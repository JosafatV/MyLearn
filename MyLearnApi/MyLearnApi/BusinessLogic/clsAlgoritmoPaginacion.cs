using System;
using System.Collections.Generic;
using MyLearnApi.Models;

namespace MyLearnApi.BusinessLogic
{
    public class clsAlgoritmoPaginacion
    {
        /// <summary>
        /// obtiene un rango de la lista
        /// </summary>
        /// <param name="lista"> lista que se quiere paginar </param>
        /// <param name="index"> indice desde donde se quiere comenzar </param>
        /// <returns></returns>
        public static List<TRABAJO> paginar(List<TRABAJO> lista, int index, byte lby_offset)
        {
            List<TRABAJO> lobj_resultado = new List<TRABAJO>();
            //obtengo el rango que se necesita
            int li_largoLista = lista.Count;
            //si el indice esta fuera del rango de la lista
            if (index * lby_offset > (li_largoLista - 1))
                return lobj_resultado;
            //si index y el offset estan dentro del rango
            else if ((li_largoLista > (index * lby_offset + lby_offset - 1)))
                lobj_resultado = lista.GetRange(index * lby_offset, index * lby_offset + lby_offset);
            //si hay un overflow en el rango devuelve del indice hasta el fin de la lista
            else
                lobj_resultado = lista.GetRange(index * lby_offset, li_largoLista);

            return lobj_resultado;

        }

        public static List<VIEW_TRABAJO> paginar(List<VIEW_TRABAJO> lista, int index, byte lby_offset)
        {
            List<VIEW_TRABAJO> lobj_resultado = new List<VIEW_TRABAJO>();
            //obtengo el rango que se necesita
            int li_largoLista = lista.Count;
            //si el indice esta fuera del rango de la lista
            if (index * lby_offset > (li_largoLista - 1))
                return lobj_resultado;
            //si index y el offset estan dentro del rango
            else if ((li_largoLista > (index * lby_offset + lby_offset - 1)))
                lobj_resultado = lista.GetRange(index * lby_offset, index * lby_offset + lby_offset);
            //si hay un overflow en el rango devuelve del indice hasta el fin de la lista
            else
                lobj_resultado = lista.GetRange(index * lby_offset, li_largoLista);

            return lobj_resultado;

        }

        
        public static List<CURSO_POR_PROFESOR> paginar(List<CURSO_POR_PROFESOR> lista, int index, byte lby_offset)
        {
            List<CURSO_POR_PROFESOR> lobj_resultado = new List<CURSO_POR_PROFESOR>();
            //obtengo el rango que se necesita
            int li_largoLista = lista.Count;
            //si el indice esta fuera del rango de la lista
            if (index * lby_offset > (li_largoLista - 1))
                return lobj_resultado;
            //si index y el offset estan dentro del rango
            else if ((li_largoLista > (index * lby_offset + lby_offset - 1)))
                lobj_resultado = lista.GetRange(index * lby_offset, index * lby_offset + lby_offset);
            //si hay un overflow en el rango devuelve del indice hasta el fin de la lista
            else
                lobj_resultado = lista.GetRange(index * lby_offset, li_largoLista);

            return lobj_resultado;

        }
    }
}