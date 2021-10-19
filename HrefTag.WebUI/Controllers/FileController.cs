using AutoMapper;
using Blog.Domain.Entities;
using Blog.Domain.Enum;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace HrefTag.WebUI.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment webHostEnvironment;

        public FileController(
            IWebHostEnvironment webHostEnvironment
            )
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("sitemap.xml")]
        public IActionResult sitemap()
        {
            string wwwPath = this.webHostEnvironment.WebRootPath;

            string filePath = wwwPath + @"\Dizin\";
            string fileName = "sitemap.xml";

            var file = System.IO.File.ReadAllText(filePath + fileName);

            return new ContentResult
            {
                Content = file,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }


        [HttpGet("robots.txt")]
        public IActionResult robots()
        {
            string wwwPath = this.webHostEnvironment.WebRootPath;

            string filePath = wwwPath + @"\Dizin\";
            string fileName = "robots.txt";

            var file = System.IO.File.ReadAllText(filePath + fileName);

            return new ContentResult
            {
                Content = file,
                StatusCode = 200
            };
        }

        [HttpGet("ads.txt")]
        public IActionResult ads()
        {
            string wwwPath = this.webHostEnvironment.WebRootPath;

            string filePath = wwwPath + @"\Dizin\";
            string fileName = "ads.txt";

            var file = System.IO.File.ReadAllText(filePath + fileName);

            return new ContentResult
            {
                Content = file,
                StatusCode = 200
            };
        }
    }
}
