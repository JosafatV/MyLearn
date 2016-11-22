using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models;
using MyLearnApi.BusinessLogic;

namespace MyLearnApi.Controllers
{
    public class CursosController : ApiController
    {
        private clsCursosLogic pobj_cursosLogic = new clsCursosLogic();
        

        [HttpGet]
        [Route("MyLearnApi/Cursos/Profesor/{idProfesor}/{index}")]
        [ResponseType(typeof(List<CURSO_POR_PROFESOR>))]
        public List<CURSO_POR_PROFESOR> getCursosDeProfesor(string idProfesor,int index)
        {
            return pobj_cursosLogic.getCursosDeProfesor(idProfesor,index);
        }

        [HttpGet]
        [Route("MyLearnApi/Cursos/Estudiante/{idEstudiante}")]
        [ResponseType(typeof(List<CURSO>))]
        public List<CURSO> getCursosDeEstudiante(string idEstudiante)
        {
            return pobj_cursosLogic.getCursosPorEstudiante(idEstudiante);
        }

        [HttpGet]
        [Route("MyLearnApi/Cursos/Universidad/{idUniversidad}/{idEstudiante}")]
        [ResponseType(typeof(List<CURSO>))]
        public List<CURSO> getCursosDeUniversidad(int idUniversidad,string idEstudiante)
        {
            return pobj_cursosLogic.getCursosPorUniversidad(idUniversidad,idEstudiante);
        }

        [HttpGet]
        [Route("MyLearnApi/Cursos/{idCurso}")]
        [ResponseType(typeof(CURSO))]
        public IHttpActionResult getCurso(int idCurso)
        {
            CURSO curso = pobj_cursosLogic.getSpecificCurso(idCurso);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpGet]
        [Route("MyLearnApi/Cursos/Terminado/{idCurso}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult terminarCurso(int idCurso)
        {
            pobj_cursosLogic.terminarCurso(idCurso);
            return StatusCode(HttpStatusCode.NoContent);
        }

        /*
              // PUT: api/Cursos/5
              [ResponseType(typeof(void))]
              public IHttpActionResult PutCURSO_POR_PROFESOR(int id, CURSO_POR_PROFESOR cURSO_POR_PROFESOR)
              {
                  if (!ModelState.IsValid)
                  {
                      return BadRequest(ModelState);
                  }

                  if (id != cURSO_POR_PROFESOR.IdCurso)
                  {
                      return BadRequest();
                  }

                  db.Entry(cURSO_POR_PROFESOR).State = EntityState.Modified;

                  try
                  {
                      db.SaveChanges();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!CURSO_POR_PROFESORExists(id))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }

                  return StatusCode(HttpStatusCode.NoContent);
              }*/

        /// <summary>
        /// Post de un curso
        /// </summary>
        /// <param name="Curso"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/CursosPorProfesor")]
        [ResponseType(typeof(CURSO))]
        public IHttpActionResult PostCURSO_POR_PROFESOR(clsCursoSpModel Curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Curso = pobj_cursosLogic.PostCURSO_POR_PROFESOR(Curso);

            return Ok(Curso);
        }

        /// <summary>
        /// post de un badge (a un curso)
        /// </summary>
        /// <param name="badge"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Cursos/Badges")]
        [ResponseType(typeof(List<BADGE>))]
        public IHttpActionResult PostBADGE(List<BADGE> badges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //valida ell puntaje total
            if (pobj_cursosLogic.isTotalPuntajeValido(badges))
                badges = pobj_cursosLogic.insertBadge(badges);
            //si no lo cum´ple retorna conflicto
            else
                return Conflict();

            return Ok(badges);
        }

        /// <summary>
        /// Get de una lista de los bagdes de un curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Cursos/Badges/{idCurso}")]
        [ResponseType(typeof(List<BADGE>))]
        public List<BADGE> getBadgesCurso(int idCurso)
        {
            return pobj_cursosLogic.getBadgePorCurso(idCurso);
        }


        protected override void Dispose(bool disposing)
        {
            pobj_cursosLogic.Dispose(disposing);
            base.Dispose(disposing);
        }

        [HttpOptions]
        [Route("MyLearnApi/CursosPorProfesor")]
        [Route("MyLearnApi/Cursos/Badges")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}