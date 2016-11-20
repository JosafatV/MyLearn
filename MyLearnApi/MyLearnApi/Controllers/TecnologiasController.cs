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
    public class TecnologiasController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        [HttpGet]
        [Route("MyLearnApi/Tecnologias")]
        public IQueryable<TECNOLOGIA> GetTECNOLOGIA()
        {
            return db.TECNOLOGIA;
        }

        [HttpGet]
        [Route("MyLearnApi/Tecnologias/{id}")]
        [ResponseType(typeof(TECNOLOGIA))]
        public IHttpActionResult GetTECNOLOGIA(int id)
        {
            TECNOLOGIA tECNOLOGIA = db.TECNOLOGIA.Find(id);
            if (tECNOLOGIA == null)
            {
                return NotFound();
            }

            return Ok(tECNOLOGIA);
        }


        [HttpPost]
        [Route("MyLearnApi/Tecnologias")]
        [ResponseType(typeof(TECNOLOGIA))]
        public IHttpActionResult PostTECNOLOGIA(TECNOLOGIA tECNOLOGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TECNOLOGIA.Add(tECNOLOGIA);
            db.SaveChanges();
           

            return Ok(tECNOLOGIA);
        }


        [HttpOptions]
        [Route("MyLearnApi/Tecnologias")]
        [Route("MyLearnApi/Tecnologias/{id}")]
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

        private bool TECNOLOGIAExists(int id)
        {
            return db.TECNOLOGIA.Count(e => e.Id == id) > 0;
        }
    }
}