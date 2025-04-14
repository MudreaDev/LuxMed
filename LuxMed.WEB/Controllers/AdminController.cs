using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxMed.BusinessLogic.AppBL;
using LuxMed.Domain.Entities.User;
using AutoMapper;
using LuxMed.Domain.Entities.Admin;
using LuxMed.Domain.Entities.Doctor;
using LuxMed.Domain.Entities.Appointment;
using System.IO;
using System.Web.UI.WebControls;
using LuxMed.Models;

namespace LuxMed.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ISession _session;
        private readonly IAdmin _admin;
        public AdminController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();
            _admin = bl.GetAdminBL();
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

        public ActionResult AddUser()
        {
            GetStatus();
            using (var db = new TableContext())
            {
                List<UserTable> usersList = db.Users.OrderByDescending(u => u.Level).ToList();
                ViewBag.usersList = usersList;
            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(AddUser user)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<AddUserData>(user);

                var addUser = _admin.AddUser(data);
                if (addUser.Status)
                {
                    return RedirectToAction("AddUser", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", addUser.StatusMsg);
                    return View();
                }
            }
            return View();
        }





    }
}