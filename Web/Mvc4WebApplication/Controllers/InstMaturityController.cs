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
    public class InstMaturityController : Controller
    {
        private DubaiDbContext db = new DubaiDbContext();

        //
        // GET: /InstMaturity/

        public ActionResult Index()
        {
            return View(db.Maturities.ToList());
        }

        //
        // GET: /InstMaturity/Details/5

        public ActionResult Details(string id = null)
        {
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            if (instrumentmaturity == null)
            {
                return HttpNotFound();
            }
            return View(instrumentmaturity);
        }

        //
        // GET: /InstMaturity/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InstMaturity/Create

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
        // GET: /InstMaturity/Edit/5

        public ActionResult Edit(string name, DateTime maturity)
        {
            //InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(new object[] { name, maturity });
            if (instrumentmaturity == null)
            {
                return HttpNotFound();
            }
            return View(instrumentmaturity);
        }

        //
        // POST: /InstMaturity/Edit/5

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
        // GET: /InstMaturity/Delete/5

        public ActionResult Delete(string id = null)
        {
            InstrumentMaturity instrumentmaturity = db.Maturities.Find(id);
            if (instrumentmaturity == null)
            {
                return HttpNotFound();
            }
            return View(instrumentmaturity);
        }

        //
        // POST: /InstMaturity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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