﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyLearnApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MyLearnDBEntities : DbContext
    {
        public MyLearnDBEntities()
            : base("name=MyLearnDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ESTUDIANTE> ESTUDIANTE { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<IDIOMA> IDIOMA { get; set; }
        public virtual DbSet<VIEW_ESTUDIANTE> VIEW_ESTUDIANTE { get; set; }
        public virtual DbSet<IDIOMA_POR_ESTUDIANTE> IDIOMA_POR_ESTUDIANTE { get; set; }
    
        public virtual int sp_insert_estudiante(string id, string contrasena, string sal, string repositorioArchivos, string credencialDrive, string nombre, string apellido, string carne, string email, string telefono, string pais, string region, Nullable<System.DateTime> fechaInscripcion, string repositorioCodigo, string linkHojaDeVida)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            var salParameter = sal != null ?
                new ObjectParameter("Sal", sal) :
                new ObjectParameter("Sal", typeof(string));
    
            var repositorioArchivosParameter = repositorioArchivos != null ?
                new ObjectParameter("RepositorioArchivos", repositorioArchivos) :
                new ObjectParameter("RepositorioArchivos", typeof(string));
    
            var credencialDriveParameter = credencialDrive != null ?
                new ObjectParameter("CredencialDrive", credencialDrive) :
                new ObjectParameter("CredencialDrive", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var carneParameter = carne != null ?
                new ObjectParameter("Carne", carne) :
                new ObjectParameter("Carne", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var paisParameter = pais != null ?
                new ObjectParameter("Pais", pais) :
                new ObjectParameter("Pais", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var fechaInscripcionParameter = fechaInscripcion.HasValue ?
                new ObjectParameter("FechaInscripcion", fechaInscripcion) :
                new ObjectParameter("FechaInscripcion", typeof(System.DateTime));
    
            var repositorioCodigoParameter = repositorioCodigo != null ?
                new ObjectParameter("RepositorioCodigo", repositorioCodigo) :
                new ObjectParameter("RepositorioCodigo", typeof(string));
    
            var linkHojaDeVidaParameter = linkHojaDeVida != null ?
                new ObjectParameter("LinkHojaDeVida", linkHojaDeVida) :
                new ObjectParameter("LinkHojaDeVida", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insert_estudiante", idParameter, contrasenaParameter, salParameter, repositorioArchivosParameter, credencialDriveParameter, nombreParameter, apellidoParameter, carneParameter, emailParameter, telefonoParameter, paisParameter, regionParameter, fechaInscripcionParameter, repositorioCodigoParameter, linkHojaDeVidaParameter);
        }
    }
}
