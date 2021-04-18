using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Models.ViewComponents
{
    public class KategoriList : ViewComponent
    {
        IKategoriService _kategoriService;
        IMapper _mapper;
        public KategoriList(IKategoriService kategoriService
            , IMapper mapper)
        {
            _kategoriService = kategoriService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var kategoriler = _kategoriService.GetList();
            var kategorilerMap = _mapper.Map<List<KategoriDto>>(kategoriler);

            var ViewModel = new KategoriListViewModel()
            {
                kategoriDtos = kategorilerMap,
            };
            return View(ViewModel);
        }
    }
}
