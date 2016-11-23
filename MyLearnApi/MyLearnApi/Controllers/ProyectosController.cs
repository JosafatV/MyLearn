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
        /// 
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/Curso/{idCurso}")]
        [ResponseType(typeof(List<VIEW_PROYECTOS>))]
        public IHttpActionResult GetVIEW_PROYECTOS(int idCurso)
        {
            return Ok(pobj_ProyectoLogic.getProyectosDeCurso(idCurso));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Proyectos/Curso/{idProyecto}")]
        [ResponseType(typeof(VIEW_PROYECTOS))]
        public IHttpActionResult GetVIEW_PROYECTOS(string idProyecto)
        {
            VIEW_PROYECTOS vIEW_PROYECTOS = pobj_ProyectoLogic.getSpecificProyecto(idProyecto);
            if (vIEW_PROYECTOS == null)
            {
                return NotFound();
            }

            return Ok(vIEW_PROYECTOS);
        }

        /// <summary>
        /// 
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
        [Route("MyLearnApi/Badge")]
        [ResponseType(typeof(BADGE_POR_PROYECTO))]
        public IHttpActionResult PostBADGE_POR_PROYECTO(BADGE_POR_PROYECTO badge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            pobj_ProyectoLogic.Dispose(disposing);
            base.Dispose(disposing);
        }

       
    }
}