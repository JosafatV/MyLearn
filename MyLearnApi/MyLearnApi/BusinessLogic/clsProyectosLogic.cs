using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    public class clsProyectosLogic
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        public List<VIEW_PROYECTOS> getProyectosDeCurso(int idCurso)
        {
            return db.VIEW_PROYECTOS.Where(p => p.IdCurso == idCurso).ToList<VIEW_PROYECTOS>();
        }


        public VIEW_PROYECTOS getSpecificProyecto(string idProyecto)
        {
            return db.VIEW_PROYECTOS.Find(idProyecto);
        }


        public VIEW_PROYECTOS PostVIEW_PROYECTOS(VIEW_PROYECTOS proyect)
        {
           
            proyect.IdProyecto = db.SP_InsertarPropuestaProyecto(
                proyect.IdEstudiante,
                proyect.NombreProyecto,
                proyect.Problematica,
                proyect.Descripcion,
                proyect.IdCurso,
                proyect.FechaInicio,
                proyect.FechaFinal,
                proyect.DocumentoAdicional,
                //proyecto comienza como activo
                "A",
                //incia la nota con un cero                       
                0
            ).SingleOrDefault().Value;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VIEW_PROYECTOSExists(proyect.IdEstudiante, proyect.IdProyecto))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return proyect;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
           
        }


        /// <summary>
        /// otorga un badge a un proyecto
        /// </summary>
        /// <param name="badge"></param>
        /// <returns></returns>
        public BADGE_POR_PROYECTO otorgarBadge(BADGE_POR_PROYECTO badge)
        {
            //estado de obtenido
            badge.Estado = "O"; 
            db.BADGE_POR_PROYECTO.Add(badge);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BADGE_POR_PROYECTOExists(badge.IdBadge, badge.IdProyecto))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return badge;
        }

        /// <summary>
        /// obtiene los badges de un proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        public List<BADGE> getBadgesDeProyecto(int idProyecto)
        {
            return db.SP_SelectBadgePorProyecto(idProyecto).ToList<BADGE>();
        }

        private bool VIEW_PROYECTOSExists(string idEstudiante, int idProyecto)
        {
            return db.VIEW_PROYECTOS.Find(idEstudiante, idProyecto) != null;
        }

        private bool BADGE_POR_PROYECTOExists(int idBadge, int idProyecto)
        {
            return db.BADGE_POR_PROYECTO.Find(idBadge,idProyecto) != null;
        }


    }

}