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
    public class EmpresasController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();



        [HttpGet]
        [Route("MyLearnApi/Empresas")]
        public IQueryable<VIEW_EMPRESA> GetVIEW_EMPRESA()
        {
            return db.VIEW_EMPRESA.Where(emp => emp.Estado != "E");
        }

        [HttpGet]
        [Route("MyLearnApi/Empresas/{id}")]
        [ResponseType(typeof(VIEW_EMPRESA))]
        public IHttpActionResult GetVIEW_EMPRESA(string id)
        {
            VIEW_EMPRESA vIEW_EMPRESA = db.VIEW_EMPRESA.Find(id);
            if (vIEW_EMPRESA == null | vIEW_EMPRESA.Estado == "E") //eliminado
            {
                return NotFound();
            }

            return Ok(vIEW_EMPRESA);
        }



        [HttpPost]
        [Route("MyLearnApi/Empresas")]
        [ResponseType(typeof(VIEW_EMPRESA))]
        public IHttpActionResult PostVIEW_EMPRESA(VIEW_EMPRESA vIEW_EMPRESA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            VIEW_EMPRESA lobj_v = vIEW_EMPRESA;
            db.SP_Insertar_Empresa(lobj_v.Id, lobj_v.Contrasena, lobj_v.Sal, lobj_v.RepositorioArchivos, lobj_v.CredencialDrive,
                lobj_v.NombreContacto, lobj_v.ApellidoContacto, lobj_v.NombreEmpresarial, lobj_v.Email, lobj_v.Telefono,
                lobj_v.FechaInscripcion, lobj_v.PaginaWebEmpresa, lobj_v.Pais, lobj_v.Region, lobj_v.RepositorioArchivos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VIEW_EMPRESAExists(vIEW_EMPRESA.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(vIEW_EMPRESA);
        }


        [HttpOptions]
        [Route("MyLearnApi/Empresas/{id}")]
        [Route("MyLearnApi/Empresas")]
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

        private bool VIEW_EMPRESAExists(string id)
        {
            return db.VIEW_EMPRESA.Count(e => e.Id == id) > 0;
        }
    }
}