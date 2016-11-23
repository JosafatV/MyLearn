using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models;
using MyLearnApi.BusinessLogic;

namespace MyLearnApi.Controllers
{
    public class MensajePorProyectoController : ApiController
    {
        //objeto que maneja la logica del area de trabajo de estudiante-profesor
        private clsAreaDeTrabajoLogic pobj_areaLogic = new clsAreaDeTrabajoLogic();

        [HttpGet]
        [Route("MyLearnApi/Mensajes/Proyecto/{idProyecto}")]
        [ResponseType(typeof(List<MENSAJE>))]
        public List<MENSAJE> getMensajesDeProyecto(int idProyecto)
        {
            return pobj_areaLogic.getListaMensajesDeProyecto(idProyecto);
        }



        [HttpPost]
        [Route("MyLearnApi/Mensajes/Proyecto/{idProyecto}")]
        [ResponseType(typeof(MENSAJE))]
        public IHttpActionResult PostMENSAJE_POR_Proyecto(MENSAJE mensaje, int idProyecto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pobj_areaLogic.agregarMensajeAProyecto(mensaje, idProyecto);

            return Ok(mensaje);

        }

        /// <summary>
        /// postea una respuesta aun mensaje
        /// </summary>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Mensajes/Proyecto/Respuesta")]
        [ResponseType(typeof(RESPUESTA))]
        public IHttpActionResult responderMensaje(RESPUESTA respuesta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pobj_areaLogic.responderMensaje(respuesta);
            return Ok(respuesta);
        }


        [HttpOptions]
        [Route("MyLearnApi/Mensajes/Proyecto/{idProyecto}")]
        [Route("MyLearnApi/Mensajes/Proyecto/Respuesta")]
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
