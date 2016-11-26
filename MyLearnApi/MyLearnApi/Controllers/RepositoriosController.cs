using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models.DriveIntegration;
using MyLearnApi.BusinessLogic.UserAccounts;
using MyLearnApi.Models;



namespace MyLearnApi.Controllers
{
    public class RepositoriosController : ApiController
    {
        private clsRepoLogic pobj_repoLogic = new clsRepoLogic();

        /// <summary>
        /// obtiene el client secre json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(clsClientSecret))]
        [Route("MyLearnApi/ClientSecret")]
        public IHttpActionResult getSecretJson()
        {
            clsClientSecret lobj_secre = new clsClientSecret();
            return Ok(lobj_secre);

        }

        /// <summary>
        /// crea una nueva credencial de drive de un usuario
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(DriveCredentials))]
        [Route("MyLearnApi/DriveCredentials")]
        public IHttpActionResult addDriveCredentials(DriveCredentials cred)
        {
            cred = pobj_repoLogic.createNewCredentials(cred);
            return Ok(cred);

        }

        /// <summary>
        /// para subir un archivo y obtener el link
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("MyLearnApi/File")]
        public IHttpActionResult uploadFile()
        {
         
            return Ok(pobj_repoLogic.uploadFile());   

        }


    }
}
