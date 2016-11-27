using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models.DriveIntegration;
using MyLearnApi.BusinessLogic.UserAccounts;
using MyLearnApi.Models;
using System.Text;
using System.Net.Http;


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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cred = clsRepoLogic.createNewCredentials(cred);
            if (cred == null)
                return Conflict();

            return Ok(cred);

        }

        /// <summary>
        /// para subir un archivo y obtener el link
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("MyLearnApi/File/{IdUsuario}")]
        public IHttpActionResult uploadFile(clsFile file, string IdUsuario)
        {

            /*string jason = "{"
                               + "\"installed\": {"
                               + "\"client_id\": \"945542049910-ie4l7np3hup7qpev39stcc4o7rlti85j.apps.googleusercontent.com\","
                               + "\"project_id\": \"basic-computing-149501\","
                               + "\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth  \",  "
                               + "\"token_uri\": \"https://accounts.google.com/o/oauth2/token \", "
                               + "\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs  \","
                               + "\"client_secret\": \"EIuppefDWrd3rOh4RyYSt-DH\","
                               + "\"redirect_uris\": [ \"urn:ietf:wg:oauth:2.0:oob\", \"http://localhost \" ]"
                               + "}"
                        + "}";

            byte[] byteArray = Encoding.UTF8.GetBytes(jason);


            string link = clsRepoLogic.uploadFile(byteArray , IdUsuario ,"perra.json", "JSON/json"); */

            byte[] byteArray = Encoding.UTF8.GetBytes(file.bytes);
            string link = clsRepoLogic.uploadFile(byteArray, IdUsuario, file.name, file.contentType);
            //returnos the web content link
            return Ok(link);
           
        }



        [HttpOptions]
        [Route("MyLearnApi/DriveCredentials")]
        [Route("MyLearnApi/File/{IdUsuario}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


    }
}
