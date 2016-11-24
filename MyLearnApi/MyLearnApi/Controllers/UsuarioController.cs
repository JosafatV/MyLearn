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


        [HttpGet]
        [Route("MyLearnApi/Usuario/{NombreUsuario}/Password/{Password}")]
        [ResponseType(typeof(List<USUARIO>))]
        public IHttpActionResult GetUSUARIO(string NombreUsuario, string Password)
        {
            clsLink link = new clsLink();
            link.rel = "userProfile";
            if (clsCuentaDeUsuario.login(NombreUsuario, Password))
            {
                byte rol = clsCuentaDeUsuario.getRol(NombreUsuario);
                USUARIO usuario = db.USUARIO.Where(u => u.NombreDeUsuario == NombreUsuario).ToList()[0];
                switch (rol)
                {
                    case clsCuentaDeUsuario.ROL_ESTUDIANTE:
                        link.href = "/MyLearn/Estudiante/Perfil/";
                        break;
                    case clsCuentaDeUsuario.ROL_EMPRESA:
                        link.href = "/MyLearn/Empresa/Perfil/";
                        break;
                    case clsCuentaDeUsuario.ROL_PROFESOR:
                        link.href = "/MyLearn/Profesor/Perfil/";
                        break;
                   
                }
                usuario.agregarLink(link);
                List<USUARIO> result = new List<USUARIO>();
                usuario.Sal = "********";
                usuario.Contrasena = "*******";
                result.Add(usuario);
                return Ok(result);
            }

            //si no lo encuentra retorna la lista vacia
            return Ok(new List<USUARIO>());
        }

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