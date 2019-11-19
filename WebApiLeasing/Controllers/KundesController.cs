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
using WebApiLeasing;

namespace WebApiLeasing.Controllers
{
    public class KundesController : ApiController
    {
        private LeasingDBcontext db = new LeasingDBcontext();

        // GET: api/Kundes
        public IQueryable<Kunde> GetKunde()
        {
            return db.Kunde;
        }

        // GET: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult GetKunde(int id)
        {
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            return Ok(kunde);
        }

        // PUT: api/Kundes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKunde(int id, Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kunde.Kunde_id)
            {
                return BadRequest();
            }

            db.Entry(kunde).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
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

        // POST: api/Kundes
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult PostKunde(Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kunde.Add(kunde);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KundeExists(kunde.Kunde_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kunde.Kunde_id }, kunde);
        }

        // DELETE: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult DeleteKunde(int id)
        {
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            db.Kunde.Remove(kunde);
            db.SaveChanges();

            return Ok(kunde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KundeExists(int id)
        {
            return db.Kunde.Count(e => e.Kunde_id == id) > 0;
        }
    }
}