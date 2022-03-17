using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    //[Authorize]
    public class ProjectCourseController : Controller
    {
        private MVC_ProjectEntities2 db = new MVC_ProjectEntities2();
        List<MyCourse> a = new List<MyCourse>();
        // GET: ProjectCourse
        public void CommonMethod()
        {
            foreach (var d in db.Courses.ToList())
            {
                a.Add(new MyCourse() { courseid = d.courseid, coursename = d.coursename, studentid = d.studentid, teacherid = d.teacherid });
            }
            ViewBag.records = a;
        }
        public ActionResult Index(int id = 0)
        {
            ViewBag.msg = TempData["msg"];
            CommonMethod();
            if (id == 0)
            {
                return View();
            }
            else
            {
                var item = (from c in db.Courses where c.courseid == id select c).Distinct().FirstOrDefault();
                if (item != null)//if the item exists
                {
                    MyCourse b = new MyCourse() { courseid = item.courseid, coursename = item.coursename, studentid = item.studentid, teacherid = item.teacherid };
                    return View(b);
                }
                else
                {
                    ViewBag.msg = "Item Not Found";
                    return View();
                }
            }
        }

        [HttpParamAction]
        [HttpPost]
        public ActionResult create(MyCourse myst)
        {
            CommonMethod();
            Course a = new Course();
            a.courseid = myst.courseid;
            a.coursename = myst.coursename;
            a.studentid = myst.studentid;
            a.teacherid = myst.teacherid;
            if (ModelState.IsValid)
            {
                try
                {
                    db.Courses.Add(a);
                    db.SaveChanges();
                    TempData["msg"] = "Successfully inserted";

                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
                return RedirectToAction("Index");
            }
            return View("AddStudents");
        }

        [HttpParamAction]
        [HttpPost]
        public ActionResult edit(MyCourse myst)//Post-Button Click
        {
            CommonMethod();
            if (ModelState.IsValid)
            {
                try
                {
                    Course item = null;
                    item = (from c in db.Courses where c.courseid == myst.courseid select c).FirstOrDefault();
                    if (item == null)
                    {
                        ViewBag.error = $"Item with id {myst.courseid} was not found";
                    }
                    TryUpdateModel(item);
                    db.SaveChanges();

                    TempData["msg"] = $"Successfully Updated the record: {myst.courseid}";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
            }
            return View(myst);
        }

        [HttpParamAction]
        [HttpPost]
        public ActionResult delete(int id)
        {
            CommonMethod();
            Course student;
            student = (from st1 in db.Courses where st1.courseid == id select st1).FirstOrDefault();

            db.Courses.Attach(student);
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            TempData["msg"] = $"Succesfully deleted {id}";
            return RedirectToAction("Index");
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}