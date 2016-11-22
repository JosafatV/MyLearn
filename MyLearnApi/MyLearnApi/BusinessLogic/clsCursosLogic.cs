using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    /// <summary>
    /// clase que maneja la lógica delos cursos
    /// </summary>
    public class clsCursosLogic
    {
        //objeto de acceso a la base de datos
        private MyLearnDBEntities db = new MyLearnDBEntities();

        /// <summary>
        /// obtiene los cursos que imparte un profesor
        /// </summary>
        /// <param name="idProfesor"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<CURSO_POR_PROFESOR> getCursosDeProfesor(string idProfesor, int index)
        {
            List<CURSO_POR_PROFESOR> lobj_list = db.CURSO_POR_PROFESOR.
                Where(curso => curso.IdProfesor == idProfesor && (curso.CURSO.Estado== "A" || curso.CURSO.Estado == "T"))
                .ToList<CURSO_POR_PROFESOR>();
            return clsAlgoritmoPaginacion.paginar(lobj_list, index, 20);
        }

        /// <summary>
        /// crea un nuevo curso
        /// </summary>
        /// <param name="Curso"></param>
        /// <returns></returns>
        public clsCursoSpModel PostCURSO_POR_PROFESOR(clsCursoSpModel Curso)
        {
            Curso.idCurso = db.Sp_InsertarCurso(Curso.IdProfesor, Curso.Nombre, Curso.Codigo, Curso.IdUniversidad,
                Curso.NotaMinima, Curso.FechaInicio, Curso.NumeroGrupo).SingleOrDefault().Value;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return Curso;
        }

        /// <summary>
        ///         disposer
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            
        }
        /// <summary>
        /// revisa si el curso existe mediante el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CURSO_POR_PROFESORExists(int id)
        {
            return db.CURSO_POR_PROFESOR.Count(e => e.IdCurso == id) > 0;
        }
        
        /// <summary>
        /// obtiene los badges de un curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public List<BADGE> getBadgePorCurso(int idCurso)
        {
            return db.BADGE.Where(b=> b.IdCurso == idCurso).ToList<BADGE>();
        }

        /// <summary>
        /// iinserta in badge en la base de datos
        /// </summary>
        /// <param name="badge"></param>
        /// <returns></returns>
        public List<BADGE> insertBadge(List<BADGE> badges)
        {
            for (int i = 0; i < badges.Count; i++)
            {
                db.BADGE.Add(badges[i]);
                db.SaveChanges();
            }
            

            return badges;
        }

        /// <summary>
        /// funcion que verifica que la suma de la puntaje de los badges sea 100
        /// </summary>
        /// <param name="badges"></param>
        /// <returns></returns>
        public bool isTotalPuntajeValido(List<BADGE> badges)
        {
            int? lby_nota_total = 0;
            for (int i = 0; i < badges.Count; i++)
            {
                lby_nota_total = lby_nota_total +  badges[i].Puntaje;
            }
            if (lby_nota_total == 100)
                return true;
            else
                return false;
        }

    }
}