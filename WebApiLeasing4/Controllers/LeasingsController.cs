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
using WebApiLeasing4;

namespace WebApiLeasing4.Controllers
{
    public class LeasingsController : ApiController
    {
        private LeasingDBContext db = new LeasingDBContext();

        // GET: api/Leasings
        public IQueryable<Leasing> GetLeasings()
        {
            return db.Leasings;
        }

        // GET: api/Leasings/5
        [ResponseType(typeof(Leasing))]
        public IHttpActionResult GetLeasing(int id)
        {
            Leasing leasing = db.Leasings.Find(id);
            if (leasing == null)
            {
                return NotFound();
            }

            return Ok(leasing);
        }

        // PUT: api/Leasings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeasing(int id, Leasing leasing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leasing.Leasing_id)
            {
                return BadRequest();
            }

            db.Entry(leasing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeasingExists(id))
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

        // POST: api/Leasings
        [ResponseType(typeof(Leasing))]
        public IHttpActionResult PostLeasing(Leasing leasing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leasings.Add(leasing);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LeasingExists(leasing.Leasing_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = leasing.Leasing_id }, leasing);
        }

        // DELETE: api/Leasings/5
        [ResponseType(typeof(Leasing))]
        public IHttpActionResult DeleteLeasing(int id)
        {
            Leasing leasing = db.Leasings.Find(id);
            if (leasing == null)
            {
                return NotFound();
            }

            db.Leasings.Remove(leasing);
            db.SaveChanges();

            return Ok(leasing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeasingExists(int id)
        {
            return db.Leasings.Count(e => e.Leasing_id == id) > 0;
        }
    }
}