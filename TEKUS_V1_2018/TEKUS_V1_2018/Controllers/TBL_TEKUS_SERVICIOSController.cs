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
    public class TBL_TEKUS_SERVICIOSController : Controller
    {
        private sisteman_TEKUSEntities db = new sisteman_TEKUSEntities();

        // GET: TBL_TEKUS_SERVICIOS
        public ActionResult Index()
        {
            var tBL_TEKUS_SERVICIOS = db.TBL_TEKUS_SERVICIOS.Include(t => t.TBL_TEKUS_CLIENTES);
            return View(tBL_TEKUS_SERVICIOS.ToList());
        }

        // GET: TBL_TEKUS_SERVICIOS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS = db.TBL_TEKUS_SERVICIOS.Find(id);
            if (tBL_TEKUS_SERVICIOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_SERVICIOS);
        }

        // GET: TBL_TEKUS_SERVICIOS/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.TBL_TEKUS_CLIENTES, "ID_CLIENTES", "NOMBRE");
            return View();
        }

        // POST: TBL_TEKUS_SERVICIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SERVICIOS,NOMBRE,VPORHORA,ID_CLIENTE")] TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_TEKUS_SERVICIOS.Add(tBL_TEKUS_SERVICIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.TBL_TEKUS_CLIENTES, "ID_CLIENTES", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_CLIENTE);
            return View(tBL_TEKUS_SERVICIOS);
        }

        // GET: TBL_TEKUS_SERVICIOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS = db.TBL_TEKUS_SERVICIOS.Find(id);
            if (tBL_TEKUS_SERVICIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.TBL_TEKUS_CLIENTES, "ID_CLIENTES", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_CLIENTE);
            return View(tBL_TEKUS_SERVICIOS);
        }

        // POST: TBL_TEKUS_SERVICIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SERVICIOS,NOMBRE,VPORHORA,ID_CLIENTE")] TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_TEKUS_SERVICIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.TBL_TEKUS_CLIENTES, "ID_CLIENTES", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_CLIENTE);
            return View(tBL_TEKUS_SERVICIOS);
        }

        // GET: TBL_TEKUS_SERVICIOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS = db.TBL_TEKUS_SERVICIOS.Find(id);
            if (tBL_TEKUS_SERVICIOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_SERVICIOS);
        }

        // POST: TBL_TEKUS_SERVICIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS = db.TBL_TEKUS_SERVICIOS.Find(id);
            db.TBL_TEKUS_SERVICIOS.Remove(tBL_TEKUS_SERVICIOS);
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
