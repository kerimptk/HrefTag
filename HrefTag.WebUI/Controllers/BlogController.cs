using AutoMapper;
using Blog.Domain.Entities;
using Blog.Domain.Enum;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace HrefTag.WebUI.Controllers
{
    public class BlogController : Controller
    {
        readonly IYaziService _yaziService;
        readonly IYorumService _yorumService;
        readonly IKategoriService _kategoriService;
        readonly IKategoriYaziService _kategoriYaziService;
        readonly IEtiketYaziService _etiketYaziService;
        readonly IReklamAlanlariService _reklamAlanlariService;
        readonly IMapper _mapper;

        public BlogController(
            IYaziService yaziService,
            IYorumService yorumService,
            IKategoriService kategoriService,
            IKategoriYaziService kategoriYaziService,
            IEtiketYaziService etiketYaziService,
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper
            )
        {
            _yaziService = yaziService;
            _yorumService = yorumService;
            _kategoriService = kategoriService;
            _kategoriYaziService = kategoriYaziService;
            _reklamAlanlariService = reklamAlanlariService;
            _etiketYaziService = etiketYaziService;
            _mapper = mapper;
        }

        [Route("Blog")]
        public IActionResult Index()
        {   
            var yazilar = _yaziService.GetListWithKategoriByOnayli();
            var yazilarMap = _mapper.Map<List<BlogYaziListDto>>(yazilar);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new BlogViewModel()
            {
                blogYaziListDtos = yazilarMap,
                reklamAlanlariDtos = reklamlarMap
            };
            return View(viewModel);
        }

        [Route("{Post}")]
        public IActionResult Yazi(string post)
        {
            var yazilar = _yaziService.GetOnayliByUrlBaslik(post);
            if (yazilar == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            yazilar.OkunmaSayisi++;
            _yaziService.Update(yazilar);

            var yaziKategorisi = _kategoriYaziService.GetListKategoriByYaziId(yazilar.Id);
            var kategoriYaziList = _kategoriYaziService.GetListByKategoriIdWithYazi(yaziKategorisi[0].KategoriId);
            var kategoriYaziListMap = _mapper.Map<List<KategoriYaziListDto>>(kategoriYaziList);

            var etiket = _etiketYaziService.GetListWithEtiket(yazilar.Id);
            var etiketMap = _mapper.Map<List<EtiketYaziDto>>(etiket);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var yorumlar = _yorumService.GetList();
            var yorumlarMap = _mapper.Map<List<YorumDto>>(yorumlar);

            var populerIcerikler = _yaziService.GetListCokOkunanlar();
            var populerIceriklerMap = _mapper.Map<List<PopulerIceriklerDto>>(populerIcerikler);

            var YaziMap = _mapper.Map<YaziDto>(yazilar);

            var viewModel = new YaziViewModel()
            {
                Yazi = YaziMap,
                kategoriYaziListDtos = kategoriYaziListMap,
                populerIceriklerDtos = populerIceriklerMap,
                Reklamlar = reklamMap,
                Yorumlar = yorumlarMap,
                etiketYaziDtos = etiketMap
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult yorumYap(Yorum item)
        {
            item.InsertDate = DateTime.Now;
            item.OnayDurumuId = (int)EOnayDurum.Taslak;

            _yorumService.Add(item);

            var yazi = _yaziService.GetById((int)item.YaziId);
            string UrlBaslik = yazi.UrlBaslik;

            return RedirectToAction("Yazi", new { post = UrlBaslik });
        }
    }
}
