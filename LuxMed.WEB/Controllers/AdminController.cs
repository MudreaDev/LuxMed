using System.Web.Mvc;
using WebApp.BusinessLogic.DBModel;

namespace LuxMed.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            SessionStatus();
            if (((string)System.Web.HttpContext.Current.Session["LoginStatus"]) != "SingIn")
            {
                return RedirectToAction("Index", "SingIn");
            }
            UDB();

            if (main.User.Level.ToString() == "Admin")
            {
                main.Users = UserContext().Users;
            }

            return View(main);
        }
    }
}