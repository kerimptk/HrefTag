using AutoMapper;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.Controllers
{
    public class EtiketController : Controller
    {
        IEtiketService _etiketService;
        IEtiketYaziService _etiketYaziService;
        IReklamAlanlariService _reklamAlanlariService;
        IMapper _mapper;
        public EtiketController(
            IEtiketService etiketService,
            IEtiketYaziService etiketYaziService,
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper
            )
        {
            _etiketService = etiketService;
            _etiketYaziService = etiketYaziService;
            _reklamAlanlariService = reklamAlanlariService;
            _mapper = mapper;
        }


        [Route("Etiket/{etk}")]
        public IActionResult etiket(string etk)
        {

            var etiket = _etiketService.GetByEtiketUrlAd(etk);

            if (etiket == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var etiketYazilar = _etiketYaziService.GetListByEtiketIdWithYazi(etiket.Id);
            var etiketYazilarMap = _mapper.Map<List<EtiketYaziListDto>>(etiketYazilar);

            var etiketAd = _etiketService.GetById(etiket.Id);
            var etiketAdMap = _mapper.Map<EtiketDto>(etiketAd);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new EtiketYaziViewModel()
            {
                etiketYaziListDtos = etiketYazilarMap,
                etiketDto = etiketAdMap,
                reklamAlanlariDtos = reklamlarMap
            };

            return View(viewModel);
        }
    }
}
