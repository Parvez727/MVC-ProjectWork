using MVC_ProjectWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class SalesController : Controller
    {
        private ISaleRepository _saleRepository;
        public SalesController()
        {
            _saleRepository = new SaleRepository();
        }
        public ActionResult Index()
        {
            var sales = _saleRepository.GetSales();
            return View(sales);
        }
        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            sale sale = _saleRepository.GetOneSale(id);
            return View(sale);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Bookid,Quantity,SaleDate")] sale sale)
        {
            if (ModelState.IsValid)
            {
                _saleRepository.Create(sale);
                return RedirectToAction("Index");
            }
            return View(sale);
        }
        public ActionResult Edit(int? id)
        {
            sale sale = _saleRepository.GetOneSale(id);
            return View(sale);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,BookID,Quantity,SaleDate")] sale sale)
        {
            _saleRepository.Update(sale);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale sale = _saleRepository.GetOneSale(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _saleRepository.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}