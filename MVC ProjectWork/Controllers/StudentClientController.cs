using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    //[Authorize]
    public class StudentClientController : Controller
    {
        // GET: StudentClient
        public ActionResult Index()
        {
            return View();
        }
    }
}