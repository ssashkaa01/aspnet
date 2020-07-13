using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExams.Controllers
{
    public class UserProfileController : Controller
    {
        public ActionResult Profile()
        {
            return View();
        }
    }
}