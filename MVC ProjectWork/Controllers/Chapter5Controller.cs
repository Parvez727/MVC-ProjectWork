using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class Chapter5Controller : Controller
    {
        // GET: Chapter5
        private MVC_ProjectEntities db = new MVC_ProjectEntities();
        List<Mystudent2> a = new List<Mystudent2>();
        public void CommonMethod()
        {
            foreach (var d in db.student2.ToList())
            {
                a.Add(new Mystudent2() { id = d.id, name = d.name, fee = d.fee, @class = d.@class, picturepath = d.picturepath });
            }
            ViewBag.records = a;
        }

        public ActionResult Index(int id=0)
        {
            ViewBag.msg = TempData["msg"];
            CommonMethod();
            if (id == 0)
            {
                return View();
            }
            else
            {
                var item = (from c in db.student2 where c.id == id select c).Distinct().FirstOrDefault();
                if (item != null)//if the item exists
                {
                    Mystudent2 b = new Mystudent2() { id = item.id, name = item.name, @class = item.@class, fee = item.fee, picturepath = item.picturepath };
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
        public ActionResult create(Mystudent2 myst)
        {
            CommonMethod();

            string FileName = Path.GetFileName(myst.ImageFile.FileName);
            string FilePath = Path.Combine(Server.MapPath("~/Uploads"), FileName);


            student2 a = new student2();
            a.id = myst.id;
            a.name = myst.name;
            a.@class = myst.@class;
            a.fee = myst.fee;
            a.picturepath = FileName;
            if (ModelState.IsValid)
            {
                try
                {
                    myst.ImageFile.SaveAs(FilePath);
                    db.student2.Add(a);
                    db.SaveChanges();
                    TempData["msg"] = $"Successfully Inserted the record: {myst.id}";

                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message.ToString();

                }
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpParamAction]
        [HttpPost]
        public ActionResult edit(Mystudent2 myst)//Post-Button Click
        {
            CommonMethod();
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

        [HttpParamAction]
        [HttpPost]
        public ActionResult delete(int id)
        {
            CommonMethod();
            student2 student;
            student = (from st1 in db.student2 where st1.id == id select st1).FirstOrDefault();

            db.student2.Attach(student);
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            TempData["msg"] = $"Succesfully deleted {id}";
            return RedirectToAction("Index");
        }
    }

}
