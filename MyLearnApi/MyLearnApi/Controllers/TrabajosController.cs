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
        [ResponseType(typeof(List<TRABAJO>))]
        public List<TRABAJO> getTrabajosActivos(string idEmpresa, int index)
        {
            return pobj_TrabajosLogic.getTrabajoActivos(idEmpresa,index);
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
        [ResponseType(typeof(TRABAJO))]
        public IHttpActionResult GetTRABAJO(int idTrabajo)
        {
            TRABAJO tRABAJO = pobj_TrabajosLogic.getSpecificTrabajo(idTrabajo);
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
        [Route("MyLearnApi/Trabajos")]
        public IHttpActionResult convertirSubastaEnTrabajo(int idTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool lbo_isvalid = pobj_TrabajosLogic.convertirSubastaEnTrabajo(idTrabajo);
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

       
    }
}