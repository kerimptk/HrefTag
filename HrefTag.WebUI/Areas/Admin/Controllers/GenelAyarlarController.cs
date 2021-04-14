using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class GenelAyarlarController : Controller
    {
        IGenelAyarlarService _genelAyarlarService;
        IMapper _mapper;
        public GenelAyarlarController(
            IGenelAyarlarService genelAyarlarService,
            IMapper mapper)
        {
            _genelAyarlarService = genelAyarlarService;
            _mapper = mapper;
        }
        public IActionResult index()
        {
            var ayar = _genelAyarlarService.GetById(1);
            var ayarMap = _mapper.Map<GenelAyarlarDto>(ayar);

            var viewModel = new AdminGenelAyarlarVievModel()
            {
                genelAyarlarDto = ayarMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> index(GenelAyarlarDto genelAyarlarDto)
        {
            var genelAyarlar = _genelAyarlarService.GetList().FirstOrDefault();
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                string fName = Guid.NewGuid().ToString() + file.FileName;
                if (file.Name == "Favicon")
                    genelAyarlar.Favicon = fName;

                if (file.Name == "LogoUrl")
                    genelAyarlar.LogoUrl = fName;

                string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            genelAyarlar.AraclarAktif = genelAyarlarDto.AraclarAktif;
            genelAyarlar.EditorunSectikleriAktif = genelAyarlarDto.EditorunSectikleriAktif;
            genelAyarlar.PopulerIceriklerAktif = genelAyarlarDto.PopulerIceriklerAktif;
            genelAyarlar.VideoIceriklerAktif = genelAyarlarDto.VideoIceriklerAktif;
            genelAyarlar.UpdateDate = DateTime.Now;

            _genelAyarlarService.Update(genelAyarlar);
            return RedirectToAction("index");
        }
    }
}