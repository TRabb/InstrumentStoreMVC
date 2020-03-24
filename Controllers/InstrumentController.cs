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
using PagedList;

namespace InstrumentStoreMVC.Controllers
{
    public class InstrumentController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Instrument
        [AllowAnonymous]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var instruments = from i in db.Instruments
                           select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                instruments = instruments.Where(i => i.InstrumentName.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    instruments = instruments.OrderByDescending(i => i.InstrumentName);
                    break;
                case "Price":
                    instruments = instruments.OrderBy(i => i.Price);
                    break;
                case "price_desc":
                    instruments = instruments.OrderByDescending(i => i.Price);
                    break;
                default:
                    instruments = instruments.OrderBy(i => i.InstrumentName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(instruments.ToPagedList(pageNumber, pageSize));
        }

        // GET: Instrument/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // GET: Instrument/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instrument/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,InstrumentName,Price")] Instrument instrument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Instruments.Add(instrument);
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


            return View(instrument);
        }

        // GET: Instrument/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instrument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,InstrumentName,Price")] Instrument instrument)
        {
            try
            {
            if (ModelState.IsValid)
            {
                db.Entry(instrument).State = EntityState.Modified;
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

            return View(instrument);
        }

        // GET: Instrument/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists please contanct your system administrator.";
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instrument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            Instrument instrument = db.Instruments.Find(id);
            db.Instruments.Remove(instrument);
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
