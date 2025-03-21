using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxMed.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBl();
        }

        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(userlogin login)
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Nume de utilizator sau parola incorecta. Va rugam sa incercati din nou!", UserLogin.StatusMessage);
                    return View();
                }
            }
            return View();
        }
    }
}