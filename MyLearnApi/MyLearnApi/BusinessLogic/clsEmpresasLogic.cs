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
    public class clsEmpresasLogic
    {   
        //
        private MyLearnDBEntities db = new MyLearnDBEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<VIEW_EMPRESA> getAllEmpresas()
        {
            return db.VIEW_EMPRESA.Where(emp => emp.Estado != "E").ToList<VIEW_EMPRESA>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VIEW_EMPRESA getSpecificEmpresa(string id)
        {
            VIEW_EMPRESA vIEW_EMPRESA = db.VIEW_EMPRESA.Find(id);
      
            return vIEW_EMPRESA;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public bool postEmpresa(VIEW_EMPRESA empresa)
        {
            
            VIEW_EMPRESA lobj_v = empresa;
            db.SP_Insertar_Empresa(lobj_v.Id, lobj_v.Contrasena, lobj_v.Sal, lobj_v.RepositorioArchivos, lobj_v.CredencialDrive,
                lobj_v.NombreContacto, lobj_v.ApellidoContacto, lobj_v.NombreEmpresarial, lobj_v.Email, lobj_v.Telefono,
                lobj_v.FechaInscripcion, lobj_v.PaginaWebEmpresa, lobj_v.Pais, lobj_v.Region, lobj_v.RepositorioArchivos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VIEW_EMPRESAExists(empresa.Id))
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
        private bool VIEW_EMPRESAExists(string id)
        {
            return db.VIEW_EMPRESA.Count(e => e.Id == id) > 0;
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
    }
}