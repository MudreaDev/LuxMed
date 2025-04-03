using LuxMed.BusinesLogic;
using LuxMed.Domain.Entities.User;
using System.Web.Mvc;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.Domain.Entities.User.Global;
using LuxMed.WEB.Models;
using System;

namespace LuxMed.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(userLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDataTime = DateTime.Now
                };
                var UserLogin = _session.UserLogin(data);
                if (UserLogin.Status)
                {
                    LevelStatus status = _session.CheckLevel(UserLogin.SessionKey);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("Name de utilizator sau parola incorecta. Va rugam sa incercati din nou!", UserLogin.StatusMessage);
                    return View();
                }
            }
            return View();
        }
    }
}