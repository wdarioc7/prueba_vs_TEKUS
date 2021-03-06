﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEKUS_V1_2018.Models;
using PagedList;
using Newtonsoft.Json;

namespace TEKUS_V1_2018.Controllers
{
    public class TBL_TEKUS_CLIENTESController : Controller
    {
        private sisteman_TEKUSEntities db = new sisteman_TEKUSEntities();

        // GET: TBL_TEKUS_CLIENTES
       public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            var tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Include(t => t.TBL_TEKUS_PAIS);
            @ViewBag.TotalClientes = db.TBL_TEKUS_CLIENTES.Count();

            List<TBL_TEKUS_SERVICIOS> pais = db.TBL_TEKUS_SERVICIOS.ToList();
            //var PAIS = pais.Distinct().Count();
            //var paises = pais.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Count);

            //Cito a leandro tutiny blog http://ltuttini.blogspot.com/2010/03/buscar-en-una-lista-contenido-repetido.html 
            //PERMITE REALIZAR LA CONSULTA DE PAISES POR SERVICIO Y CALCULAR EL NUMERO DE EXISTENCIAS POR PALABRA -- BIG DATA
            var paises = from item in pais
                         let extension = item.ID_PAIS
                         group item by extension into g
                         select new { Key = g.Key, Values = g.Count() };



            ViewBag.paises = paises.ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Nit = String.IsNullOrEmpty(sortOrder) ? "Nit" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName desc" : "";
            ViewBag.Correo = String.IsNullOrEmpty(sortOrder) ? "Correo" : "";
            ViewBag.UnitPriceSortParm = sortOrder == "UnitPrice" ? "UnitPrice desc" : "UnitPrice";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var products = db.TBL_TEKUS_CLIENTES.Include(t => t.TBL_TEKUS_PAIS);

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.NOMBRE.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Nit":
                    products = products.OrderByDescending(s => s.NIT);
                    break;
                case "NameSortParm":
                    products = products.OrderByDescending(s => s.NOMBRE);
                    break;
                case "Correo":
                    products = products.OrderByDescending(s => s.CORREOE);
                    break;
                //case "UnitPrice desc":
                //    products = products.OrderByDescending(s => s.ID_SERVICIOS);
                //    break;
                default:
                    products = products.OrderBy(s => s.NOMBRE);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }
        //get Angular js
        public JsonResult Get_AllClientes()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<TBL_TEKUS_CLIENTES> Emp = db.TBL_TEKUS_CLIENTES.ToList();
                return this.Json(Emp, JsonRequestBehavior.AllowGet);
           
        }
        public ActionResult Get_AllClientes1()
        {

            List<TBL_TEKUS_CLIENTES> Emp = db.TBL_TEKUS_CLIENTES.ToList();
            return View(Emp);

        }

        // GET: TBL_TEKUS_CLIENTES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Find(id);
            if (tBL_TEKUS_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_CLIENTES);
        }

        // GET: TBL_TEKUS_CLIENTES/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE");
            return View();
        }

        // POST: TBL_TEKUS_CLIENTES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLIENTES,NIT,NOMBRE,CORREOE,ID_PAIS")] TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.TBL_TEKUS_CLIENTES.Add(tBL_TEKUS_CLIENTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE", tBL_TEKUS_CLIENTES.ID_PAIS);
            return View(tBL_TEKUS_CLIENTES);
        }

        // GET: TBL_TEKUS_CLIENTES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Find(id);
            if (tBL_TEKUS_CLIENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE", tBL_TEKUS_CLIENTES.ID_PAIS);
            return View(tBL_TEKUS_CLIENTES);
        }

        // POST: TBL_TEKUS_CLIENTES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLIENTES,NIT,NOMBRE,CORREOE,ID_PAIS")] TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_TEKUS_CLIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE", tBL_TEKUS_CLIENTES.ID_PAIS);
            return View(tBL_TEKUS_CLIENTES);
        }

        // GET: TBL_TEKUS_CLIENTES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Find(id);
            if (tBL_TEKUS_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TEKUS_CLIENTES);
        }

        // POST: TBL_TEKUS_CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Find(id);
            db.TBL_TEKUS_CLIENTES.Remove(tBL_TEKUS_CLIENTES);
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
