using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
namespace MyEmployeeWebApi.Controllers
{
    public class ElementosTalentososController : ApiController
    {

        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("XmpApi/ElementosTalentosos/numResultados/{n}/Pais/{pais}")]
        public string getElementosPorPais(int n, string pais)
        {
            return "";
        }

        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("XmpApi/ElementosTalentosos/numResultados/{n}/Criterio/{rubro}/Porcentaje/{porcentaje}")]
        public string getElementosPorCriterio(int n, string rubro, float porcentaje)
        {
            return "";
        }



    }
}
