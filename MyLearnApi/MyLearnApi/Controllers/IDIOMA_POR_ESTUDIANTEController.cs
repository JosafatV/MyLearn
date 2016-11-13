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
using MyLearnApi.Models;

namespace MyLearnApi.Controllers
{
    public class IDIOMA_POR_ESTUDIANTEController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        // GET: api/IDIOMA_POR_ESTUDIANTE
        public IQueryable<IDIOMA_POR_ESTUDIANTE> GetIDIOMA_POR_ESTUDIANTE()
        {
            return db.IDIOMA_POR_ESTUDIANTE;
        }

        // GET: api/IDIOMA_POR_ESTUDIANTE/5
        [ResponseType(typeof(IDIOMA_POR_ESTUDIANTE))]
        public IHttpActionResult GetIDIOMA_POR_ESTUDIANTE(string id)
        {
            IDIOMA_POR_ESTUDIANTE iDIOMA_POR_ESTUDIANTE = db.IDIOMA_POR_ESTUDIANTE.Find(id);
            if (iDIOMA_POR_ESTUDIANTE == null)
            {
                return NotFound();
            }

            return Ok(iDIOMA_POR_ESTUDIANTE);
        }

        // PUT: api/IDIOMA_POR_ESTUDIANTE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIDIOMA_POR_ESTUDIANTE(string id, IDIOMA_POR_ESTUDIANTE iDIOMA_POR_ESTUDIANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iDIOMA_POR_ESTUDIANTE.IdEstudiante)
            {
                return BadRequest();
            }

            db.Entry(iDIOMA_POR_ESTUDIANTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IDIOMA_POR_ESTUDIANTEExists(id))
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

        // POST: api/IDIOMA_POR_ESTUDIANTE
        [ResponseType(typeof(IDIOMA_POR_ESTUDIANTE))]
        public IHttpActionResult PostIDIOMA_POR_ESTUDIANTE(IDIOMA_POR_ESTUDIANTE iDIOMA_POR_ESTUDIANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IDIOMA_POR_ESTUDIANTE.Add(iDIOMA_POR_ESTUDIANTE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IDIOMA_POR_ESTUDIANTEExists(iDIOMA_POR_ESTUDIANTE.IdEstudiante))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = iDIOMA_POR_ESTUDIANTE.IdEstudiante }, iDIOMA_POR_ESTUDIANTE);
        }

        // DELETE: api/IDIOMA_POR_ESTUDIANTE/5
        [ResponseType(typeof(IDIOMA_POR_ESTUDIANTE))]
        public IHttpActionResult DeleteIDIOMA_POR_ESTUDIANTE(string id)
        {
            IDIOMA_POR_ESTUDIANTE iDIOMA_POR_ESTUDIANTE = db.IDIOMA_POR_ESTUDIANTE.Find(id);
            if (iDIOMA_POR_ESTUDIANTE == null)
            {
                return NotFound();
            }

            db.IDIOMA_POR_ESTUDIANTE.Remove(iDIOMA_POR_ESTUDIANTE);
            db.SaveChanges();

            return Ok(iDIOMA_POR_ESTUDIANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IDIOMA_POR_ESTUDIANTEExists(string id)
        {
            return db.IDIOMA_POR_ESTUDIANTE.Count(e => e.IdEstudiante == id) > 0;
        }
    }
}