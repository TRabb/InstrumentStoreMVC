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
    public class StoreDetailController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: StoreDetail
        public ActionResult Index()
        {
            return View(db.StoreDetails.ToList());
        }

        // GET: StoreDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreDetail storeDetail = db.StoreDetails.Find(id);
            if (storeDetail == null)
            {
                return HttpNotFound();
            }
            return View(storeDetail);
        }

        // GET: StoreDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,State,City,Zip")] StoreDetail storeDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StoreDetails.Add(storeDetail);
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


            return View(storeDetail);
        }

        // GET: StoreDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreDetail storeDetail = db.StoreDetails.Find(id);
            if (storeDetail == null)
            {
                return HttpNotFound();
            }
            return View(storeDetail);
        }

        // POST: StoreDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,State,City,Zip")] StoreDetail storeDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(storeDetail).State = EntityState.Modified;
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

            return View(storeDetail);
        }

        // GET: StoreDetail/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreDetail storeDetail = db.StoreDetails.Find(id);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists please contanct your system administrator.";
            }
            if (storeDetail == null)
            {
                return HttpNotFound();
            }
            return View(storeDetail);
        }

        // POST: StoreDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                StoreDetail storeDetail = db.StoreDetails.Find(id);
                db.StoreDetails.Remove(storeDetail);
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
        }\
    }
}
