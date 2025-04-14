using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LuxMed.BusinessLogic.AppBL;
using LuxMed.Models;
using LuxMed.Domain.Entities.User;

namespace LuxMed.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISession _session;
        public HomeController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();
        }

        public void GetStatus()
        {
            SessionStatus();
            var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];
            string userStatus = (string)System.Web.HttpContext.Current.Session["LoginStatus"];
            if (userStatus != "guest")
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                ViewBag.level = profile.Level;
            }
            ViewBag.userStatus = userStatus;
        }

        public ActionResult Home()
        {
            GetStatus();
            var doctors = _session.GetDoctorList().Take(4);
            ViewBag.doctors = doctors;
            return View();
        }
    }

}

