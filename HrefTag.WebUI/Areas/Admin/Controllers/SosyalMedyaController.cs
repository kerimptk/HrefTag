using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Domain.Interfaces;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;
using HrefTag.WebUI.ViewModels;
using System.Linq;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SosyalMedyaController : Controller
    {
        ISosyalMedyaService _sosyalMedyaService;
        IMapper _mapper;
        public SosyalMedyaController(ISosyalMedyaService sosyalMedyaService,
            IMapper mapper)
        {
            _sosyalMedyaService = sosyalMedyaService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var sosyalMedya = _sosyalMedyaService.GetById(1);
            var sosyalMedyaMap = _mapper.Map<SosyalMedyaDto>(sosyalMedya);

            var viewModel = new AdminSosyalMedyaViewModel()
            {
                sosyalMedyaDto = sosyalMedyaMap
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(SosyalMedyaDto sosyalMedyaDto)
        {
            var sosyalMedya = _sosyalMedyaService.GetList().Where(i => i.Id == sosyalMedyaDto.Id).FirstOrDefault();
            sosyalMedya.Instagram = sosyalMedyaDto.Instagram;
            sosyalMedya.Twitter = sosyalMedyaDto.Twitter;
            sosyalMedya.Linkedin = sosyalMedyaDto.Linkedin;
            sosyalMedya.Youtube = sosyalMedyaDto.Youtube;
            _sosyalMedyaService.Update(sosyalMedya);
            return RedirectToAction("Index");
        }
    }
}