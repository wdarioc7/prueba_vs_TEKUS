using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEKUS_V1_2018.Models;

namespace TEKUS_V1_2018.Controllers
{
    public class TBL_TEKUS_PAISController : Controller
    {
        private sisteman_TEKUSEntities db = new sisteman_TEKUSEntities();

        // GET: TBL_TEKUS_PAIS
        public ActionResult Index()
        {
            return View(db.TBL_TEKUS_PAIS.ToList());
        }

        // GET: TBL_TEKUS_PAIS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_PAIS tBL_TEKUS_PAIS = db.TBL_TEKUS_PAIS.Find(id);
            if (tBL_TEKUS_PAIS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_PAIS);
        }

        // GET: TBL_TEKUS_PAIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_TEKUS_PAIS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAIS,NOMBRE")] TBL_TEKUS_PAIS tBL_TEKUS_PAIS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_TEKUS_PAIS.Add(tBL_TEKUS_PAIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_TEKUS_PAIS);
        }

        // GET: TBL_TEKUS_PAIS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_PAIS tBL_TEKUS_PAIS = db.TBL_TEKUS_PAIS.Find(id);
            if (tBL_TEKUS_PAIS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_PAIS);
        }

        // POST: TBL_TEKUS_PAIS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAIS,NOMBRE")] TBL_TEKUS_PAIS tBL_TEKUS_PAIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_TEKUS_PAIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_TEKUS_PAIS);
        }

        // GET: TBL_TEKUS_PAIS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_PAIS tBL_TEKUS_PAIS = db.TBL_TEKUS_PAIS.Find(id);
            if (tBL_TEKUS_PAIS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_PAIS);
        }

        // POST: TBL_TEKUS_PAIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TBL_TEKUS_PAIS tBL_TEKUS_PAIS = db.TBL_TEKUS_PAIS.Find(id);
            db.TBL_TEKUS_PAIS.Remove(tBL_TEKUS_PAIS);
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
