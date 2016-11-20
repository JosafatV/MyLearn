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
    public class EmpresasController : ApiController
    {

        //
        private clsEmpresasLogic pobj_EmpresasLogic = new clsEmpresasLogic();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Empresas")]
        [ResponseType(typeof(List<VIEW_EMPRESA>))]
        public List<VIEW_EMPRESA> GetVIEW_EMPRESA()
        {
            return pobj_EmpresasLogic.getAllEmpresas();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyLearnApi/Empresas/{id}")]
        [ResponseType(typeof(VIEW_EMPRESA))]
        public IHttpActionResult GetVIEW_EMPRESA(string id)
        {
            VIEW_EMPRESA vIEW_EMPRESA = pobj_EmpresasLogic.getSpecificEmpresa(id);
            if (vIEW_EMPRESA == null | vIEW_EMPRESA.Estado == "E") //eliminado
            {
                return NotFound();
            }

            return Ok(vIEW_EMPRESA);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vIEW_EMPRESA"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MyLearnApi/Empresas")]
        [ResponseType(typeof(VIEW_EMPRESA))]
        public IHttpActionResult PostVIEW_EMPRESA(VIEW_EMPRESA vIEW_EMPRESA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool lbo_conflict = pobj_EmpresasLogic.postEmpresa(vIEW_EMPRESA);

            if (!lbo_conflict)
            {
                return Conflict();
            }
            
            return Ok(vIEW_EMPRESA);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [Route("MyLearnApi/Empresas/{id}")]
        [Route("MyLearnApi/Empresas")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            pobj_EmpresasLogic.dispose(disposing);
            base.Dispose(disposing);
        }

        
    }
}