using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models;
using MyLearnApi.BusinessLogic;

namespace MyLearnApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfesoresController : ApiController
    {
        //
        private clsProfesoresLogic pobj_ProfesoresLogic = new clsProfesoresLogic();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Profesores")]
        [ResponseType(typeof(List<VIEW_PROFESOR>))]
        public List<VIEW_PROFESOR> GetVIEW_PROFESOR()
        {
            return pobj_ProfesoresLogic.getAllProfesores();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Profesores/{id}")]
        [ResponseType(typeof(VIEW_PROFESOR))]
        public IHttpActionResult GetVIEW_PROFESOR(string id)
        {
            VIEW_PROFESOR vIEW_PROFESOR = pobj_ProfesoresLogic.getSpecificProfesor(id);
            if (vIEW_PROFESOR == null)
            {
                return NotFound();
            }

            return Ok(vIEW_PROFESOR);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vIEW_PROFESOR"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Profesores")]
        [ResponseType(typeof(VIEW_PROFESOR))]
        public IHttpActionResult PostVIEW_PROFESOR(VIEW_PROFESOR vIEW_PROFESOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool lbo_isValid = pobj_ProfesoresLogic.insertProfesor(vIEW_PROFESOR); 

           
            if (!lbo_isValid)
            {
                return Conflict();
            }
               
            return   Ok(vIEW_PROFESOR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("MyLearnApi/Profesores")]
        [Route("MyLearnApi/Profesores/{id}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            pobj_ProfesoresLogic.Dispose(disposing);
            base.Dispose(disposing);
        }

        
    }
}