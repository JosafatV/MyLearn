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
        public List<VIEW_TRABAJO> getTrabajoActivos(string idEmpresa, int index)
        {
            //retorna los proyectos activos
            List<VIEW_TRABAJO> listaTrabajos = db.VIEW_TRABAJO
                .Where(trab => trab.EstadoTrabajo == "A" && trab.IdEmpresa == idEmpresa && trab.EstadoTrabajoPorEstudiante =="A" )
                .OrderBy(trab => trab.FechaFinalizacion)
                .ToList<VIEW_TRABAJO>();
            //pagina el resultado de 20 en 20
            return algoritmoPaginacion(listaTrabajos, index, 20);
        }

        /// <summary>
        /// retorna proyectos activos y terminados
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        public List<VIEW_TRABAJO> getTrabajoDeEstudiante(string idEstudiante)
        {
            //retorna los proyectos activos
            List<VIEW_TRABAJO> listaTrabajos = db.VIEW_TRABAJO
                //si es activo "A" o terminado "T"
                .Where(trab => (trab.EstadoTrabajo == "A"  || trab.EstadoTrabajo == "T" )&&
                trab.IdEstudiante == idEstudiante &&
                trab.EstadoTrabajoPorEstudiante == "A")
                .OrderBy(trab => trab.Nombre)
                .ToList<VIEW_TRABAJO>();
            //pagina el resultado de 20 en 20
            return listaTrabajos;
        }

        /// <summary>
        /// obtiene las ofertas no aceptadas de un trabajo especifico de una empresa especifica
        /// </summary>
        /// <param name="idEmpresa"> llave primaria de la empresa </param>
        /// <param name="idTrabajo"> identificador del trabajo </param>
        /// <returns></returns>
        public List<VIEW_TRABAJO> getOfertasParaSubasta(string idEmpresa, int idTrabajo)
        {
            //lista las orfetas de una subasta especifica de una empresa especifica
            List<VIEW_TRABAJO> listaTrabajos = db.VIEW_TRABAJO
                .Where(trab => trab.EstadoTrabajo == "P" && trab.IdEmpresa == idEmpresa &&
                trab.EstadoTrabajoPorEstudiante == "P" && trab.IdTrabajo == idTrabajo)
                .OrderBy(trab => trab.FechaFinalizacion)
                .ToList<VIEW_TRABAJO>();
            //pagina el resultado de 20 en 20
            return listaTrabajos;
        }

        /// <summary>
        /// Retorna las subastas que no han sido aceptadas como trabajos (subastados)
        /// Son trabajos en estado de subasta
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<TRABAJO> getSubastasdeTrabajosActivas(string idEmpresa, int index)
        {
            //estado "P" de trabajo pendiente, o sea es una subasta

            List<TRABAJO> listaTrabajos = db.TRABAJO
                .Where(trab => trab.Estado == "P" && trab.IdEmpresa == idEmpresa)
                .OrderBy(trab => trab.FechaCierre)
                .ToList<TRABAJO>();
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
        /// funcion para cambiar el estado de un trabajo y de una oferta a activos
        /// o sea se convierten entrabajo
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        private bool cambiarEstadoTrabajo(int idTrabajo, string idEstudiante , string estado)
        {

            //Cambia el estado en la tabla de trabajo 
            TRABAJO lobj_trabajo = db.TRABAJO.Find(idTrabajo);
            lobj_trabajo.Estado = estado;
            //cambia el estado de la oferta de perndiente a aceptada
            TRABAJO_POR_ESTUDIANTE lobj_trabajo_por_estudiante = db.TRABAJO_POR_ESTUDIANTE.Find(idTrabajo,idEstudiante);
            lobj_trabajo_por_estudiante.Estado = estado;
            //modificar estado
            db.Entry(lobj_trabajo).State = EntityState.Modified;
            db.Entry(lobj_trabajo_por_estudiante).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRABAJOExists(idTrabajo) || !trabajoPorEstudianteExists(idTrabajo, idEstudiante))
                {   //si hay problema de concurrencia retorna falso
                    return false; 
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public bool convertirSubastaEnTrabajo(int idTrabajo, string idEstudiante)
        {

            //cambio el estado en trabajo y trabajo por estudiante
            if (cambiarEstadoTrabajo(idTrabajo, idEstudiante, "A") == false)
                return false;
            //rechazo las demás
            db.SP_Rechazar_Demas_Subastas(idTrabajo, idEstudiante);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!TRABAJOExists(idTrabajo) || !trabajoPorEstudianteExists(idTrabajo, idEstudiante))
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

        /// <summary>
        /// Termina un trabajo y le asiga estrellas
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <param name="idEstudiante"></param>
        /// <param name="estrellas"> las estrellas deben estar de cero a 5 (inclusive)</param>
        /// <returns>true si se completa o false si hay error</returns>
        public bool terminarTrabajo(int idTrabajo, string idEstudiante,byte estrellas)
        {
            TRABAJO lobj_trabajo = db.TRABAJO.Find(idTrabajo);
            if (lobj_trabajo == null)
            {
                return false;
            }
            if (estrellas<= 5 && estrellas >= 0)
                lobj_trabajo.EstrellasObtenidas = estrellas;
            else
                return false;

            db.Entry(lobj_trabajo).State = EntityState.Modified;

            //cambio el estado en trabajo y trabajo por estudiante a terminado
            if (cambiarEstadoTrabajo(idTrabajo, idEstudiante, "T") == false)
                return false;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!TRABAJOExists(idTrabajo) || !trabajoPorEstudianteExists(idTrabajo, idEstudiante))
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
        /// <summary>
        /// agrega una tecnologia a un trabajo
        /// </summary>
        /// <param name="tecnologia"></param>
        /// <returns></returns>
        public bool addTecnologiaToTrabajo(TECNOLOGIA_POR_TRABAJO tecnologia)
        {
            tecnologia.Estado = "A";
            db.TECNOLOGIA_POR_TRABAJO.Add(tecnologia);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (trabajoTecnologiaPorTrabajoExists(tecnologia.IdTecnologia,tecnologia.IdTrabajo))
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
        private bool trabajoPorEstudianteExists(int idTrabajo, string idEstudiante)
        {
            return db.TRABAJO_POR_ESTUDIANTE.Find(idTrabajo,idEstudiante) != null ;
        }
        private bool trabajoTecnologiaPorTrabajoExists(int idTecnologia, int idTrabajo)
        {
            return db.TECNOLOGIA_POR_TRABAJO.Find(idTecnologia,idTrabajo) != null;
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
            if (index * lby_offset > (li_largoLista-1))
                return lobj_resultado;
            //si index y el offset estan dentro del rango
            else if ((li_largoLista > (index * lby_offset + lby_offset -1 )))
                lobj_resultado = lista.GetRange(index * lby_offset , index * lby_offset + lby_offset);
            //si hay un overflow en el rango devuelve del indice hasta el fin de la lista
            else
                lobj_resultado = lista.GetRange(index * lby_offset , li_largoLista);

            return lobj_resultado;

        }


    }
}