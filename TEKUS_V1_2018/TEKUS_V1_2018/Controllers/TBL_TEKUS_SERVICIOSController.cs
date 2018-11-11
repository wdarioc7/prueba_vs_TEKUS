using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEKUS_V1_2018.Models;
using PagedList;

namespace TEKUS_V1_2018.Controllers
{
    public class TBL_TEKUS_SERVICIOSController : Controller
    {
        private sisteman_TEKUSEntities db = new sisteman_TEKUSEntities();

        // GET: TBL_TEKUS_SERVICIOS
        //public ActionResult Index()
        //{
        //    @ViewBag.Servicios = db.TBL_TEKUS_SERVICIOS.Count();

        //    List<TBL_TEKUS_SERVICIOS> pais = db.TBL_TEKUS_SERVICIOS.ToList();
        //    //var PAIS = pais.Distinct().Count();
        //    //var paises = pais.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Count);

        //    //Cito a leandro tutiny blog http://ltuttini.blogspot.com/2010/03/buscar-en-una-lista-contenido-repetido.html 
        //    //PERMITE REALIZAR LA CONSULTA DE PAISES POR SERVICIO Y CALCULAR EL NUMERO DE EXISTENCIAS POR PALABRA -- BIG DATA
        //    var paises = from item in pais
        //                 let extension = item.ID_PAIS
        //                 group item by extension into g
        //                 select new { Key = g.Key, Values = g.Count() };



        //    ViewBag.paises = paises.ToList();
           


        //    var tBL_TEKUS_SERVICIOS = db.TBL_TEKUS_SERVICIOS.Include(t => t.TBL_TEKUS_CLIENTES).Include(t => t.TBL_TEKUS_PAIS);
        //    return View(tBL_TEKUS_SERVICIOS.ToList());
        //}
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            @ViewBag.Servicios = db.TBL_TEKUS_SERVICIOS.Count();

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
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName desc" : "";
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
            var products = db.TBL_TEKUS_SERVICIOS.Include(t => t.TBL_TEKUS_CLIENTES).Include(t => t.TBL_TEKUS_PAIS);

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.NOMBRE.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ProductName desc":
                    products = products.OrderByDescending(s => s.NOMBRE);
                    break;
                case "UnitPrice":
                    products = products.OrderBy(s => s.ID_CLIENTE);
                    break;
                case "UnitPrice desc":
                    products = products.OrderByDescending(s => s.ID_SERVICIOS);
                    break;
                default:
                    products = products.OrderBy(s => s.NOMBRE);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            
            return View(products.ToPagedList(pageNumber, pageSize));
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
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE");
            return View();
        }

        // POST: TBL_TEKUS_SERVICIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SERVICIOS,NOMBRE,VPORHORA,ID_CLIENTE,ID_PAIS")] TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_TEKUS_SERVICIOS.Add(tBL_TEKUS_SERVICIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.TBL_TEKUS_CLIENTES, "ID_CLIENTES", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_CLIENTE);
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_PAIS);
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
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_PAIS);
            return View(tBL_TEKUS_SERVICIOS);
        }

        // POST: TBL_TEKUS_SERVICIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SERVICIOS,NOMBRE,VPORHORA,ID_CLIENTE,ID_PAIS")] TBL_TEKUS_SERVICIOS tBL_TEKUS_SERVICIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_TEKUS_SERVICIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.TBL_TEKUS_CLIENTES, "ID_CLIENTES", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_CLIENTE);
            ViewBag.ID_PAIS = new SelectList(db.TBL_TEKUS_PAIS, "ID_PAIS", "NOMBRE", tBL_TEKUS_SERVICIOS.ID_PAIS);
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
