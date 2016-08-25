using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OP.MvcView.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.UserName = Session["User"] == null ? "" : ((OP.Model.SystemUser)Session["User"]).UserName;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string UserPwd)
        {
            return null;
        }
    }
}