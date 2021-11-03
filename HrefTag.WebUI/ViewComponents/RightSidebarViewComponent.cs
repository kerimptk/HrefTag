using AutoMapper;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewComponents
{
    public class RightSidebarViewComponent : ViewComponent
    {
        IKategoriService _kategoriService;
        IMapper _mapper;
        public RightSidebarViewComponent(
             IKategoriService kategoriService,
             IMapper mapper
            )
        {
            _kategoriService = kategoriService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var kategoriler = _kategoriService.GetList();
            var kategoriListMap = _mapper.Map<List<KategoriDto>>(kategoriler);

            var ViewModel = new RightSidebarViewModel()
            {
                KategoriDtos = kategoriListMap,
            };
            return View(ViewModel);
        }
    }
}
