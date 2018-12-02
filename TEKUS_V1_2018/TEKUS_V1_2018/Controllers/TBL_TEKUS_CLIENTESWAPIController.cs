using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TEKUS_V1_2018.Models;

namespace TEKUS_V1_2018.Controllers
{
    public class TBL_TEKUS_CLIENTESWAPIController : ApiController
    {
        private sisteman_TEKUSEntities db = new sisteman_TEKUSEntities();

        // GET: api/TBL_TEKUS_CLIENTESWAPI
        public IQueryable<TBL_TEKUS_CLIENTES> GetTBL_TEKUS_CLIENTES()
        {
            return db.TBL_TEKUS_CLIENTES;
        }

        // GET: api/TBL_TEKUS_CLIENTESWAPI/5
        [ResponseType(typeof(TBL_TEKUS_CLIENTES))]
        public IHttpActionResult GetTBL_TEKUS_CLIENTES(decimal id)
        {
            TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Find(id);
            if (tBL_TEKUS_CLIENTES == null)
            {
                return NotFound();
            }

            return Ok(tBL_TEKUS_CLIENTES);
        }

        // PUT: api/TBL_TEKUS_CLIENTESWAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBL_TEKUS_CLIENTES(decimal id, TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBL_TEKUS_CLIENTES.ID_CLIENTES)
            {
                return BadRequest();
            }

            db.Entry(tBL_TEKUS_CLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBL_TEKUS_CLIENTESExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TBL_TEKUS_CLIENTESWAPI
        [ResponseType(typeof(TBL_TEKUS_CLIENTES))]
        public IHttpActionResult PostTBL_TEKUS_CLIENTES(TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBL_TEKUS_CLIENTES.Add(tBL_TEKUS_CLIENTES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tBL_TEKUS_CLIENTES.ID_CLIENTES }, tBL_TEKUS_CLIENTES);
        }

        // DELETE: api/TBL_TEKUS_CLIENTESWAPI/5
        [ResponseType(typeof(TBL_TEKUS_CLIENTES))]
        public IHttpActionResult DeleteTBL_TEKUS_CLIENTES(decimal id)
        {
            TBL_TEKUS_CLIENTES tBL_TEKUS_CLIENTES = db.TBL_TEKUS_CLIENTES.Find(id);
            if (tBL_TEKUS_CLIENTES == null)
            {
                return NotFound();
            }

            db.TBL_TEKUS_CLIENTES.Remove(tBL_TEKUS_CLIENTES);
            db.SaveChanges();

            return Ok(tBL_TEKUS_CLIENTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBL_TEKUS_CLIENTESExists(decimal id)
        {
            return db.TBL_TEKUS_CLIENTES.Count(e => e.ID_CLIENTES == id) > 0;
        }
    }
}