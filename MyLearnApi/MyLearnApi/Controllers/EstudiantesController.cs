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
    [AllowAnonymous]
    public class EstudiantesController : ApiController
    {   //
        private clsStudentsLogic pobj_studentsLogic = new clsStudentsLogic();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Estudiantes")]
        [ResponseType(typeof(List<VIEW_ESTUDIANTE>))]
        public IHttpActionResult GetESTUDIANTE()
        {
            return Ok(pobj_studentsLogic.GetAllEstudiantes());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Estudiantes/{id}")]
        [ResponseType(typeof(VIEW_ESTUDIANTE))]
        public IHttpActionResult GetESTUDIANTE(string id)
        {
            VIEW_ESTUDIANTE eSTUDIANTE = pobj_studentsLogic.getSpecificStudent(id);

            if (eSTUDIANTE == null || eSTUDIANTE.Estado == "E") //si está eliminado
            {
                return NotFound();
            }        
            return Ok(eSTUDIANTE);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Estudiantes/Idiomas/{idEstudiante}")]
        [ResponseType(typeof(List<VIEW_IDIOMA_POR_ESTUDIANTE>))]
        public IHttpActionResult GetIdiomasPorEstudiante(string idEstudiante)
        {
            return Ok(pobj_studentsLogic.GetIdiomasPorEstudiante(idEstudiante));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Estudiantes")]
        [ResponseType(typeof(VIEW_ESTUDIANTE))]
        public IHttpActionResult PostESTUDIANTE(VIEW_ESTUDIANTE estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool lbo_isValid = pobj_studentsLogic.doStudentInsertion(estudiante);
           
            if (!lbo_isValid)
            {
                return Conflict();
            }
            return Ok(estudiante);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Estudiantes/Idioma")]
        [ResponseType(typeof(IDIOMA_POR_ESTUDIANTE))]
        public IHttpActionResult PostIdiomaToEstudiante(IDIOMA_POR_ESTUDIANTE idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool lbo_isValid = pobj_studentsLogic.addIdiomaToEstudiante(idioma);

            if (!lbo_isValid)
            {
                return Conflict();
            }
            return Ok(idioma);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tecnologia"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Estudiantes/Tecnologia")]
        [ResponseType(typeof(TECNOLOGIA_POR_ESTUDIANTE))]
        public IHttpActionResult PostTecnologiaToEstudiante(TECNOLOGIA_POR_ESTUDIANTE tecnologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool lbo_isValid = pobj_studentsLogic.addTecnologiaToEstudiante(tecnologia);

            if (!lbo_isValid)
            {
                return Conflict();
            }
            return Ok(tecnologia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("MyLearnApi/Estudiantes/{id}")]
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteEstudiante(int id)
        {
            USUARIO estudiante = pobj_studentsLogic.DeleteEstudiante(id);

            if (estudiante == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(estudiante);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [Route("MyLearnApi/Estudiantes")]
        [Route("MyLearnApi/Estudiantes/{id}")]
        [Route("MyLearnApi/Estudiantes/Idioma")]
        [Route("MyLearnApi/Estudiantes/Tecnologia")]
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
            pobj_studentsLogic.dispose(disposing);
            base.Dispose(disposing);
        }

    }
}