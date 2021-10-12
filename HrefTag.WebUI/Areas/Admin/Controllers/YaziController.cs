using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using BaseCore.Aspects.Validation;
using BaseCore.Controllers.MVC;
using Blog.Application.Validations.FluentValidation;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class YaziController : BaseController
    {
        IHttpContextAccessor httpContextAccessor;
        IYaziService _yaziService;
        IKategoriService _kategoriService;
        IKategoriYaziService _kategoriYaziService;
        IYorumService _yorumService;
        IGenelAyarlarService _genelAyarlarService;
        IMapper _mapper;
        public YaziController(IHttpContextAccessor _httpContextAccessor, IYaziService yaziService,
            IKategoriService kategoriService,
            IKategoriYaziService kategoriYaziService,
            IYorumService yorumService,
            IGenelAyarlarService genelAyarlarService,
            IMapper mapper) : base(_httpContextAccessor)
        {
            _yaziService = yaziService;
            _kategoriService = kategoriService;
            _kategoriYaziService = kategoriYaziService;
            _yorumService = yorumService;
            _mapper = mapper;
            _genelAyarlarService = genelAyarlarService;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult YaziListesi()
        {
            var yazilar = _yaziService.GetListSilinmemisWithUser();
            var yazilarMap = _mapper.Map<List<YaziDto>>(yazilar);

            var viewModel = new AdminYaziViewModel()
            {
                yaziDtos = yazilarMap
            };

            return View(viewModel);
        }


        public IActionResult YaziEkleme()
        {
            var kategoriler = _kategoriService.GetList().Where(x => x.ParentMi != true).ToList();
            var kategorilerMap = _mapper.Map<List<KategoriDto>>(kategoriler);

            var ayar = _genelAyarlarService.GetById(1);
            var ayarMap = _mapper.Map<GenelAyarlarDto>(ayar);

            var viewModel = new YaziInsertDto()
            {
                kategoriDtos = kategorilerMap,
                GenelAyarlarDto = ayarMap
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidationAspect(Validator = typeof(YaziEkleValidator))]
        public async Task<IActionResult> YaziEkleme(YaziInsertDto yaziInsertDto)
        {
            var yazi = _mapper.Map<Yazi>(yaziInsertDto);

            foreach (var selected in yaziInsertDto.SelectedCategoryIds)
                yazi.KategoriYazilar.Add(new KategoriYazi() { KategoriId = selected, Yazi = yazi });

            yazi.UserId = GetUserId();

            var UrlBaslikBasic = BaseCore.Utilities.Helpers.UrlHelper.ToUrlSlug(yazi.Baslik);

            var baslikCount = _yaziService.GetByUrlBaslik(UrlBaslikBasic);

            var maxId = _yaziService.GetList().OrderByDescending(i => i.Id).ToList().FirstOrDefault();
            if (baslikCount == null)
            {
                yazi.UrlBaslik = UrlBaslikBasic;
            }
            else
            {
                yazi.UrlBaslik = UrlBaslikBasic + '-' + (maxId.Id + 1);
            }
            var files = HttpContext.Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                yazi.OneCikanGorsel = "default.png";
            }
            else
            {
                foreach (var file in files)
                {
                    string fName = Guid.NewGuid().ToString() + file.FileName;
                    yazi.OneCikanGorsel = fName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            _yaziService.Add(yazi);

            return RedirectToAction("YaziListesi");
        }


        [HttpGet]
        public async Task<IActionResult> yayinla([FromQuery(Name = "Id")] int id)
        {
            var yazi = _yaziService.GetById(id);
            yazi.OnayDurumuId = 1;
            _yaziService.Update(yazi);
            return RedirectToAction("YaziListesi");
        }

        [HttpGet]
        public async Task<IActionResult> yayindankaldir([FromQuery(Name = "Id")] int id)
        {
            var yazi = _yaziService.GetById(id);
            yazi.OnayDurumuId = 0;
            _yaziService.Update(yazi);
            return RedirectToAction("YaziListesi");
        }


        [HttpGet]
        public IActionResult copeat([FromQuery(Name = "Id")] int id)
        {
            var yazi = _yaziService.GetById(id);
            yazi.SilId = 1;
            yazi.OnayDurumuId = 0;
            _yaziService.Update(yazi);
            return RedirectToAction("YaziListesi");
        }


        [HttpGet]
        public IActionResult YaziDuzenle([FromQuery(Name = "Id")] int id)
        {
            var yazi = _yaziService.GetWithKategoriYaziById(id);
            if (yazi == null) return RedirectToAction("404", "Error");

            var yaziMap = _mapper.Map<YaziUpdateDto>(yazi);

            var ayar = _genelAyarlarService.GetById(1);
            var ayarMap = _mapper.Map<GenelAyarlarDto>(ayar);

            var kategoriler = _kategoriService.GetList().Where(x => x.ParentMi != true).ToList();
            var kategoriDtos = _mapper.Map<List<KategoriDto>>(kategoriler);

            var ViewModel = new AdminYaziUpdateViewModel()
            {
                yaziUpdateDto = yaziMap,
                kategoriDtos = kategoriDtos,
                genelAyarlarDto = ayarMap
            };
            return View(ViewModel);
        }


        [HttpPost]
        [ValidationAspect(Validator = typeof(YaziGuncelleValidator))]
        public async Task<IActionResult> YaziDuzenleOnay(YaziUpdateDto yaziUpdateDto)
        {
            var yazi = _mapper.Map<Yazi>(yaziUpdateDto);
            var eskiYazi = _yaziService.GetById(yazi.Id);

            var silinecekKategoriler = _kategoriYaziService.GetListSilinecekKategoriler(yazi.Id);

            foreach (var item in silinecekKategoriler)
            {
                _kategoriYaziService.Delete(item);
            }

            foreach (var selected in yaziUpdateDto.SelectedCategoryIds)
            {
                _kategoriYaziService.Add(new KategoriYazi() { KategoriId = selected, YaziId = yazi.Id });
            }

            eskiYazi.Baslik = yazi.Baslik;
            eskiYazi.Icerik = yazi.Icerik;
            eskiYazi.Ozet = yazi.Ozet;
            eskiYazi.InsertDate = eskiYazi.InsertDate;
            eskiYazi.OkunmaSayisi = eskiYazi.OkunmaSayisi;
            eskiYazi.OnayDurumuId = yazi.OnayDurumuId;
            eskiYazi.OneCikan = yazi.OneCikan;
            eskiYazi.SilId = eskiYazi.SilId;
            eskiYazi.DuyuruMu = yazi.DuyuruMu;
            eskiYazi.UpdateDate = DateTime.Now;
            eskiYazi.UrlBaslik = eskiYazi.UrlBaslik;
            eskiYazi.UserId = eskiYazi.UserId;

            var files = HttpContext.Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                eskiYazi.OneCikanGorsel = eskiYazi.OneCikanGorsel;
            }
            else
            {
                foreach (var file in files)
                {
                    string fName = Guid.NewGuid().ToString() + file.FileName;
                    eskiYazi.OneCikanGorsel = fName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                    using (var stream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(stream);
                }
            }
            var result = _yaziService.Update(eskiYazi);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }


        public IActionResult Etiketler()
        {
            return View();
        }


        public IActionResult geridonusumkutusu()
        {
            var yazilar = _yaziService.GetListSilinenWithUser();
            var yazilarMap = _mapper.Map<List<YaziDto>>(yazilar);

            var viewModel = new AdminYaziViewModel()
            {
                yaziDtos = yazilarMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult kalicisil(int id)
        {
            foreach (var item in _kategoriYaziService.GetList())
            {
                if (item.YaziId == id)
                {
                    _kategoriYaziService.Delete(item);
                }
            }

            foreach (var item in _yorumService.GetList())
            {
                if (item.YaziId == id)
                {
                    _yorumService.Delete(item);
                }
            }

            _yaziService.Delete(new Blog.Domain.Entities.Yazi
            {
                Id = id
            });
            return RedirectToAction("geridonusumkutusu");
        }


        [HttpPost]
        public IActionResult geriyukle(int id)
        {
            var yazi = _yaziService.GetById(id);
            yazi.SilId = 0;
            _yaziService.Update(yazi);
            return RedirectToAction("geridonusumkutusu");
        }
    }
}