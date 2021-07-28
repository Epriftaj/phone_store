using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJECT_FINAL.Models;

namespace PROJECT_FINAL.Controllers
{
    public class CategorytblsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categorytbls
        public ActionResult Index()
        {
            return View(db.Categorytbls.ToList());
        }

        // GET: Categorytbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorytbl categorytbl = db.Categorytbls.Find(id);
            if (categorytbl == null)
            {
                return HttpNotFound();
            }
            return View(categorytbl);
        }

        // GET: Categorytbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorytbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_Id,Category_Name")] Categorytbl categorytbl)
        {
            if (ModelState.IsValid)
            {
                db.Categorytbls.Add(categorytbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorytbl);
        }

        // GET: Categorytbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorytbl categorytbl = db.Categorytbls.Find(id);
            if (categorytbl == null)
            {
                return HttpNotFound();
            }
            return View(categorytbl);
        }

        // POST: Categorytbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_Id,Category_Name")] Categorytbl categorytbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorytbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorytbl);
        }

        // GET: Categorytbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorytbl categorytbl = db.Categorytbls.Find(id);
            if (categorytbl == null)
            {
                return HttpNotFound();
            }
            return View(categorytbl);
        }

        // POST: Categorytbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorytbl categorytbl = db.Categorytbls.Find(id);
            db.Categorytbls.Remove(categorytbl);
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
