using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxMed.WEB.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: widgets
        public ActionResult Widgets()
        {
            return View();
        }
    }
}