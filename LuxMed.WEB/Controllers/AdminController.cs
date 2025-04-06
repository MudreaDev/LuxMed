using System.Web.Mvc;
using LuxMed.BusinessLogic.DBModel;
using LuxMed.BusinesLogic;
using LuxMed.Domain.Entities.User;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.User.Global;
using LuxMed.WEB.Models;
using System;


namespace LuxMed.Controllers
{
    public class AdminController : Controller
    {
        private object main;

        // GET: Admin
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "SingIn")
            {
                return RedirectToAction("Index", "SingIn");
            }

            UDB();

            if (main.User.Level.ToString() == "Admin")
            {
                main.Users = new UserContext().Users;
            }

            return View(main);
        }
    }
}
