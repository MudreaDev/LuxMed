using AutoMapper;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using LuxMed.Domain.Entities.User;
using LuxMed.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace LuxMed.Controllers
{
    public class SignInController : Controller
    {
        private readonly ISession _session;
        public SignInController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();
        }
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<ULoginData>(login);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userLogin = _session.UserLoginSessionBL(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(login.Email);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}