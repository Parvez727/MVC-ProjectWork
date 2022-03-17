using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page1()
        {
            ViewBag.Message = "Welcome to Page1";
            return View();
        }

        [HttpGet]
        [Route("hello")]
        public ActionResult Page2()
        {
            ViewBag.Message = "Welcome to Page2";
            return View();
        }
        public ActionResult Page3()
        {
            ViewBag.Message = "Welcome to Page3";
            return View();
        }
        public ActionResult Page4()
        {
            ViewBag.Message = "Welcome to Page4";
            return View();
        }

        public ViewResult Page6()
        {
            ViewBag.Message = "RouteData from RouteConfig.cs";
            var data = RouteData.Values["controller"] ?? String.Empty;
            var data2 = RouteData.Values["action"] ?? String.Empty;
            var data3 = RouteData.Values["id"] ?? "No Id";
            var data4 = Request["name"] ?? "no query string";
            ViewBag.Data = "Controller name is :" + data;
            ViewBag.Data2 = "Action name is :" + data2;
            ViewBag.Data3 = "Parameter name is :" + data3;
            ViewBag.Data4 = "Querystring:name is :" + data4;
            return View();
        }

        public JavaScriptResult GetScript()
        {
            var script = "alert('Hello')";
            return JavaScript(script);
        }
        public JsonResult GetMyJson()
        {
            cm_restoEntities a = new cm_restoEntities();
            return Json(a.foodMenuTBs.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ViewResult GetByHtmlView()
        {
            cm_restoEntities a = new cm_restoEntities();
            var b = a.foodMenuTBs.ToList();
            return View(b);
        }

        //display to add two numbers
        [HttpGet]
        public ViewResult AddingNumbers()
        {
            return View();
        }
        //submit button work
        [HttpPost]
        public ActionResult AddingNumbers(AddingNumbers a)
        {
            if (ModelState.IsValid)
            {
                a.OutputNumber = a.Number1 + a.Number2;
                //from controller to view, data can be passed in three ways
                //first way: viewBag
                ViewBag.ot = a.OutputNumber;
                //second way: viewData
                ViewData["ot"] = a.OutputNumber;
                //third way: ModelData
                return View("Page8", a);
            }
            return View(a);
        }

    }
}