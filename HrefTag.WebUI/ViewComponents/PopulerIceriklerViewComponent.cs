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
    public class PopulerIcerikler : ViewComponent
    {
        IYaziService _yaziService;
        IMapper _mapper;
        public PopulerIcerikler(IYaziService yaziService
            , IMapper mapper)
        {
            _yaziService = yaziService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var yazilar = _yaziService.GetListCokOkunanlar();
            var yazilarMap = _mapper.Map<List<BlogYaziListDto>>(yazilar);

            var ViewModel = new PopulerIceriklerViewModel()
            {
                blogYaziListDtos = yazilarMap,
            };
            return View(ViewModel);
        }
    }
}
