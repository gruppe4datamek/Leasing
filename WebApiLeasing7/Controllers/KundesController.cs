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
using WebApiLeasing7;

namespace WebApiLeasing7.Controllers
{
    public class KundesController : ApiController
    {
        private LeasingDBContext db = new LeasingDBContext();

        // GET: api/Kundes
        public IQueryable<Kunde> GetKundes()
        {
            return db.Kundes;
        }

        // GET: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult GetKunde(int id)
        {
            Kunde kunde = db.Kundes.Find(id);
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

            db.Kundes.Add(kunde);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kunde.Kunde_id }, kunde);
        }

        // DELETE: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult DeleteKunde(int id)
        {
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            db.Kundes.Remove(kunde);
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
            return db.Kundes.Count(e => e.Kunde_id == id) > 0;
        }
    }
}