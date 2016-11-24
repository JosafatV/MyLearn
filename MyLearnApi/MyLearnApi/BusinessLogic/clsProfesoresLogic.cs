using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyLearnApi.Models;
using MyLearnApi.BusinessLogic.UserAccounts;


namespace MyLearnApi.BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class clsProfesoresLogic
    {
        //
        private MyLearnDBEntities db = new MyLearnDBEntities();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<VIEW_PROFESOR> getAllProfesores()
        {
            return db.VIEW_PROFESOR.ToList<VIEW_PROFESOR>();
        }

        public VIEW_PROFESOR getSpecificProfesor(string id)
        {
            VIEW_PROFESOR vIEW_PROFESOR = db.VIEW_PROFESOR.Find(id);
            return vIEW_PROFESOR;
        }

        public bool insertProfesor(VIEW_PROFESOR vIEW_PROFESOR)
        {
            //se autogenera un id
            clsIncrementalIdGenerator lobj_generator = new clsIncrementalIdGenerator();
            vIEW_PROFESOR.Id = lobj_generator.generateUserId();
 
            //se inserta mediante un procedimiento almacenaado
            db.SP_Insertar_Profesor(vIEW_PROFESOR.Id, vIEW_PROFESOR.Contrasena, vIEW_PROFESOR.Sal, 
                vIEW_PROFESOR.RepositorioArchivos, vIEW_PROFESOR.CredencialDrive,
                vIEW_PROFESOR.NombreContacto, vIEW_PROFESOR.ApellidoContacto, vIEW_PROFESOR.Email,
                vIEW_PROFESOR.Telefono,
                vIEW_PROFESOR.HorarioAtencion, vIEW_PROFESOR.Pais, vIEW_PROFESOR.Region, 
                vIEW_PROFESOR.IdUniversidad, vIEW_PROFESOR.NombreDeUsuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VIEW_PROFESORExists(vIEW_PROFESOR.Id))
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


        private bool VIEW_PROFESORExists(string id)
        {
            return db.VIEW_PROFESOR.Count(e => e.Id == id) > 0;
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