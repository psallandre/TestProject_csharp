using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4WebApplication.Models;
using Mvc4WebApplication.Repository;

namespace Mvc4WebApplication.Controllers
{
    public class InstMaturityFrController : Controller
    {
        private DubaiDbContext db = new DubaiDbContext();

        //
        // GET: /InstMaturityFr/

        public ActionResult Index()
        {
            return View(db.Maturities.ToList());
        }

        //
        // GET: /InstMaturityFr/Details/5

        public ActionResult Details(int id = 0)
        {
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            if (instrumentmaturity == null)
            {
                return HttpNotFound();
            }
            return View(instrumentmaturity);
        }

        //
        // GET: /InstMaturityFr/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InstMaturityFr/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstrumentMaturity instrumentmaturity)
        {
            if (ModelState.IsValid)
            {
                db.Maturities.Add(instrumentmaturity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrumentmaturity);
        }

        //
        // GET: /InstMaturityFr/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            if (instrumentmaturity == null)
            {
                return HttpNotFound();
            }
            return View(instrumentmaturity);
        }

        //
        // POST: /InstMaturityFr/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstrumentMaturity instrumentmaturity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrumentmaturity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrumentmaturity);
        }

        //
        // GET: /InstMaturityFr/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            if (instrumentmaturity == null)
            {
                return HttpNotFound();
            }
            return View(instrumentmaturity);
        }

        //
        // POST: /InstMaturityFr/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            db.Maturities.Remove(instrumentmaturity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}