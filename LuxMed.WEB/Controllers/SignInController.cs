using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace LuxMed.WEB.Controllers
{
    public class SignInController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Home()
        {
            return View();
        }

    }        
}