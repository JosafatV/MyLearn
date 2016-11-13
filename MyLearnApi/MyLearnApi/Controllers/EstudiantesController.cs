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
    [AllowAnonymous]
    public class EstudiantesController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        [HttpGet]
        [Route("MyLearnApi/Estudiantes")]
        public IQueryable<VIEW_ESTUDIANTE> GetESTUDIANTE()
        {
            return db.VIEW_ESTUDIANTE.Where(est => est.Estado != "E"); ;
        }

        [HttpGet]
        [Route("MyLearnApi/Estudiantes/{id}")]
        [ResponseType(typeof(VIEW_ESTUDIANTE))]
        public IHttpActionResult GetESTUDIANTE(string id)
        {
            VIEW_ESTUDIANTE eSTUDIANTE = db.VIEW_ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null || eSTUDIANTE.Estado == "E") //si está eliminado
            {
                return NotFound();
            }

            return Ok(eSTUDIANTE);
        }


        [HttpPost]
        [Route("MyLearnApi/Estudiantes")]
        [ResponseType(typeof(VIEW_ESTUDIANTE))]
        public IHttpActionResult PostESTUDIANTE(VIEW_ESTUDIANTE estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sp_insert_estudiante(estudiante.Id,estudiante.Contrasena,estudiante.Sal,estudiante.RepositorioArchivos,estudiante.CredencialDrive,
                estudiante.NombreContacto,estudiante.ApellidoContacto,estudiante.Carne,estudiante.Email,estudiante.Telefono,estudiante.Pais,estudiante.Region,
                estudiante.FechaInscripcion, estudiante.RepositorioCodigo,estudiante.LinkHojaDeVida);
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

        [HttpDelete]
        [Route("MyLearnApi/Estudiantes/{id}")]
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteEstudiante(int id)
        {
            USUARIO estudiante = db.USUARIO.Find(id);

            if (estudiante == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            estudiante.Estado = "E" ; //se pone E de eliminado
            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                 throw;        
            }

            return Ok(estudiante);
        }

        [HttpOptions]
        [Route("MyLearnApi/Estudiantes")]
        [Route("MyLearnApi/Estudiantes/{id}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
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
            return db.VIEW_ESTUDIANTE.Count(e => e.Id == id) > 0;
        }
    }
}