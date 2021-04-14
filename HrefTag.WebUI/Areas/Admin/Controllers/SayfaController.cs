using System;
using System.Collections.Generic;
using System.IO;
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

namespace HrefTag.WebUI.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SayfaController : BaseController
    {
        IHttpContextAccessor httpContextAccessor;
        ISayfaService _sayfaService;
        IUserService _userService;
        IMapper _mapper;
        public SayfaController(IHttpContextAccessor _httpContextAccessor,
            ISayfaService sayfaService,
            IUserService userService,
            IMapper mapper) : base(_httpContextAccessor)
        {
            _sayfaService = sayfaService;
            _mapper = mapper;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> SayfaListesi()
        {
            var Sayfalar = _sayfaService.GetList();
            var SayfalarMap = _mapper.Map<List<SayfaDto>>(Sayfalar);

            var viewModel = new AdminSayfaViewModel()
            {
                sayfaDtos = SayfalarMap
            };

            return View(viewModel);
        }


        public IActionResult SayfaEkleme()
        {
            return View();
        }


        [HttpPost]
        [ValidationAspect(Validator = typeof(SayfaInsertUpdateValidator))]
        public async Task<IActionResult> SayfaEkleme(SayfaInsertDto SayfaInsertDto)
        {
            var Sayfa = _mapper.Map<Sayfa>(SayfaInsertDto);

            var files = HttpContext.Request.Form.Files;

            foreach (var file in files)
            {
                string fName = Guid.NewGuid().ToString() + file.FileName;
                Sayfa.OneCikanGorsel = fName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            _sayfaService.Add(Sayfa);

            return RedirectToAction("SayfaListesi");
        }


        [HttpGet]
        public async Task<IActionResult> yayinla([FromQuery(Name = "Id")] int id)
        {
            var Sayfa = _sayfaService.GetById(id);
            Sayfa.OnayDurumuId = 1;
            _sayfaService.Update(Sayfa);
            return RedirectToAction("SayfaListesi");
        }

        [HttpGet]
        public async Task<IActionResult> yayindankaldir([FromQuery(Name = "Id")] int id)
        {
            var Sayfa = _sayfaService.GetById(id);
            Sayfa.OnayDurumuId = 0;
            _sayfaService.Update(Sayfa);
            return RedirectToAction("SayfaListesi");
        }


        [HttpGet]
        public IActionResult copeat([FromQuery(Name = "Id")] int id)
        {
            var Sayfa = _sayfaService.GetById(id);
            Sayfa.SilId = 1;
            Sayfa.OnayDurumuId = 0;
            _sayfaService.Update(Sayfa);
            return RedirectToAction("SayfaListesi");
        }


        [HttpGet]
        public IActionResult SayfaDuzenle([FromQuery(Name = "Id")] int id)
        {
            var Sayfa = _sayfaService.GetById(id);
            if (Sayfa == null) return RedirectToAction("404", "Error");

            var SayfaMap = _mapper.Map<SayfaUpdateDto>(Sayfa);

            var ViewModel = new AdminSayfaInsertUpdateViewModel()
            {
                sayfaUpdateDto = SayfaMap
            };
            return View(ViewModel);
        }


        [HttpPost]
        [ValidationAspect(Validator = typeof(SayfaInsertUpdateValidator))]
        public async Task<IActionResult> SayfaDuzenleOnay(SayfaInsertDto SayfaUpdateDto)
        {
            var Sayfa = _mapper.Map<Sayfa>(SayfaUpdateDto);
            var eskiSayfa = _sayfaService.GetById(Sayfa.Id);

            eskiSayfa.UpdateDate = DateTime.Now;
            eskiSayfa.Baslik = Sayfa.Baslik;
            eskiSayfa.UrlBaslik = eskiSayfa.UrlBaslik;
            eskiSayfa.Icerik = Sayfa.Icerik;
            eskiSayfa.OnayDurumuId = Sayfa.OnayDurumuId;

            var files = HttpContext.Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                eskiSayfa.OneCikanGorsel = Sayfa.OneCikanGorsel;
            }
            else
            {
                foreach (var file in files)
                {
                    string fName = Guid.NewGuid().ToString() + file.FileName;
                    eskiSayfa.OneCikanGorsel = fName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            _sayfaService.Update(eskiSayfa);

            return RedirectToAction("SayfaListesi");
        }


        public IActionResult geridonusumkutusu()
        {
            var Sayfalar = _sayfaService.GetListSilinen();
            var SayfalarMap = _mapper.Map<List<SayfaDto>>(Sayfalar);

            var viewModel = new AdminSayfaViewModel()
            {
                sayfaDtos = SayfalarMap
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult kalicisil([FromQuery(Name = "Id")] int id)
        {
            _sayfaService.Delete(new Blog.Domain.Entities.Sayfa
            {
                Id = id
            });
            return RedirectToAction("geridonusumkutusu");
        }


        [HttpGet]
        public IActionResult geriyukle([FromQuery(Name = "Id")] int id)
        {
            var Sayfa = _sayfaService.GetById(id);
            Sayfa.SilId = 0;
            _sayfaService.Update(Sayfa);
            return RedirectToAction("geridonusumkutusu");
        }
    }
}