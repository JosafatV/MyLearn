﻿using System;
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
        /// Get de los trabajos de un estudiante
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Trabajos/Estudiante/{idEstudiante}")]
        [ResponseType(typeof(List<VIEW_TRABAJO>))]
        public List<VIEW_TRABAJO> getTrabajosActivosDeEstudiante(string idEstudiante)
        {
            return pobj_TrabajosLogic.getTrabajoDeEstudiante(idEstudiante);
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

        /// <summary>
        /// get de un trabajo especifico
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Trabajos/{idTrabajo}/{idEstudiante}")]
        [ResponseType(typeof(VIEW_TRABAJO))]
        public IHttpActionResult GetTRABAJO(int idTrabajo, string idEstudiante)
        {
            VIEW_TRABAJO tRABAJO = pobj_TrabajosLogic.getSpecificTrabajo(idTrabajo, idEstudiante);
            if (tRABAJO == null)
            {
                return NotFound();
            }

            return Ok(tRABAJO);
        }


        /// <summary>
        /// get de una subasta especifica
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Subastas/{idTrabajo}")]
        [ResponseType(typeof(TRABAJO))]
        public IHttpActionResult GetTRABAJO(int idTrabajo)
        {
            TRABAJO tRABAJO = pobj_TrabajosLogic.getInfoTrabajo(idTrabajo);
            if (tRABAJO == null)
            {
                return NotFound();
            }

            return Ok(tRABAJO);
        }



        [HttpGet]
        [Route("MyLearnApi/Trabajos/Tecnologias/{idTrabajo}")]
        [ResponseType(typeof(List<TECNOLOGIA>))]
        public IHttpActionResult GetTecnologiasTrabajo(int idTrabajo)
        {
            return Ok(pobj_TrabajosLogic.getTecnologiasTrabajo(idTrabajo));
        }

        /// <summary>
        /// filtra las subastas por nombre y tecnologia. Puede buscar por ambos o un parámetro
        /// </summary>
        /// <param name="IdTecnologia"></param>
        /// <param name="NombreTrabajo"></param>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Subastas/{IdTecnologia}/{NombreTrabajo}/{idEstudiante}")]
        [ResponseType(typeof(List<TRABAJO>))]
        public IHttpActionResult buscarPorTecnologiaYNombreTrabajo(int IdTecnologia, string NombreTrabajo,string idEstudiante)
        {
            return Ok(pobj_TrabajosLogic.getTabajosPorTecnologiaYNombre(IdTecnologia, NombreTrabajo,idEstudiante));
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
                //put
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
        /// post de una oferta a una usbasta para competir
        /// </summary>
        /// <param name="oferta"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Subastas/Ofertas")]
        [ResponseType(typeof(TRABAJO_POR_ESTUDIANTE))]
        public IHttpActionResult PostOferta(TRABAJO_POR_ESTUDIANTE oferta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            oferta = pobj_TrabajosLogic.crearOfertaSubasta(oferta);
            if (oferta == null)
                return Conflict();


            return Ok(oferta);
        }

        [HttpPost]
        [Route("MyLearnApi/Subastas/Tecnologia")]
        [ResponseType(typeof(TECNOLOGIA_POR_TRABAJO))]
        public IHttpActionResult postTecnologiaAProyecto(TECNOLOGIA_POR_TRABAJO tecnologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool lbo_isValid = pobj_TrabajosLogic.addTecnologiaToTrabajo(tecnologia);

            if (!lbo_isValid)
            {
                return Conflict();
            }
            return Ok(tecnologia);

        }


        [HttpPost]
        [Route("MyLearnApi/Trabajos/Terminados/{idTrabajo}/{idEstudiante}/{estrellas}/{exitoso}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult terminartrabajo(int idTrabajo, string idEstudiante, byte estrellas, bool exitoso)
        {
            if (pobj_TrabajosLogic.terminarTrabajo(idTrabajo,idEstudiante,estrellas,exitoso))
                return StatusCode(HttpStatusCode.NoContent);
            else
                return Conflict();
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
        [Route("MyLearnApi/Subastas/Tecnologia")]
        [Route("MyLearnApi/Subastas/Ofertas")]
        [Route("MyLearnApi/Trabajos/Terminados/{idTrabajo}/{idEstudiante}/{estrellas}/{exitoso}")]
        [Route("MyLearnApi/Subastas/Tecnoloogia/{idTecnologia}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

    }
}