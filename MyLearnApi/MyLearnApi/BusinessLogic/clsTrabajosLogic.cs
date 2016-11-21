using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;

namespace MyLearnApi.BusinessLogic
{
    /// <summary>
    /// clase que maneja la logica de los trabajos de empresa
    /// </summary>
    public class clsTrabajosLogic
    {
        //objeto de acceso a la base de datos
        private MyLearnDBEntities db = new MyLearnDBEntities();

        /// <summary>
        /// Retorna los trabajos activos
        /// </summary>
        /// <returns></returns>
        public List<TRABAJO> getTrabajoActivos(string idEmpresa, int index)
        {
            //retorna los proyectos activos
            List<TRABAJO> listaTrabajos = db.TRABAJO
                .Where(trab => trab.Estado == "A" && trab.IdEmpresa == idEmpresa  )
                .OrderBy(trab => trab.FechaCierre)
                .ToList<TRABAJO>();
            //pagina el resultado de 20 en 20
            return algoritmoPaginacion(listaTrabajos, index, 20);
        }

        /// <summary>
        /// Retorna las subastas que no han sido aceptadas como trabajos (subastados)
        /// Son trabajos en estado de subasta
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<VIEW_TRABAJO> getSubastasdeTrabajosActivas(string idEmpresa, int index)
        {
            //estado "P" de trabajo pendiente, o sea es una subasta

            List<VIEW_TRABAJO> listaTrabajos = db.VIEW_TRABAJO
                .Where(trab => trab.EstadoTrabajo == "P" && trab.IdEmpresa == idEmpresa)
                .OrderBy(trab => trab.FechaFinalizacion)
                .ToList<VIEW_TRABAJO>();
            //pagina el resultado de 20 en 20
            return algoritmoPaginacion(listaTrabajos, index, 20);
        }

        /// <summary>
        /// obtiene un trabajo especifico buscado con el id
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <returns></returns>
        public VIEW_TRABAJO getSpecificTrabajo(int idTrabajo)
        {
            if (View_TRABAJOExists(idTrabajo))
                return db.VIEW_TRABAJO.Find(idTrabajo);
            else
                return null;       
        }

        /// <summary>
        /// logica de insertar nuevo trabajo en la base de datos
        /// </summary>
        /// <param name="tRABAJO"></param>
        /// <returns></returns>
        public TRABAJO insertarTrabajo(TRABAJO tRABAJO)
        {
            //se crea como pendiente (o sea esta en estado de subasta)
            tRABAJO.Estado = "P";
            tRABAJO.EstrellasObtenidas = 0;
            db.TRABAJO.Add(tRABAJO);
            db.SaveChanges();
            return tRABAJO;
        }

        
        /// <summary>
        /// funcion para cambiar el estado de un trabajo
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        private bool cambiarEstadoTrabajo(int idTrabajo, string estado)
        {

            TRABAJO trabajo = db.TRABAJO.Find(idTrabajo);
            trabajo.Estado = estado;

            db.Entry(trabajo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRABAJOExists(idTrabajo))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public bool convertirSubastaEnTrabajo(int idTrabajo)
        {
            return cambiarEstadoTrabajo(idTrabajo, "A");
        }


        /// <summary>
        /// pregunta si el trabajo existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool TRABAJOExists(int id)
        {
            return db.TRABAJO.Count(e => e.Id == id) > 0;
        }

        private bool View_TRABAJOExists(int id)
        {
            return db.VIEW_TRABAJO.Count(e => e.IdTrabajo == id) > 0;
        }


        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// obtiene un rango de la lista
        /// </summary>
        /// <param name="lista"> lista que se quiere paginar </param>
        /// <param name="index"> indice desde donde se quiere comenzar </param>
        /// <returns></returns>
        private List<TRABAJO> algoritmoPaginacion(List<TRABAJO> lista, int index, byte lby_offset )
        {
            List<TRABAJO> lobj_resultado = new List<TRABAJO>();
            //obtengo el rango que se necesita
            int li_largoLista = lista.Count;
            //si el indice esta fuera del rango de la lista
            if (index > li_largoLista)
                return lobj_resultado;
            //si index y el offset estan dentro del rango
            else if ((li_largoLista >= (index + lby_offset)))
                lobj_resultado = lista.GetRange(index, index + lby_offset - 1);
            //si hay un overflow en el rango devuelve del indice hasta el fin de la lista
            else
                lobj_resultado = lista.GetRange(index, li_largoLista );

            return lobj_resultado;

        }


        /// <summary>
        /// obtiene un rango de la lista
        /// </summary>
        /// <param name="lista"> lista que se quiere paginar </param>
        /// <param name="index"> indice desde donde se quiere comenzar </param>
        /// <returns></returns>
        private List<VIEW_TRABAJO> algoritmoPaginacion(List<VIEW_TRABAJO> lista, int index, byte lby_offset)
        {
            List<VIEW_TRABAJO> lobj_resultado = new List<VIEW_TRABAJO>();
            //obtengo el rango que se necesita
            int li_largoLista = lista.Count;
            //si el indice esta fuera del rango de la lista
            if (index > li_largoLista)
                return lobj_resultado;
            //si index y el offset estan dentro del rango
            else if ((li_largoLista >= (index + lby_offset)))
                lobj_resultado = lista.GetRange(index, index + lby_offset - 1);
            //si hay un overflow en el rango devuelve del indice hasta el fin de la lista
            else
                lobj_resultado = lista.GetRange(index, li_largoLista);

            return lobj_resultado;

        }


    }
}