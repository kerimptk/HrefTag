using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HrefTag.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index([FromQuery(Name = "StatusCode")] int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return RedirectToAction("NotFound", "Error");

                case 302:
                    return RedirectToAction("DeveloperMode", "Error");

                default:
                    break;
            }

            return View();
        }


        [Route("DeveloperMode")]
        public IActionResult DeveloperMode()
        {
            return View();
        }


        [Route("NotFound")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
