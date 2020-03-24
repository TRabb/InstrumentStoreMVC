using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstrumentStoreMVC.DAL;
using InstrumentStoreMVC.Models;

namespace InstrumentStoreMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: OrderDetail
        [Authorize]
        public ActionResult Index()
        {
            return View(db.OrderDetails.ToList());
        }

        // GET: OrderDetail/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetail/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderID,StoreID,InstrumentID")] OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists please see your system administrator");
                throw;
            }


            return View(orderDetail);
        }

        // GET: OrderDetail/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderID,StoreID,InstrumentID")] OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(orderDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists please see your system administrator");
                throw;
            }

            return View(orderDetail);
        }

        // GET: OrderDetail/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists please contanct your system administrator.";
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                OrderDetail orderDetail = db.OrderDetails.Find(id);
                db.OrderDetails.Remove(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists please see your system administrator");
                throw;
            }

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
