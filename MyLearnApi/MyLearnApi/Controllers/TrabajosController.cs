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
    /// clase controladora de las entidades trabajos
    /// </summary>
    public class TrabajosController : ApiController
    {
        //objeto que maneja la logica de los trabajos
        private clsTrabajosLogic pobj_TrabajosLogic = new clsTrabajosLogic();

        /// <summary>
        /// get de los trabajos activos
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="index"> indice de paginacion </param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Trabajos/Empresa/{idEmpresa}/{index}")]
        [ResponseType(typeof(List<VIEW_TRABAJO>))]
        public List<VIEW_TRABAJO> getTrabajosActivos(string idEmpresa, int index)
        {
            return pobj_TrabajosLogic.getTrabajoActivos(idEmpresa,index);
        }

        /// <summary>
        ///  obtiene las ofertas no aceptadas de un trabajo especifico de una empresa especifica
        /// </summary>
        /// <param name="idEmpresa"> llave primaria de la empresa </param>
        /// <param name="idTrabajo"> identificador del trabajo </param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Subastas/Ofertas/{idEmpresa}/{idTrabajo}")]
        [ResponseType(typeof(List<VIEW_TRABAJO>))]
        public List<VIEW_TRABAJO> getOfertasDeSubasta(string idEmpresa, int idTrabajo)
        {
            return pobj_TrabajosLogic.getOfertasParaSubasta(idEmpresa, idTrabajo);
        }
        /// <summary>
        /// Get de los trabajos en estado de subasta
        /// </summary>
        /// <param name="idEmpresa"> </param>
        /// <param name="index"> indice de paginacion </param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Subastas/Empresa/{idEmpresa}/{index}")]
        [ResponseType(typeof(List<TRABAJO>))]
        public List<TRABAJO> getSubastasActivas(string idEmpresa, int index)
        {
            return pobj_TrabajosLogic.getSubastasdeTrabajosActivas(idEmpresa,index);
        }


        [HttpGet]
        [Route("MyLearnApi/Trabajos/{idTrabajo}")]
        [ResponseType(typeof(VIEW_TRABAJO))]
        public IHttpActionResult GetTRABAJO(int idTrabajo)
        {
            VIEW_TRABAJO tRABAJO = pobj_TrabajosLogic.getSpecificTrabajo(idTrabajo);
            if (tRABAJO == null)
            {
                return NotFound();
            }

            return Ok(tRABAJO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("MyLearnApi/Trabajos/{idTrabajo}/{idEstudiante}")]
        public IHttpActionResult convertirSubastaEnTrabajo(int idTrabajo, string idEstudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool lbo_isvalid = pobj_TrabajosLogic.convertirSubastaEnTrabajo(idTrabajo,idEstudiante);
            if (!lbo_isvalid)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tRABAJO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Subastas")]
        [ResponseType(typeof(TRABAJO))]
        public IHttpActionResult PostTRABAJO(TRABAJO tRABAJO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tRABAJO = pobj_TrabajosLogic.insertarTrabajo(tRABAJO);

            return Ok(tRABAJO);
        }

    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            pobj_TrabajosLogic.Dispose(disposing);
            base.Dispose(disposing);
        }
        
        [HttpOptions]
        [Route("MyLearnApi/Trabajos/{idTrabajo}/{idEstudiante}")]
        [Route("MyLearnApi/Subastas")]
        [Route("MyLearnApi/Trabajos")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

    }
}