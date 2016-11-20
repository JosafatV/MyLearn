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
    public class UniversidadesController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        [HttpGet]
        [Route("MyLearnApi/Universidades")]
        public IQueryable<UNIVERSIDAD> GetUNIVERSIDAD()
        {
            return db.UNIVERSIDAD;
        }




        [HttpPost]
        [Route("MyLearnApi/Universidades")]
        [ResponseType(typeof(UNIVERSIDAD))]
        public IHttpActionResult PostUNIVERSIDAD(UNIVERSIDAD uNIVERSIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UNIVERSIDAD.Add(uNIVERSIDAD);
            db.SaveChanges();

            return Ok(uNIVERSIDAD);
        }

        [HttpOptions]
        [Route("MyLearnApi/Universidades")]
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

        private bool UNIVERSIDADExists(int id)
        {
            return db.UNIVERSIDAD.Count(e => e.Id == id) > 0;
        }
    }
}