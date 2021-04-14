using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HrefTag.WebUI.Controllers
{
    public class EditorunSectikleriController : Controller
    {
        IYaziService _yaziService;
        IReklamAlanlariService _reklamAlanlariService;
        IMapper _mapper;
        public EditorunSectikleriController(
            IYaziService yaziService,
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper
            )
        {
            _yaziService = yaziService;
            _reklamAlanlariService = reklamAlanlariService;
            _mapper = mapper;
        }

        [Route("EditorunSectikleri")]
        public IActionResult index()
        {
            var oneCikan = _yaziService.GetListOneCikan();
            var oneCikanMap = _mapper.Map<List<EditorunSectikleriDto>>(oneCikan);

            var yazilar = _yaziService.GetListOnayli();
            var yazilarMap = _mapper.Map<List<YaziDto>>(yazilar);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new EditorunSectikleriViewModel()
            {
                editorunSectikleriDtos = oneCikanMap,
                yaziDtos = yazilarMap,
                reklamAlanlariDtos = reklamlarMap
            };
            return View(viewModel);
        }
    }
}
