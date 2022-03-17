using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class mystudentController : Controller
    {
        // GET: mystudent
        private MVC_ProjectEntities db = new MVC_ProjectEntities();
        public JsonResult Getstudents()
        {
            return Json(db.student2, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getstudent(int id)
        {
            var student = db.student2.Find(id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Poststudent(student2 student)
        {
            db.student2.Add(student);
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Deletestudent(int id)
        {
            student2 student = db.student2.Find(id);
            db.student2.Remove(student);
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Putstudent(int id, student2 student)
        {
            student2 st = db.student2.Find(id);
            st.id = id;
            st.name = student.name;
            st.fee = student.fee;
            st.@class = student.@class;
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

    }
}