using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BaseCore.Controllers.MVC;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.Areas.yp.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ToDoListController : BaseController
    {
        IToDoListService _toDoListService;
        IUserService _userService;
        IHttpContextAccessor _httpContextAccessor;
        IMapper _mapper;

        public ToDoListController(
            IToDoListService toDoListService,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IMapper mapper) : base(httpContextAccessor)
        {
            _toDoListService = toDoListService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var toDoList = _toDoListService.GetList();
            var toDoListMap = _mapper.Map<List<ToDoListDto>>(toDoList);

            var viewModel = new AdminToDoListVievModel()
            {
                toDoListDtos = toDoListMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Ekle(ToDoListDto toDoListDto)
        {
            toDoListDto.Olusturan = GetUserId();
            var toDoListMap = _mapper.Map<ToDoList>(toDoListDto);

            toDoListMap.InsertDate = DateTime.Now;

            _toDoListService.Add(toDoListMap);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult YapildiOlarakIsaretle(int id)
        {
            var yapilacakis = _toDoListService.GetById(id);
            yapilacakis.Durum = 1;
            _toDoListService.Update(yapilacakis);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult IptalEt(int id)
        {
            var yapilacakis = _toDoListService.GetById(id);
            yapilacakis.Durum = 2;
            _toDoListService.Update(yapilacakis);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult geriYukle(int id)
        {
            var yapilacakis = _toDoListService.GetById(id);
            yapilacakis.Durum = 0;
            _toDoListService.Update(yapilacakis);
            return RedirectToAction("index");
        }


        [HttpPost]
        public IActionResult duzenle(ToDoListDto toDoListDto)
        {
            var yapilacakis = _toDoListService.GetById(toDoListDto.Id);
            yapilacakis.Durum = 0;
            yapilacakis.IsinAdi = toDoListDto.IsinAdi;
            yapilacakis.Icerik = toDoListDto.Icerik;
            yapilacakis.SonTarih = toDoListDto.SonTarih;
            yapilacakis.UpdateDate = DateTime.Now;
            _toDoListService.Update(yapilacakis);
            return RedirectToAction("index");
        }
    }
}
