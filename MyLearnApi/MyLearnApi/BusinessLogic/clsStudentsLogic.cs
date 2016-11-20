using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;

namespace MyLearnApi.BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class clsStudentsLogic
    {
        //
        private MyLearnDBEntities db = new MyLearnDBEntities();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<VIEW_ESTUDIANTE> GetAllEstudiantes()
        {
            return db.VIEW_ESTUDIANTE.Where(est => est.Estado != "E").ToList<VIEW_ESTUDIANTE>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VIEW_ESTUDIANTE getSpecificStudent(string id)
        {
            VIEW_ESTUDIANTE eSTUDIANTE = db.VIEW_ESTUDIANTE.Find(id);
            return eSTUDIANTE;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        public List<VIEW_IDIOMA_POR_ESTUDIANTE> GetIdiomasPorEstudiante(string idEstudiante)
        {
            return db.VIEW_IDIOMA_POR_ESTUDIANTE.Where(idiom => idiom.IdEstudiante != idEstudiante).ToList<VIEW_IDIOMA_POR_ESTUDIANTE>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public bool doStudentInsertion(VIEW_ESTUDIANTE estudiante)
        {
            db.SP_Insertar_Estudiante(estudiante.Id, estudiante.Contrasena, estudiante.Sal, estudiante.RepositorioArchivos, estudiante.CredencialDrive,
                estudiante.NombreContacto, estudiante.ApellidoContacto, estudiante.Carne, estudiante.Email, estudiante.Telefono, estudiante.Pais, estudiante.Region,
                 estudiante.RepositorioCodigo, estudiante.LinkHojaDeVida);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ESTUDIANTEExists(estudiante.Id))
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public USUARIO DeleteEstudiante(int id)
        {
            USUARIO estudiante = db.USUARIO.Find(id);

            estudiante.Estado = "E"; //se pone E de eliminado
            db.Entry(estudiante).State = EntityState.Modified;

            if (estudiante == null)
            {
                return null;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return estudiante;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        public void dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ESTUDIANTEExists(string id)
        {
            return db.VIEW_ESTUDIANTE.Count(e => e.Id == id) > 0;
        }
    }
}