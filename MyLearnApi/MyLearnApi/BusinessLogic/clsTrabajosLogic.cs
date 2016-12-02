using System;
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
            return clsAlgoritmoPaginacion.paginar(listaTrabajos, index, 20);
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


        public List<TECNOLOGIA> getTecnologiasTrabajo(int idTrabajo)
        {
                    
            return db.SP_SelectTecnologiasPorTrabajo(idTrabajo).ToList<TECNOLOGIA>();
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
            return clsAlgoritmoPaginacion.paginar(listaTrabajos, index, 20);
        }

        /// <summary>
        /// obtiene un trabajo especifico buscado con el id
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <returns></returns>
        public VIEW_TRABAJO getSpecificTrabajo(int idTrabajo, string idEstudiante)
        {
            if (View_TRABAJOExists(idTrabajo,idEstudiante))
                return db.VIEW_TRABAJO.Find(idTrabajo, idEstudiante);
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
            //aun no es exitoso
            tRABAJO.Exitoso = false;
            tRABAJO.EstrellasObtenidas = 0;
            tRABAJO.FechaInicio = DateTime.Now;
            db.TRABAJO.Add(tRABAJO);
            db.SaveChanges();
            return tRABAJO;
        }

        /// <summary>
        /// Obtiene la informacion de un trabajo ingresada por el empleador
        /// </summary>
        /// <param name="tRABAJO"></param>
        /// <returns></returns>
        public TRABAJO getInfoTrabajo(int idTrabajo)
        {
            return db.TRABAJO.Find(idTrabajo);
        }

        /// <summary>
        /// crea un oferta relacionada a un trabajo y un estudiante
        /// </summary>
        /// <param name="oferta"></param>
        /// <returns></returns>
        public TRABAJO_POR_ESTUDIANTE crearOfertaSubasta(TRABAJO_POR_ESTUDIANTE oferta)
        {
            //comienza con estado pendiente
            oferta.Estado = "P";
            db.TRABAJO_POR_ESTUDIANTE.Add(oferta);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (trabajoPorEstudianteExists(oferta.IdTrabajo, oferta.IdEstudiante))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return oferta;
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
        /// <summary>
        /// cambia el estado de trabajo y trabajo por estudiante a activo y
        /// rechachaza las demás sumbastas (las demas trabajo por estudiante quedan en X)
        /// </summary>
        /// <param name="idTrabajo"></param>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
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
        public bool terminarTrabajo(int idTrabajo, string idEstudiante,byte estrellas,bool exitoso)
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
            lobj_trabajo.Exitoso = exitoso;
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
        /// busca una serie de trabajos filtrados por nombre y tecnologias
        /// </summary>
        /// <param name="nombreTecnologia"></param>
        /// <param name="nombreTrabajo"></param>
        /// <returns></returns>
        public List<TRABAJO> getTabajosPorTecnologiaYNombre(int IdTecnologia, string nombreTrabajo,string idEstudiante)
        {
            int numeroDeResultados = 20;
            /*return db.FiltrarSubastasPorTecnologiaYNombre(nombreTecnologia, nombreTrabajo, numeroDeResultados)
                //ordenar por fecha
                .OrderByDescending(t=> t.FechaInicio)
                .ToList<TRABAJO>();

            */

           return  db.TRABAJO.SqlQuery(
                "  SELECT DISTINCT TOP(" + numeroDeResultados+") TRABAJO.ID, TRABAJO.NOMBRE, TRABAJO.Descripcion, TRABAJO.IdEmpresa, TRABAJO.FechaInicio, TRABAJO.FechaCierre,"
                +" TRABAJO.DocumentoAdicional, TRABAJO.EstrellasObtenidas, TRABAJO.PresupuestoBase, TRABAJO.Estado, TRABAJO.Exitoso "
                +" FROM TRABAJO INNER JOIN TECNOLOGIA_POR_TRABAJO ON TRABAJO.Id = TECNOLOGIA_POR_TRABAJO.IdTrabajo "
                +" INNER JOIN TECNOLOGIA ON TECNOLOGIA.Id = TECNOLOGIA_POR_TRABAJO.IdTecnologia, TRABAJO_POR_ESTUDIANTE "
                +" WHERE ( TECNOLOGIA.Id =  '"+ IdTecnologia + "' OR TRABAJO.Nombre LIKE '%"+nombreTrabajo+"%' ) "
                +" AND Trabajo.Estado = 'P' AND NOT EXISTS"
                +" ( SELECT * FROM TRABAJO_POR_ESTUDIANTE WHERE TRABAJO.Id = TRABAJO_POR_ESTUDIANTE.IdTrabajo AND TRABAJO_POR_ESTUDIANTE.IdEstudiante = '"+idEstudiante+"') ")
                .ToList<TRABAJO>();
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
        private bool View_TRABAJOExists(int idTrabajo, string idEstudiante)
        {
            return db.VIEW_TRABAJO.Find(idTrabajo,idEstudiante) != null;
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



    }
}