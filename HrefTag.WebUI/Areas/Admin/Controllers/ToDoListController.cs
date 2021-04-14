using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
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
    public class ToDoListController : Controller
    {
        IToDoListService _toDoListService;
        IMapper _mapper;

        public ToDoListController(
            IToDoListService toDoListService,
            IMapper mapper)
        {
            _toDoListService = toDoListService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var toDoList = _toDoListService.GetList();
            var toDoListMap = _mapper.Map<List<ToDoListaDto>>(toDoList);

            var viewModel = new AdminToDoListVievModel()
            {
                toDoListaDtos = toDoListMap
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult Ekle(ModelAdminToDoList item)
        //{
        //    var user = _userManager.GetUserId(_httpContext.HttpContext.User);
        //    var CurrentUser = _userManager.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(user));

        //    if (item.TblToDoList.Olusturan == null || item.TblToDoList.Olusturan == 0)
        //    {
        //        item.TblToDoList.Olusturan = CurrentUser.Id;
        //    }

        //    item.TblToDoList.Durum = 0;

        //    _ToDoListService.Add(item.TblToDoList);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult YapildiOlarakIsaretle(int id)
        //{
        //    var yapilacakis = _ToDoListService.GetTblToDoListToId(id);
        //    yapilacakis.Durum = 1;
        //    _ToDoListService.Update(yapilacakis);
        //    return RedirectToAction("DevamEdenIsler");
        //}

        //[HttpPost]
        //public IActionResult IptalEt(int id)
        //{
        //    var yapilacakis = _ToDoListService.GetTblToDoListToId(id);
        //    yapilacakis.Durum = 2;
        //    _ToDoListService.Update(yapilacakis);
        //    return RedirectToAction("DevamEdenIsler");
        //}

        //[HttpPost]
        //public IActionResult geriYukle(int id)
        //{
        //    var yapilacakis = _ToDoListService.GetTblToDoListToId(id);
        //    yapilacakis.Durum = 0;
        //    _ToDoListService.Update(yapilacakis);
        //    return RedirectToAction("DevamEdenIsler");
        //}


        //[HttpPost]
        //public IActionResult duzenle(ToDoList item)
        //{
        //    _ToDoListService.Update(item);
        //    return RedirectToAction("DevamEdenIsler");
        //}
    }
}
