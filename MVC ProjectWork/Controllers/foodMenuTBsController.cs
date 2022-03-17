using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_ProjectWork.Models;

namespace MVC_ProjectWork.Controllers
{
    public class foodMenuTBsController : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();

        // GET: foodMenuTBs
        public ActionResult Index()
        {
            return View(db.foodMenuTBs.ToList());
        }

        // GET: foodMenuTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foodMenuTB foodMenuTB = db.foodMenuTBs.Find(id);
            if (foodMenuTB == null)
            {
                return HttpNotFound();
            }
            return View(foodMenuTB);
        }

        // GET: foodMenuTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: foodMenuTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Food,Items,Price")] foodMenuTB foodMenuTB)
        {
            if (ModelState.IsValid)
            {
                db.foodMenuTBs.Add(foodMenuTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodMenuTB);
        }

        // GET: foodMenuTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foodMenuTB foodMenuTB = db.foodMenuTBs.Find(id);
            if (foodMenuTB == null)
            {
                return HttpNotFound();
            }
            return View(foodMenuTB);
        }

        // POST: foodMenuTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Food,Items,Price")] foodMenuTB foodMenuTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodMenuTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodMenuTB);
        }

        // GET: foodMenuTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foodMenuTB foodMenuTB = db.foodMenuTBs.Find(id);
            if (foodMenuTB == null)
            {
                return HttpNotFound();
            }
            return View(foodMenuTB);
        }

        // POST: foodMenuTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foodMenuTB foodMenuTB = db.foodMenuTBs.Find(id);
            db.foodMenuTBs.Remove(foodMenuTB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
