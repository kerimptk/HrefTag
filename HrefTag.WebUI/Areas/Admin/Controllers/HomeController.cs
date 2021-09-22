using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.DataTransferObjects;
using AutoMapper;
using Blog.Domain.Interfaces;
using Blog.Domain.Entities;
using HrefTag.WebUI.ViewModels;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        IYaziService _yaziService;
        IYorumService _yorumService;
        IPostaKutusuService _postaKutusuService;
        IKategoriService _kategoriService;
        IUserService _userService;
        IMapper _mapper;

        public HomeController(
            IHttpContextAccessor httpContext,
            IYaziService yaziService,
            IYorumService yorumService,
            IPostaKutusuService postaKutusuService,
            IKategoriService kategoriService,
            IMapper mapper,
            IUserService userService
            )
        {
            _yaziService = yaziService;
            _yorumService = yorumService;
            _postaKutusuService = postaKutusuService;
            _kategoriService = kategoriService;
            _mapper = mapper;
            _userService = userService;

        }
        public async Task<IActionResult> Dashboard()
        {
            var yazilar = _yaziService.GetList();
            var yazilarMap = _mapper.Map<List<YaziDto>>(yazilar);

            var kategoriler = _kategoriService.GetList();
            var kategorilerMap = _mapper.Map<List<KategoriDto>>(kategoriler);

            var yorumlar = _yorumService.GetList();
            var yorumlarMap = _mapper.Map<List<YorumDto>>(yorumlar);

            var gelenKutusu = _postaKutusuService.GetList();
            var gelenKutusuMap = _mapper.Map<List<PostaKutusuDto>>(gelenKutusu);

            var users = _userService.GetList();
            var usersMap = _mapper.Map<List<ProfilDto>>(users);

            var viewModel = new AdminHomeViewModel()
            {
                kategoriDtos = kategorilerMap,
                yaziDtos = yazilarMap,
                yorumDtos = yorumlarMap,
                postaKutusuDtos = gelenKutusuMap,
                accountDtos = usersMap
            }; return View(viewModel);
        }
    }
}