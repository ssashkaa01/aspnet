using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ImageController : Controller
    {
        DataContext dataContext = new DataContext();

        // GET: Image
        public ActionResult Index()
        {
            return View(dataContext);
        }
    }
}