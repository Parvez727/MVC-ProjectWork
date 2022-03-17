using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    //[Authorize]
    public class MidmonthProjectController : Controller
    {
        // GET: MidmonthProject
        public ActionResult Index()
        {
            return View();
        }
    }
}