using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HrefTag.WebUI.Controllers
{
    public class DuyurularController : Controller
    {
        IYaziService _yaziService;
        IReklamAlanlariService _reklamAlanlariService;
        IMapper _mapper;
        public DuyurularController(
            IYaziService yaziService,
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper
            )
        {
            _yaziService = yaziService;
            _reklamAlanlariService = reklamAlanlariService;
            _mapper = mapper;
        }

        [Route("Duyurular")]
        public IActionResult index()
        {
            var duyurular = _yaziService.GetListDuyurular();
            var duyurularMap = _mapper.Map<List<DuyurularDto>>(duyurular);

            var yazilar = _yaziService.GetListOnayli();
            var yazilarMap = _mapper.Map<List<YaziDto>>(yazilar);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new DuyurularViewModel()
            {
                duyurularDtos = duyurularMap,
                yaziDtos = yazilarMap,
                reklamAlanlariDtos = reklamlarMap
            };
            return View(viewModel);
        }
    }
}
