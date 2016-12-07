using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;
using System.Data.Entity;

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


        /// <summary>
        /// Agrega una tecnologia a un proyecto
        /// </summary>
        /// <param name="tecnologia"></param>
        /// <returns></returns>
        public TECNOLOGIA_POR_PROYECTO agregarTecnologiaAProyecto(TECNOLOGIA_POR_PROYECTO tecnologia)
        {
            tecnologia.Estado = "A";
            db.TECNOLOGIA_POR_PROYECTO.Add(tecnologia);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TecnologiaPorProtectoExists(tecnologia.IdTecnologia, tecnologia.IdProyecto))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return tecnologia;
        }

        public VIEW_PROYECTOS getSpecificProyecto(int idProyecto)
        {
            return db.VIEW_PROYECTOS.Where(p=> p.IdProyecto == idProyecto).ToList<VIEW_PROYECTOS>().First<VIEW_PROYECTOS>();
        }

        /// <summary>
        /// obtiene las tecnologias de un proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        public List<TECNOLOGIA> getTecnologiaDeProyecto(int idProyecto)
        {
            return db.Sp_SelectTecnologiasDeProyecto(idProyecto).ToList<TECNOLOGIA>(); ;
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


            ESTUDIANTE_POR_CURSO lobj_estCurso = db.ESTUDIANTE_POR_CURSO.Find(proyect.IdEstudiante, proyect.IdCurso);
            lobj_estCurso.Estado = "A";
            db.Entry(lobj_estCurso).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyectoProEstudianteExists( proyect.IdProyecto,proyect.IdEstudiante))
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
        public List<SP_Select_Badge_Por_Proyecto_Result> getBadgesDeProyecto(int idProyecto)
        {
            //se busca mediante el estado obtenido O
            return db.selectBadgePorProyecto(idProyecto).Where(b=> b.Estado == "O" || b.Estado == "R").ToList<SP_Select_Badge_Por_Proyecto_Result>();
        }

        public List<BADGE> getBadgesDeProyectoNoOtorgados(int idCurso,int idProyecto)
        {
            //se busca mediante el estado obtenido O
            
            return db.SP_SelectBadgePorProyectoNoOtorgado(idCurso,idProyecto).ToList<BADGE>();
        }

        /// <summary>
        /// termina un proyecto y un proyecto por estudiante
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns></returns>
        public bool terminarProyecto(int idProyecto, string idEstudiante)
        {
            //cambia el estado de un proyecto a "T" y de un proyecto por estudiante
            db.SP_Terminar_Proyecto_De_Un_Estudiante(idProyecto, idEstudiante, "T");
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            { 
                if (!ProyectoExists(idProyecto) || !ProyectoProEstudianteExists(idProyecto,idEstudiante))
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
       
    



        private bool ProyectoExists(int idProyecto)
        {
            return db.PROYECTO.Find(idProyecto)!=null;
        }

        private bool ProyectoProEstudianteExists(int idProyecto, string idEstudiante)
        {
            return db.PROYECTO_POR_ESTUDIANTE.Find(idProyecto, idEstudiante) != null;
        }

        private bool BADGE_POR_PROYECTOExists(int idBadge, int idProyecto)
        {
            return db.BADGE_POR_PROYECTO.Find(idBadge,idProyecto) != null;
        }

        private bool TecnologiaPorProtectoExists(int idTecnologia, int idProyecto)
        {
            return db.TECNOLOGIA_POR_PROYECTO.Find(idTecnologia, idProyecto) != null;
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