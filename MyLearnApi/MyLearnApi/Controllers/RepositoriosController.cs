using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyLearnApi.Models.DriveIntegration;


namespace MyLearnApi.Controllers
{
    public class RepositoriosController : ApiController
    {
        private clsDriveConn driveConn = new clsDriveConn();


        [HttpGet]
        [ResponseType(typeof(clsClientSecret))]
        [Route("MyLearnApi/ClientSecret")]
        public IHttpActionResult getSecretJson()
        {
            clsClientSecret lobj_secre = new clsClientSecret();
            return Ok(lobj_secre);

        }

        //prueba borrar
        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("MyLearnApi/File")]
        public IHttpActionResult uploadFile()
        {
            driveConn.getContentLink("biber","JSON/Json");

            return StatusCode(HttpStatusCode.NoContent) ;

        }


    }
}
