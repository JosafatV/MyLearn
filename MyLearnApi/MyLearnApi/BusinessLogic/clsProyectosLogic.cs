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

        public List<VIEW_PROYECTOS> getProyectosDeEstudiante(string idEstudiante)
        {
            return db.VIEW_PROYECTOS.Where(p =>  p.IdEstudiante == idEstudiante &&
                (p.EstadoProyecto == "A" || p.EstadoProyecto == "T"))
                .ToList<VIEW_PROYECTOS>();
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
        /// otorga un badge a un proyecto y se lo suma a la nota del proyecto y curso
        /// </summary>
        /// <param name="badge"></param>
        /// <returns></returns>
        public BADGE_POR_PROYECTO otorgarBadge(BADGE_POR_PROYECTO badge)
        {
            //estado de obtenido
            badge.Estado = "O"; 
            //se inserta un nuevo badge a un proyecto
            db.BADGE_POR_PROYECTO.Add(badge);
            //se incrementa la nota del proyecto con el puntaje del badge insertardo
            db.SP_Incrementar_Puntaje_Proyecto(badge.IdBadge, badge.IdProyecto);
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
            //se busca mediante el estado obtenido O
            string lstr_Estado = "O";
            return db.SP_SelectBadgePorProyecto(idProyecto, lstr_Estado).ToList<BADGE>();
        }

        public List<BADGE> getBadgesDeProyectoNoOtorgados(int idCurso,int idProyecto)
        {
            //se busca mediante el estado obtenido O
            
            return db.SP_SelectBadgePorProyectoNoOtorgado(idCurso,idProyecto).ToList<BADGE>();
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