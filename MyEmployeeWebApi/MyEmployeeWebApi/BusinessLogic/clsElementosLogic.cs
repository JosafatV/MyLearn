﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyEmployeeWebApi.Models;

namespace MyEmployeeWebApi.BusinessLogic
{
    /// <summary>
    /// ejecuta la logica de buscar los elementos más talentosos
    /// </summary>
    public class clsElementosLogic
    {
        //acceso a la base de datos
        private MyLearnDBEntities db = new MyLearnDBEntities();

        /// <summary>
        /// Se debe proveer una búsqueda de un top n de los elementos más talentosos por paíse. Los parámetros de búsqueda son ‘n’,
        /// donde n es un número entero que significa el número de resultados deseados y el nombre del país (búsqueda con nombre exacto). 
        /// </summary>
        /// <param name="top"></param>
        /// <param name="pais"></param>
        /// <returns></returns>
        public List<SP_MyEmployee_Result> getElementosPorPais(int top, string pais)
        {
            //obtiene los mejores elemnentos buscando pais y top
            return db.get_Elementos_por_pais(top, pais).ToList<SP_MyEmployee_Result>();
        }

        /// <summary>
        /// búsqueda es un top ‘n’, de acuerdo al índice, donde se ingresan los n resultados deseados y
        /// cualquiera de los rubros(valor del promedio de la nota de los cursos, Promedio de la calificación 
        /// de proyectos, tasa de proyectos exitosos o  tasa de aprobación de los cursos)  con su porcentaje
        /// correspondiente que va de 0% a 100%.  Se puede buscar solo por un criterio a la vez.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="rubro"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
        public List<SP_MyEmployee_Custom_Result> getElementosPorRubro(int? top, string rubro, double? porcentaje)
        {
            List<SP_MyEmployee_Custom_Result> result = new List<SP_MyEmployee_Custom_Result>();
            double? tasa = porcentaje / 100;
            switch (rubro)
            {
                case "Promedio_notas_de_cursos":
                    result = db.get_elementos_por_rubro(top, porcentaje, 0, 0, 0, 0).ToList<SP_MyEmployee_Custom_Result>();
                    break;

                case "Promedio_calificacion_trabajos":
                    result = db.get_elementos_por_rubro(top, 0, porcentaje, 0, 0, 0).ToList<SP_MyEmployee_Custom_Result>();
                    break;

                case "Tasa_de_Trabajos_Existosos":
                    result = db.get_elementos_por_rubro(top, 0, 0, 0, porcentaje, 0).ToList<SP_MyEmployee_Custom_Result>();
                    break;

                case "Tasa_de aprobacion_de_cursos":
                    result = db.get_elementos_por_rubro(top, 0, 0, porcentaje, 0, 0).ToList<SP_MyEmployee_Custom_Result>();
                    break;

                default:
                    return result;

            }
            for (int i = 0; i < result.Count; i++)
            {
                result[i].NombreContacto = RemoveWhitespace(result[i].NombreContacto);
                result[i].NombreContacto = result[i].NombreContacto.Replace('-', ' ');
            }

            return result;


        }
        /// <summary>
        /// remove withe spaces
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string RemoveWhitespace( string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

    }
    

}