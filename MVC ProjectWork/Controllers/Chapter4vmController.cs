using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class Chapter4vmController : Controller
    {
        private MVC_ProjectEntities db = new MVC_ProjectEntities();
        List<Mystudent2> a = new List<Mystudent2>();
        // GET: Chapter4vm
        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"];
            foreach (var d in db.student2.ToList())
            {
                a.Add(new Mystudent2() { id = d.id, name = d.name, fee = d.fee, @class = d.@class });
            }
            return View(a);

        }


        public ActionResult EditStudents(int id)//select-Edit
        {
            Mystudent2 st1 = new Mystudent2();
            var st = db.student2.Find(id);//linq code
                                          //from model1(edmx) to viewmodel
            st1.id = st.id;
            st1.name = st.name;
            st1.@class = st.@class;
            st1.fee = st.fee;
            return View(st1);//st1 is a viewmodel that is passed from controller to the view
        }


        [HttpPost]
        public ActionResult EditStudents(Mystudent2 myst)//Post-Button Click
        {
            if (ModelState.IsValid)
            {
                try
                {
                    student2 item = null;
                    item = (from c in db.student2 where c.id == myst.id select c).FirstOrDefault();
                    if (item == null)
                    {
                        ViewBag.error = $"Item with id {myst.id} was not found";
                    }
                    TryUpdateModel(item);
                    db.SaveChanges();
                    TempData["msg"] = $"Successfully Updated the record: {myst.id}";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
            }
            return View(myst);
        }



        public ActionResult AddStudents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudents1(Mystudent2 myst)
        {
            student2 a = new student2();
            a.id = myst.id;
            a.name = myst.name;
            a.@class = myst.@class;
            a.fee = myst.fee;
            if (ModelState.IsValid)
            {

           
                try
                {
                    db.student2.Add(a);
                    db.SaveChanges();
                    TempData["msg"] = "Successfully Inserted";
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
                return RedirectToAction("Index");
            }
            return View("AddStudents", myst);
        }



        [HttpPost]
        public ActionResult Delete1(int id)
        {
            student2 student;
            student = (from st1 in db.student2 where st1.id == id select st1).FirstOrDefault();

            db.student2.Attach(student);
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            TempData["msg"] = $"Successfully deleted {id}";
            return RedirectToAction("Index");
        }



        public ActionResult ShowName()
        {
            List<student2> item = null;
            item = (from c in db.student2 select c).ToList();
            ViewBag.DDLProducts = new SelectList(item, "id", "name");//a dropdownlist will be created with value: id and display: name
            return View();
        }
        [HttpPost]
        public ActionResult ShowName(Mystudent2 st)
        {
            List<student2> item = null;
            item = (from c in db.student2 select c).ToList();
            ViewBag.DDLProducts = new SelectList(item, "id", "name");
            ViewBag.StId = st.id;
            return View(st);
        }


        public ActionResult ShowClassName()
        {
            //List<student> item = null;
            var item = (from c in db.student2 select new { @class = c.@class }).Distinct().ToList();
            ViewBag.DDLProducts = new SelectList(item, "class", "class");
            return View();
        }
        [HttpPost]
        public ActionResult ShowClassName(Mystudent2 st)
        {
            var item = (from c in db.student2 select new { @class = c.@class }).Distinct().ToList();
            ViewBag.DDLProducts = new SelectList(item, "class", "class");
            ViewBag.StId = st.@class;
            List<student2> lst = (from c in db.student2 where c.@class == st.@class select c).ToList();
            ViewBag.allstudents = lst;
            return View(st);
        }


    }
}