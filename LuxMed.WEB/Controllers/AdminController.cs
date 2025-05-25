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
using LuxMed.Models;
using LuxMed.Domain.Entities.Doctor;
using LuxMed.Domain.Entities.Appointment;
using System.IO;
using System.Web.UI.WebControls;



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
            var usersList = _session.GetUserList();
            ViewBag.usersList = usersList;
            return View();
        }


        public ActionResult AddDoctor()
        {
            GetStatus();
            List<string> types = new List<string> { "Neurology", "Opthalmology", "Nuclear Magnetic", "Surgical", "Cardiology", "X-ray", "Dental", "Traumatology" };
            ViewBag.types = types;
            var doctorList = _session.GetDoctorList();
            ViewBag.doctorsList = doctorList;
            return View();
        }


        public ActionResult ShowAppointment()
        {
            GetStatus();
            var appointmentList = _session.GetAppointmentList();
            ViewBag.AppointmentsList = appointmentList;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor(AddDoctor doctor, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentType == "image/png")
                {
                    var path = Path.Combine(Server.MapPath($"~/Content/images/doctor/{doctor.Username}.png"));
                    imageFile.SaveAs(path);
                    doctor.Image = doctor.Username + ".png"; // setezi imaginea în model
                }

                var data = Mapper.Map<AddDoctorData>(doctor);

                var addDoctor = _admin.AddDoctor(data);

                if (addDoctor.Status)
                {
                    return RedirectToAction("AddDoctor", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", addDoctor.StatusMsg);
                    return View();
                }
            }
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            _admin.DeleteUser(id);
            return RedirectToAction("AddUser", "Admin");
        }

        public ActionResult DeleteDoctor(int id)
        {
            var doctor = _session.GetDoctorById(id);
            if (doctor != null && !string.IsNullOrEmpty(doctor.Image))
            {
                var path = Path.Combine(Server.MapPath($"~/Content/images/doctor/{doctor.Image}"));
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
            _admin.DeleteDoctor(id);
            return RedirectToAction("AddDoctor", "Admin");
        }


        public ActionResult DeleteAppointment(int id)
        {
            _admin.DeleteAppointment(id);
            return RedirectToAction("ShowAppointment", "Admin");
        }

        public ActionResult EditUser(int id)
        {
            GetStatus();
            var user = _session.GetUserById(id);
            var data = Mapper.Map<EditUser>(user);
            ViewBag.userToEdit = data;
            return View(data);
        }

        public ActionResult EditDoctor(int id)
        {
            GetStatus();
            List<string> types = new List<string> { "Neurology", "Opthalmology", "Nuclear Magnetic", "Surgical", "Cardiology", "X-ray", "Dental", "Traumatology" };
            ViewBag.types = types;
            var doctor = _session.GetDoctorById(id);
            var data = Mapper.Map<EditDoctor>(doctor);
            ViewBag.doctorToEdit = data;
            return View(data);
        }


        public ActionResult EditAppointment(int id)
        {
            GetStatus();
            List<string> doctors = _session.GetDoctorList().Select(d => d.Username).ToList();
            ViewBag.doctors = doctors;
            var appointment = _session.GetAppointmentById(id);
            var data = Mapper.Map<EditAppointment>(appointment);
            ViewBag.appointmentToEdit = data;
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUser user)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<EditUserData>(user);

                var editUser = _admin.EditUser(data);
                if (editUser.Status)
                {
                    return RedirectToAction("AddUser", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", editUser.StatusMsg);
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDoctor(EditDoctor doctor, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentType == "image/png")
                {
                    var existingDoctor = _session.GetDoctorById(doctor.Id); 
                    if (existingDoctor != null)
                    {
                        var oldPath = Path.Combine(Server.MapPath($"~/Content/images/doctor/{existingDoctor.Username}.png"));
                        var newPath = Path.Combine(Server.MapPath($"~/Content/images/doctor/{doctor.Username}.png"));
                        if (System.IO.File.Exists(oldPath))
                            System.IO.File.Delete(oldPath);
                        imageFile.SaveAs(newPath);
                        doctor.Image = doctor.Username + ".png"; 
                    }
                }

                var data = Mapper.Map<EditDoctorData>(doctor);

                var editDoctor = _admin.EditDoctor(data);
                if (editDoctor.Status)
                {
                    return RedirectToAction("AddDoctor", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", editDoctor.StatusMsg);
                    return View();
                }
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(EditAppointment appointment)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<EditAppointmentData>(appointment);

                var editAppointment = _admin.EditAppointment(data);
                if (editAppointment.Status)
                {
                    return RedirectToAction("ShowAppointment", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", editAppointment.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}