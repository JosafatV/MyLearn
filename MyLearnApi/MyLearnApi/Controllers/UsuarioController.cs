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
    public class UsuarioController : ApiController
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();


      /*  [HttpGet]
        [Route("MyLearnApi/Usuario/{idUsuario}/Password/{Password}")]
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult GetUSUARIO(string idUsuario, string Password)
        {
             cuenta = new clsCuentaDeUsuario();

            if(clsCuentaDeUsuario.login(id)
            USUARIO uSUARIO = db.USUARIO.Find(idUsuario);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }

      */

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}