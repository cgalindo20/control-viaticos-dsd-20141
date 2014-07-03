using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlViaticosApp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "CONTROL DE VIÁTICOS";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
