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
    /// Clase controladora de mensajeria entre estudiante y empresa
    /// </summary>
    public class MensajePorTrabajoController : ApiController
    {
        //objeto que maneja la logica del area de trabajo de estudiante-empresa
        private clsAreaDeTrabajoEmpresaLogic pobj_areaLogic = new clsAreaDeTrabajoEmpresaLogic();

        [HttpGet]
        [Route("MyLearnApi/Mensajes/Trabajo/{idTrabajo}")]
        [ResponseType(typeof(List<MENSAJE>))]
        public List<MENSAJE> getMensajesDeTrabajo(int idTrabajo)
        {
            return pobj_areaLogic.getListaMensajesDeTrabajo(idTrabajo);
        }



        [HttpPost]
        [Route("MyLearnApi/Mensajes/Trabajo/{idTrabajo}")]
        [ResponseType(typeof(MENSAJE))]
        public IHttpActionResult PostMENSAJE_POR_TRABAJO(MENSAJE mensaje, int idTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pobj_areaLogic.agregarMensajeATrabajo(mensaje, idTrabajo);

            return Ok(mensaje) ;
  
        }

        [HttpOptions]
        [Route("MyLearnApi/Mensajes/Trabajo/{idTrabajo}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        protected override void Dispose(bool disposing)
        {
            pobj_areaLogic.Dispose(disposing);
            base.Dispose(disposing);
        }        
    }
}