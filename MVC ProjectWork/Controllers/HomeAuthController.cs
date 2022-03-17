using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    [Authorize]
    public class HomeAuthController : Controller
    {
        // GET: HomeAuth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            return View();
        }
    }
}