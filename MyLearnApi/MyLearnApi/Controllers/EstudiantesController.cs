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
    public class EstudiantesController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        // GET: api/Estudiantes
        public IQueryable<ESTUDIANTE> GetESTUDIANTE()
        {
            return db.ESTUDIANTE;
        }

        // GET: api/Estudiantes/5
        [ResponseType(typeof(ESTUDIANTE))]
        public IHttpActionResult GetESTUDIANTE(string id)
        {
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return NotFound();
            }

            return Ok(eSTUDIANTE);
        }

     

        // POST: api/Estudiantes
        [ResponseType(typeof(VIEW_ESTUDIANTE))]
        public IHttpActionResult PostESTUDIANTE(VIEW_ESTUDIANTE estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sp_insert_estudiante(estudiante.Id,estudiante.Contrasena,estudiante.Sal,estudiante.RepositorioArchivos,estudiante.CredencialDrive,
                estudiante.NombreContacto,estudiante.ApellidoContacto,);
           // db.sp_insert_estudiante(eSTUDIANTE.Id, eSTUDIANTE.);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ESTUDIANTEExists(estudiante.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(estudiante);
        }

        // DELETE: api/Estudiantes/5
        [ResponseType(typeof(ESTUDIANTE))]
        public IHttpActionResult DeleteESTUDIANTE(string id)
        {
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return NotFound();
            }

            db.ESTUDIANTE.Remove(eSTUDIANTE);
            db.SaveChanges();

            return Ok(eSTUDIANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ESTUDIANTEExists(string id)
        {
            return db.ESTUDIANTE.Count(e => e.Id == id) > 0;
        }
    }
}