using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class Product_SalesController : Controller
    {
        // GET: Product_Sales
        private MVC_ProjectEntities2 db = new MVC_ProjectEntities2();
        public ActionResult Index()
        {
            List<Product_Sales> esg = new List<Product_Sales>();
            Product_Sales sg = new Product_Sales();
            IEnumerable<Product> a = db.Products.ToList();
            foreach (Product a1 in a)
            {

                List<Sale> b = (from it in db.Sales where it.product_id == a1.product_id select it).ToList();

                foreach (Sale a2 in b)
                {
                sg = new Product_Sales() { product_id = a1.product_id, product_name = a1.product_name, purchase_price = (int)a1.purchase_price, 
                    sale_id = a2.sale_id, Qty = a2.Qty, sales_price = a2.sales_price, Total_price = a2.Total_price };
                esg.Add(sg);
                }
            }

            return View(esg);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale st = db.Sales.Find(id);
            if (st == null)
            {
                return HttpNotFound();
            }
            Product gd = st.Product;

            Product_Sales stg = new Product_Sales() 
            { product_id = gd.product_id, product_name = gd.product_name, purchase_price = (int)gd.purchase_price,
                sale_id = st.sale_id, Qty = st.Qty, sales_price = st.sales_price, Total_price = st.Total_price };

            return View(stg);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product_Sales stu_Guard)
        {

            Product a = new Product();
            a.product_id = stu_Guard.product_id;
            a.product_name = stu_Guard.product_name;
            a.purchase_price = stu_Guard.purchase_price;
            Sale a1 = new Sale();
            a1.sale_id = stu_Guard.sale_id;
            a1.product_id = stu_Guard.product_id;
            a1.Qty = stu_Guard.Qty;
            a1.sales_price = stu_Guard.sales_price;
            a1.Total_price = (decimal)stu_Guard.Total_price;
            Product d2 = db.Products.Find(stu_Guard.product_id);
            if (d2 == null)
            {
                db.Products.Add(a);
            }
            if (stu_Guard.sale_id.ToString() != "")
            {
                db.Sales.Add(a1);
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Sales sg = new Product_Sales();
            Sale a1 = db.Sales.Find( id);
            if (a1 != null)
            {
                Product b = db.Products.Find(a1.product_id);
                sg = new Product_Sales() { product_id = b.product_id, product_name = b.product_name, purchase_price = (int)b.purchase_price, 
                    sale_id = a1.sale_id, Qty = a1.Qty, sales_price = a1.sales_price, Total_price = a1.Total_price };
            }
            return View(sg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product_Sales stu_Guard)
        {
            if (ModelState.IsValid)
            {
                Product st5 = db.Products.Find(stu_Guard.product_id);
                st5.product_name = stu_Guard.product_name;
                st5.purchase_price = stu_Guard.purchase_price;
                Sale gd5 = db.Sales.Find(stu_Guard.sale_id);
                gd5.Qty = stu_Guard.Qty;
                gd5.sales_price = stu_Guard.sales_price;
                gd5.Total_price = (decimal)stu_Guard.Total_price;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_Guard);
        }


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Sales sg = new Product_Sales();
            Sale a1 = db.Sales.Find(id);
            if (a1 != null)
            {
                Product b = db.Products.Find(a1.product_id);
                sg = new Product_Sales() {
                    product_id = b.product_id,
                    product_name = b.product_name,
                    purchase_price = b.purchase_price,
                    sale_id = a1.sale_id,
                    Qty =a1.Qty,
                    sales_price = a1.sales_price,
                    Total_price = a1.Total_price
                };
            }
            return View(sg);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sale st5 = db.Sales.Find(id);
            var a = (from i in db.Sales where i.sale_id == id select new {i.product_id}).FirstOrDefault();
            Product st6 = db.Products.Find(a.product_id);
            var fk = (from d in db.Sales where d.product_id == a.product_id select d).ToList();
            if (fk.Count <= 1)
            {
                db.Products.Remove(st6);
            }
            db.Sales.Remove(st5);

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
        public JsonResult GetDept(string id)
        {
            var a = (from d in db.Products where d.product_id == id select new { d.product_id, d.product_name, d.purchase_price });
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }





}
