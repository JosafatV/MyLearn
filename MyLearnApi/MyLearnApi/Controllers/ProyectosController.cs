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
    public class ProyectosController : ApiController
    {
        //
        private clsProyectosLogic pobj_ProyectoLogic = new clsProyectosLogic();
        
        /// <summary>
        /// get proyectos de un curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/Profesores/Curso/{idCurso}")]
        [ResponseType(typeof(List<VIEW_PROYECTOS>))]
        public IHttpActionResult GetProyectosDeCurso(int idCurso)
        {
            return Ok(pobj_ProyectoLogic.getProyectosDeCurso(idCurso));
        }

        /// <summary>
        /// get de royectos de un estudiante
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/Estudiantes/{idEstudiante}")]
        [ResponseType(typeof(List<VIEW_PROYECTOS>))]
        public IHttpActionResult GetProyectosDeEstudiante(string idEstudiante)
        {
            return Ok(pobj_ProyectoLogic.getProyectosDeEstudiante(idEstudiante));
        }

        /// <summary>
        /// Get de un proyecto en específico
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/Curso/{idProyecto}")]
        [ResponseType(typeof(VIEW_PROYECTOS))]
        public IHttpActionResult GetProyecto(string idProyecto)
        {
            VIEW_PROYECTOS vIEW_PROYECTOS = pobj_ProyectoLogic.getSpecificProyecto(idProyecto);
            if (vIEW_PROYECTOS == null)
            {
                return NotFound();
            }

            return Ok(vIEW_PROYECTOS);
        }

        /// <summary>
        /// Crea una propuesta de proyecto para un curso en estado activo (no tiene que esperar a aceptarse)
        /// </summary>
        /// <param name="proyect"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Proyectos")]
        [ResponseType(typeof(VIEW_PROYECTOS))]
        public IHttpActionResult PostVIEW_PROYECTOS(VIEW_PROYECTOS proyect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            if (pobj_ProyectoLogic.PostVIEW_PROYECTOS(proyect) == null)
            {
                return Conflict();
            }
            else
                return Ok(proyect) ;
        }

        /// <summary>
        /// Otorga un badge a un proyecto
        /// </summary>
        /// <param name="bADGE_POR_PROYECTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Proyectos/Badge")]
        [ResponseType(typeof(BADGE_POR_PROYECTO))]
        public IHttpActionResult PostBADGE_POR_PROYECTO(BADGE_POR_PROYECTO badge)
        {
            //pregunta si el formato es correcto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //almancea el badge y confirma si el almacenaje fue exitoso
            if (pobj_ProyectoLogic.otorgarBadge(badge) == null )
            {
                return Conflict();
            }
            else
            {
            return Ok(badge);
            }
            
        }

        /// <summary>
        /// Obtiene todos los badges posibles para ese proyecto,
        /// o sea los badges creados para un curso
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/Badges/{idProyecto}")]
        [ResponseType(typeof(List<BADGE>))]
        public IHttpActionResult getBadgesDeProyecto(int idProyecto)
        {
            return Ok(pobj_ProyectoLogic.getBadgesDeProyecto(idProyecto));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCurso"></param>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/BadgesNoOtorgados/{idCurso}/{idProyecto}")]
        [ResponseType(typeof(List<BADGE>))]
        public IHttpActionResult getBadgesDeProyectoNoDados(int idCurso,int idProyecto)
        {
            return Ok(pobj_ProyectoLogic.getBadgesDeProyectoNoOtorgados(idCurso,idProyecto));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            pobj_ProyectoLogic.Dispose(disposing);
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método para habilitar métodos desde una aplicación web
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [Route("MyLearnApi/Proyectos/Badge")]
        [Route("MyLearnApi/Proyectos")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


    }
}