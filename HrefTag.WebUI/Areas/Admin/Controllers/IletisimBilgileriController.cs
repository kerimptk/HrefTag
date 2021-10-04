using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class IletisimBilgileriController : Controller
    {
        IIletisimBilgileriService _iletisimBilgileriService;
        IMapper _mapper;
        public IletisimBilgileriController(
            IIletisimBilgileriService iletisimBilgileriService,
            IMapper mapper)
        {
            _iletisimBilgileriService = iletisimBilgileriService;
            _mapper = mapper;
        }

        public IActionResult index()
        {
            var iletisimBilgileri = _iletisimBilgileriService.GetById(1);
            var iletisimBilgileriMap = _mapper.Map<IletisimBilgileriDto>(iletisimBilgileri);

            var viewModel = new AdminIletisimBilgileriViewModel()
            {
                iletisimBilgileriDto = iletisimBilgileriMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> index(IletisimBilgileriDto iletisimBilgileriDto)
        {
            var iletisimBilgileri = _iletisimBilgileriService.GetById(1);
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                string fName = Guid.NewGuid().ToString() + file.FileName;
                if (file.Name == "OneCikanGorsel")
                    iletisimBilgileri.OneCikanGorsel = fName;

                string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            iletisimBilgileri.SayfaBasligi = iletisimBilgileriDto.SayfaBasligi;
            iletisimBilgileri.Aciklama = iletisimBilgileriDto.Aciklama;            
            iletisimBilgileri.Adres = iletisimBilgileriDto.Adres;
            iletisimBilgileri.Eposta = iletisimBilgileriDto.Eposta;
            iletisimBilgileri.Harita = iletisimBilgileriDto.Harita;
            iletisimBilgileri.Telefon = iletisimBilgileriDto.Telefon;
            _iletisimBilgileriService.Update(iletisimBilgileri);
            return RedirectToAction("Index");
        }
    }
}