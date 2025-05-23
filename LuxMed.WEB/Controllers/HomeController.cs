using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LuxMed.BusinessLogic.Interfaces;
using LuxMed.BusinessLogic;
using LuxMed.Controllers;
using LuxMed.Domain.Entities.User;
using LuxMed.Models;

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

        public ActionResult UserAppointments()
        {
            GetStatus();
            var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];
            var profile = _session.GetUserByCookie(apiCookie.Value);
            var appointments = _session.GetAppointmentList().Where(a => a.UserId == profile.Id);
            ViewBag.appointments = appointments;
            return View();
        }

        public ActionResult Appointment()
        {
            GetStatus();

            var doctorList = _session.GetDoctorList()
                .Select(d => new SelectListItem
                {
                    Text = $"Dr. {d.Username} - {d.Type}",  // Ce se vede în dropdown
                    Value = d.Username                      // Ce se trimite în form
                }).ToList();

            ViewBag.doctors = doctorList;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Appointment(AddAppointment appointment)
        {
            if (ModelState.IsValid)
            {
                var doctorList = _session.GetDoctorList()
                    .Select(d => new SelectListItem
                    {
                        Text = $"Dr. {d.Username} - {d.Type}",
                        Value = d.Username
                    }).ToList();

                ViewBag.doctors = doctorList;
               

                var data = Mapper.Map<AddAppointmentData>(appointment);

                var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];
                var profile = _session.GetUserByCookie(apiCookie.Value);

                data.UserId = profile.Id;

                var addAppointment = _session.AddAppointment(data);
                if (addAppointment.Status)
                {
                    return RedirectToAction("Appointment", "Home");
                }
                else
                {
                    ModelState.AddModelError("", addAppointment.StatusMsg);
                    return View();
                }
            }
            return View();
        }


        





    }


}