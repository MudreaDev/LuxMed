using AutoMapper;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using LuxMed.Domain.Entities.User;
using LuxMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxMed.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ISession _session;
        public SignUpController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Register
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<URegisterData>(register);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userRegister = _session.UserRegistrationSessionBL(data);
                if (userRegister.Status)
                {
                    HttpCookie cookie = _session.GenCookie(register.Email);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}