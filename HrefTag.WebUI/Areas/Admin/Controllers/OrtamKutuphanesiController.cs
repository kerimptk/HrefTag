using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrtamKutuphanesiController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;


        public OrtamKutuphanesiController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Obsolete]
        public IActionResult Index()
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            List<string> dosya = new List<string>();
            foreach (string file in Directory.EnumerateFiles(
                        path,
                        "*",
                        SearchOption.AllDirectories)
                        )
            {
                dosya.Add(file.Substring(64));
            }
            return View(new AdminOrtamKutuphanesiViewModel()
            {
                ImagePath = dosya
            });
        }
    }
}