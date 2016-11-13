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
   
    public class IdiomasController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        [HttpGet]
        [Route("MyLearnApi/Idiomas")]
        public IQueryable<IDIOMA> GetIDIOMA()
        {
            return db.IDIOMA;
        }
        [HttpGet]
        [Route("MyLearnApi/Idiomas/{id}")]
        [ResponseType(typeof(IDIOMA))]
        public IHttpActionResult GetIDIOMA(int id)
        {
            IDIOMA iDIOMA = db.IDIOMA.Find(id);
            if (iDIOMA == null)
            {
                return NotFound();
            }

            return Ok(iDIOMA);
        }


        [HttpPost]
        [Route("MyLearnApi/Idiomas")]
        [ResponseType(typeof(IDIOMA))]
        public IHttpActionResult PostIDIOMA(IDIOMA iDIOMA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IDIOMA.Add(iDIOMA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iDIOMA.Id }, iDIOMA);
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IDIOMAExists(int id)
        {
            return db.IDIOMA.Count(e => e.Id == id) > 0;
        }

        [HttpOptions]
        [Route("MyLearnApi/Idiomas/{id}")]
        [Route("MyLearnApi/Idiomas")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}