using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using MyEmployeeWebApi.Models;
using MyEmployeeWebApi.BusinessLogic;

namespace MyEmployeeWebApi.Controllers
{
    /// <summary>
    /// Clase controladora de la busqueda de elementos talentosos
    /// </summary>
    [clsBasicAuthentication]
    public class ElementosTalentososController : ApiController
    {
        /// <summary>
        /// clase de acceso a la logica
        /// </summary>
        private clsElementosLogic ele_logic = new clsElementosLogic();

        /// <summary>
        /// Se debe proveer una búsqueda de un top n de los elementos más talentosos por paíse. Los parámetros de búsqueda son ‘n’,
        /// donde n es un número entero que significa el número de resultados deseados y el nombre del país (búsqueda con nombre exacto). 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="pais"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<SP_MyEmployee_Result>))]
        [Route("XmpApi/ElementosTalentosos/numResultados/{n}/Pais/{pais}")]
        public List<SP_MyEmployee_Result> getElementosPorPais(int n, string pais)
        {
            return ele_logic.getElementosPorPais(n,pais);
        }
        /// <summary>
        /// búsqueda es un top ‘n’, de acuerdo al índice, donde se ingresan los n resultados deseados y
        /// cualquiera de los rubros(valor del promedio de la nota de los cursos, Promedio de la calificación 
        /// de proyectos, tasa de proyectos exitosos o  tasa de aprobación de los cursos)  con su porcentaje
        /// correspondiente que va de 0% a 100%.  Se puede buscar solo por un criterio a la vez.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rubro"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<SP_MyEmployee_Result>))]
        [Route("XmpApi/ElementosTalentosos/numResultados/{n}/Criterio/{rubro}/Porcentaje/{porcentaje}")]
        public List<SP_MyEmployee_Custom_Result> getElementosPorCriterio(int n, string rubro, float porcentaje)
        {
            return ele_logic.getElementosPorRubro(n,rubro,porcentaje);
        }
    }
}
