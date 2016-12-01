using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models.DriveIntegration;
using MyLearnApi.BusinessLogic.UserAccounts;
using MyLearnApi.Models;
using System.Text;
using System.Net.Http;
using System.Web;
using Tweetinvi;


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
        /// para subir solo un archivo y obtener el link de descarga de drive
        /// </summary>
        /// <returns> File download link </returns>
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("MyLearnApi/File/{IdUsuario}")]
        public IHttpActionResult uploadFile(string IdUsuario)
        {
            //Si lalista de archivos viene vacía
            if (HttpContext.Current.Request.Files.Count == 0)
            {
                return Ok("{ \"link\": \"\" }");
            }
            ///se revisa el primer archivo
            if (HttpContext.Current.Request.Files[0] == null)
            {
                return Ok("nullFile");
            }
            
            //obtiene el input Streeam
             byte[] byteArray = new byte[HttpContext.Current.Request.Files[0].InputStream.Length + 1];
             HttpContext.Current.Request.Files[0].InputStream.Read(byteArray, 0, byteArray.Length);
            //envía el input stram a la capa de logica y luego a la de datos para psersistir el archivo
            string link = clsRepoLogic.uploadFile(HttpContext.Current.Request.Files[0].InputStream, IdUsuario,
                HttpContext.Current.Request.Files[0].FileName, HttpContext.Current.Request.Files[0].ContentType);
            //returnos the web content link
            return Ok("{ \"link\": \"" + link + " \" }"  );
           
        }




        /// <summary>
        /// para subir solo un archivo y obtener el link de descarga de drive
        /// </summary>
        /// <returns> File download link </returns>
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("MyLearnApi/Twitt/{IdUsuario}")]
        public IHttpActionResult twitt(string IdUsuario)
        {
            Auth.SetUserCredentials("jUV15h3RmCiiTlewmoSICNdx2", "EDugd5Ph71tuvmZmEfKXeaUQw5DDLJh1bjUSkhYuDd4p4p4TJn",
                "940379875-jiedKvLwZFqCLTvQ7cX7fNzUTkh6djKt610xLm8d", "wtvlmiiovHuG4xm4Wcp5FXl5gwDe19nQr6gAa2l3NaBvq");
            var user = Tweetinvi.User.GetAuthenticatedUser();

            var tweet = Tweet.PublishTweet("Twitter REST API -prueba");

            return Ok("{  }");

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
