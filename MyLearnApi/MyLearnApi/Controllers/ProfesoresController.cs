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
    public class ProfesoresController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        [HttpGet]
        [Route("MyLearnApi/Profesores")]
        public IQueryable<VIEW_PROFESOR> GetVIEW_PROFESOR()
        {
            return db.VIEW_PROFESOR;
        }

        [HttpGet]
        [Route("MyLearnApi/Profesores/{id}")]
        [ResponseType(typeof(VIEW_PROFESOR))]
        public IHttpActionResult GetVIEW_PROFESOR(string id)
        {
            VIEW_PROFESOR vIEW_PROFESOR = db.VIEW_PROFESOR.Find(id);
            if (vIEW_PROFESOR == null)
            {
                return NotFound();
            }

            return Ok(vIEW_PROFESOR);
        }



        [HttpPost]
        [Route("MyLearnApi/Profesores")]
        [ResponseType(typeof(VIEW_PROFESOR))]
        public IHttpActionResult PostVIEW_PROFESOR(VIEW_PROFESOR vIEW_PROFESOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

         ///   db.SP_Insertar_Profesor(vIEW_PROFESOR.Id,vIEW_PROFESOR.Contrasena,vIEW_PROFESOR.Sal,vIEW_PROFESOR.RepositorioArchivos,vIEW_PROFESOR.CredencialDrive,
            //    vIEW_PROFESOR.NombreContacto, vIEW_PROFESOR.ApellidoContacto,vIEW_PROFESOR.Email,vIEW_PROFESOR.Telefono, vIEW_PROFESOR.FechaInscripcion,
              //  vIEW_PROFESOR.HorarioAtencion,vIEW_PROFESOR.Pais, vIEW_PROFESOR.Region, vIEW_PROFESOR.)

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VIEW_PROFESORExists(vIEW_PROFESOR.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return   Ok(vIEW_PROFESOR);
        }

        [Route("MyLearnApi/Profesores")]
        [Route("MyLearnApi/Profesores/{id}")]
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

        private bool VIEW_PROFESORExists(string id)
        {
            return db.VIEW_PROFESOR.Count(e => e.Id == id) > 0;
        }
    }
}