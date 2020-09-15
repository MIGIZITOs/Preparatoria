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
using Preparatoria.Models;

namespace Preparatoria.Controllers
{
    public class TapiasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Tapias
        [Authorize]
        public IQueryable<Tapia> GetTapias()
        {
            return db.Tapias;
        }

        // GET: api/Tapias/5
        [Authorize]
        [ResponseType(typeof(Tapia))]
        public IHttpActionResult GetTapia(int id)
        {
            Tapia tapia = db.Tapias.Find(id);
            if (tapia == null)
            {
                return NotFound();
            }

            return Ok(tapia);
        }

        // PUT: api/Tapias/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTapia(int id, Tapia tapia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tapia.TapiaID)
            {
                return BadRequest();
            }

            db.Entry(tapia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TapiaExists(id))
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

        // POST: api/Tapias
        [Authorize]
        [ResponseType(typeof(Tapia))]
        public IHttpActionResult PostTapia(Tapia tapia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tapias.Add(tapia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tapia.TapiaID }, tapia);
        }

        // DELETE: api/Tapias/5
        [Authorize]
        [ResponseType(typeof(Tapia))]
        public IHttpActionResult DeleteTapia(int id)
        {
            Tapia tapia = db.Tapias.Find(id);
            if (tapia == null)
            {
                return NotFound();
            }

            db.Tapias.Remove(tapia);
            db.SaveChanges();

            return Ok(tapia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TapiaExists(int id)
        {
            return db.Tapias.Count(e => e.TapiaID == id) > 0;
        }
    }
}