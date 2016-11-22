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
        public virtual DbSet<IDIOMA_POR_ESTUDIANTE> IDIOMA_POR_ESTUDIANTE { get; set; }
        public virtual DbSet<VIEW_IDIOMA_POR_ESTUDIANTE> VIEW_IDIOMA_POR_ESTUDIANTE { get; set; }
        public virtual DbSet<VIEW_ESTUDIANTE> VIEW_ESTUDIANTE { get; set; }
        public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        public virtual DbSet<VIEW_EMPRESA> VIEW_EMPRESA { get; set; }
        public virtual DbSet<VIEW_PROFESOR> VIEW_PROFESOR { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<TECNOLOGIA> TECNOLOGIA { get; set; }
        public virtual DbSet<UNIVERSIDAD> UNIVERSIDAD { get; set; }
        public virtual DbSet<TECNOLOGIA_POR_ESTUDIANTE> TECNOLOGIA_POR_ESTUDIANTE { get; set; }
        public virtual DbSet<TRABAJO> TRABAJO { get; set; }
        public virtual DbSet<VIEW_TRABAJO> VIEW_TRABAJO { get; set; }
        public virtual DbSet<TRABAJO_POR_ESTUDIANTE> TRABAJO_POR_ESTUDIANTE { get; set; }
        public virtual DbSet<TECNOLOGIA_POR_PROYECTO> TECNOLOGIA_POR_PROYECTO { get; set; }
        public virtual DbSet<TECNOLOGIA_POR_TRABAJO> TECNOLOGIA_POR_TRABAJO { get; set; }
        public virtual DbSet<MENSAJE> MENSAJE { get; set; }
        public virtual DbSet<MENSAJE_POR_TRABAJO> MENSAJE_POR_TRABAJO { get; set; }
        public virtual DbSet<RESPUESTA> RESPUESTA { get; set; }
        public virtual DbSet<CURSO> CURSO { get; set; }
        public virtual DbSet<CURSO_POR_PROFESOR> CURSO_POR_PROFESOR { get; set; }
        public virtual DbSet<BADGE> BADGE { get; set; }
    
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
    
        public virtual int SP_Select_Cursos(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Select_Cursos", userIdParameter);
        }
    
        public virtual int SP_Insertar_Empresa(string id, string contrasena, string sal, string repositorioArchivos, string credencialDrive, string nombreContacto, string apellidoContacto, string nombreEmpresarial, string email, string telefono, string paginaWebEmpresa, string pais, string region, string repositorioCodigo)
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
    
            var nombreContactoParameter = nombreContacto != null ?
                new ObjectParameter("NombreContacto", nombreContacto) :
                new ObjectParameter("NombreContacto", typeof(string));
    
            var apellidoContactoParameter = apellidoContacto != null ?
                new ObjectParameter("ApellidoContacto", apellidoContacto) :
                new ObjectParameter("ApellidoContacto", typeof(string));
    
            var nombreEmpresarialParameter = nombreEmpresarial != null ?
                new ObjectParameter("NombreEmpresarial", nombreEmpresarial) :
                new ObjectParameter("NombreEmpresarial", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var paginaWebEmpresaParameter = paginaWebEmpresa != null ?
                new ObjectParameter("PaginaWebEmpresa", paginaWebEmpresa) :
                new ObjectParameter("PaginaWebEmpresa", typeof(string));
    
            var paisParameter = pais != null ?
                new ObjectParameter("Pais", pais) :
                new ObjectParameter("Pais", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var repositorioCodigoParameter = repositorioCodigo != null ?
                new ObjectParameter("RepositorioCodigo", repositorioCodigo) :
                new ObjectParameter("RepositorioCodigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Empresa", idParameter, contrasenaParameter, salParameter, repositorioArchivosParameter, credencialDriveParameter, nombreContactoParameter, apellidoContactoParameter, nombreEmpresarialParameter, emailParameter, telefonoParameter, paginaWebEmpresaParameter, paisParameter, regionParameter, repositorioCodigoParameter);
        }
    
        public virtual int SP_Insertar_Profesor(string id, string contrasena, string sal, string repositorioArchivos, string credencialDrive, string nombreContacto, string apellidoContacto, string email, string telefono, string horarioAtencion, string pais, string region, Nullable<int> idUniversidad)
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
    
            var nombreContactoParameter = nombreContacto != null ?
                new ObjectParameter("NombreContacto", nombreContacto) :
                new ObjectParameter("NombreContacto", typeof(string));
    
            var apellidoContactoParameter = apellidoContacto != null ?
                new ObjectParameter("ApellidoContacto", apellidoContacto) :
                new ObjectParameter("ApellidoContacto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var horarioAtencionParameter = horarioAtencion != null ?
                new ObjectParameter("HorarioAtencion", horarioAtencion) :
                new ObjectParameter("HorarioAtencion", typeof(string));
    
            var paisParameter = pais != null ?
                new ObjectParameter("Pais", pais) :
                new ObjectParameter("Pais", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var idUniversidadParameter = idUniversidad.HasValue ?
                new ObjectParameter("IdUniversidad", idUniversidad) :
                new ObjectParameter("IdUniversidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Profesor", idParameter, contrasenaParameter, salParameter, repositorioArchivosParameter, credencialDriveParameter, nombreContactoParameter, apellidoContactoParameter, emailParameter, telefonoParameter, horarioAtencionParameter, paisParameter, regionParameter, idUniversidadParameter);
        }
    
        public virtual int SP_Insertar_Estudiante(string id, string contrasena, string sal, string repositorioArchivos, string credencialDrive, string nombre, string apellido, string carne, string email, string telefono, string pais, string region, Nullable<int> idUniversidad, string repositorioCodigo, string linkHojaDeVida)
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
    
            var idUniversidadParameter = idUniversidad.HasValue ?
                new ObjectParameter("IdUniversidad", idUniversidad) :
                new ObjectParameter("IdUniversidad", typeof(int));
    
            var repositorioCodigoParameter = repositorioCodigo != null ?
                new ObjectParameter("RepositorioCodigo", repositorioCodigo) :
                new ObjectParameter("RepositorioCodigo", typeof(string));
    
            var linkHojaDeVidaParameter = linkHojaDeVida != null ?
                new ObjectParameter("LinkHojaDeVida", linkHojaDeVida) :
                new ObjectParameter("LinkHojaDeVida", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Estudiante", idParameter, contrasenaParameter, salParameter, repositorioArchivosParameter, credencialDriveParameter, nombreParameter, apellidoParameter, carneParameter, emailParameter, telefonoParameter, paisParameter, regionParameter, idUniversidadParameter, repositorioCodigoParameter, linkHojaDeVidaParameter);
        }
    
        public virtual int SP_Insertar_Trabajo(string nombre, string descripcion, string idEmpresa, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaCierre, string documentoAdicional, Nullable<double> presupuesto)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var idEmpresaParameter = idEmpresa != null ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(string));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var fechaCierreParameter = fechaCierre.HasValue ?
                new ObjectParameter("FechaCierre", fechaCierre) :
                new ObjectParameter("FechaCierre", typeof(System.DateTime));
    
            var documentoAdicionalParameter = documentoAdicional != null ?
                new ObjectParameter("DocumentoAdicional", documentoAdicional) :
                new ObjectParameter("DocumentoAdicional", typeof(string));
    
            var presupuestoParameter = presupuesto.HasValue ?
                new ObjectParameter("presupuesto", presupuesto) :
                new ObjectParameter("presupuesto", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Trabajo", nombreParameter, descripcionParameter, idEmpresaParameter, fechaInicioParameter, fechaCierreParameter, documentoAdicionalParameter, presupuestoParameter);
        }
    
        public virtual int SP_Aceptar_Subasta(Nullable<int> idSubasta, string idEstudiante)
        {
            var idSubastaParameter = idSubasta.HasValue ?
                new ObjectParameter("IdSubasta", idSubasta) :
                new ObjectParameter("IdSubasta", typeof(int));
    
            var idEstudianteParameter = idEstudiante != null ?
                new ObjectParameter("IdEstudiante", idEstudiante) :
                new ObjectParameter("IdEstudiante", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Aceptar_Subasta", idSubastaParameter, idEstudianteParameter);
        }
    
        public virtual int SP_Rechazar_Demas_Subastas(Nullable<int> idSubasta, string idEstudiante)
        {
            var idSubastaParameter = idSubasta.HasValue ?
                new ObjectParameter("IdSubasta", idSubasta) :
                new ObjectParameter("IdSubasta", typeof(int));
    
            var idEstudianteParameter = idEstudiante != null ?
                new ObjectParameter("IdEstudiante", idEstudiante) :
                new ObjectParameter("IdEstudiante", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Rechazar_Demas_Subastas", idSubastaParameter, idEstudianteParameter);
        }
    
        public virtual int SP_Insertar_Mensaje_Trabajo(string contenido, string adjunto, Nullable<int> idTrabajo, string nombreEmisor)
        {
            var contenidoParameter = contenido != null ?
                new ObjectParameter("Contenido", contenido) :
                new ObjectParameter("Contenido", typeof(string));
    
            var adjuntoParameter = adjunto != null ?
                new ObjectParameter("Adjunto", adjunto) :
                new ObjectParameter("Adjunto", typeof(string));
    
            var idTrabajoParameter = idTrabajo.HasValue ?
                new ObjectParameter("IdTrabajo", idTrabajo) :
                new ObjectParameter("IdTrabajo", typeof(int));
    
            var nombreEmisorParameter = nombreEmisor != null ?
                new ObjectParameter("NombreEmisor", nombreEmisor) :
                new ObjectParameter("NombreEmisor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Mensaje_Trabajo", contenidoParameter, adjuntoParameter, idTrabajoParameter, nombreEmisorParameter);
        }
    
        public virtual int SP_Insertar_Respuesta(Nullable<long> mensajeRaiz, string contenido, string adjunto, string nombreEmisor)
        {
            var mensajeRaizParameter = mensajeRaiz.HasValue ?
                new ObjectParameter("MensajeRaiz", mensajeRaiz) :
                new ObjectParameter("MensajeRaiz", typeof(long));
    
            var contenidoParameter = contenido != null ?
                new ObjectParameter("Contenido", contenido) :
                new ObjectParameter("Contenido", typeof(string));
    
            var adjuntoParameter = adjunto != null ?
                new ObjectParameter("Adjunto", adjunto) :
                new ObjectParameter("Adjunto", typeof(string));
    
            var nombreEmisorParameter = nombreEmisor != null ?
                new ObjectParameter("NombreEmisor", nombreEmisor) :
                new ObjectParameter("NombreEmisor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Respuesta", mensajeRaizParameter, contenidoParameter, adjuntoParameter, nombreEmisorParameter);
        }
    
        public virtual int SP_Insertar_Curso(string idProfesor, string nombre, string codigo, Nullable<int> idUniversidad, Nullable<byte> notaMinima, Nullable<System.DateTime> fechaInicio, Nullable<int> numeroGrupo)
        {
            var idProfesorParameter = idProfesor != null ?
                new ObjectParameter("IdProfesor", idProfesor) :
                new ObjectParameter("IdProfesor", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var idUniversidadParameter = idUniversidad.HasValue ?
                new ObjectParameter("IdUniversidad", idUniversidad) :
                new ObjectParameter("IdUniversidad", typeof(int));
    
            var notaMinimaParameter = notaMinima.HasValue ?
                new ObjectParameter("NotaMinima", notaMinima) :
                new ObjectParameter("NotaMinima", typeof(byte));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var numeroGrupoParameter = numeroGrupo.HasValue ?
                new ObjectParameter("NumeroGrupo", numeroGrupo) :
                new ObjectParameter("NumeroGrupo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insertar_Curso", idProfesorParameter, nombreParameter, codigoParameter, idUniversidadParameter, notaMinimaParameter, fechaInicioParameter, numeroGrupoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Sp_InsertarCurso(string idProfesor, string nombre, string codigo, Nullable<int> idUniversidad, Nullable<byte> notaMinima, Nullable<System.DateTime> fechaInicio, Nullable<int> numeroGrupo)
        {
            var idProfesorParameter = idProfesor != null ?
                new ObjectParameter("IdProfesor", idProfesor) :
                new ObjectParameter("IdProfesor", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            var idUniversidadParameter = idUniversidad.HasValue ?
                new ObjectParameter("IdUniversidad", idUniversidad) :
                new ObjectParameter("IdUniversidad", typeof(int));
    
            var notaMinimaParameter = notaMinima.HasValue ?
                new ObjectParameter("NotaMinima", notaMinima) :
                new ObjectParameter("NotaMinima", typeof(byte));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var numeroGrupoParameter = numeroGrupo.HasValue ?
                new ObjectParameter("NumeroGrupo", numeroGrupo) :
                new ObjectParameter("NumeroGrupo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Sp_InsertarCurso", idProfesorParameter, nombreParameter, codigoParameter, idUniversidadParameter, notaMinimaParameter, fechaInicioParameter, numeroGrupoParameter);
        }
    
        public virtual ObjectResult<SP_select_tecnologias_por_trabajo_Result> SP_select_tecnologias_por_trabajo(Nullable<int> idTrabajo)
        {
            var idTrabajoParameter = idTrabajo.HasValue ?
                new ObjectParameter("IdTrabajo", idTrabajo) :
                new ObjectParameter("IdTrabajo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_select_tecnologias_por_trabajo_Result>("SP_select_tecnologias_por_trabajo", idTrabajoParameter);
        }
    
        public virtual ObjectResult<TECNOLOGIA> SP_SelectTecnologiasPorTrabajo(Nullable<int> idTrabajo)
        {
            var idTrabajoParameter = idTrabajo.HasValue ?
                new ObjectParameter("IdTrabajo", idTrabajo) :
                new ObjectParameter("IdTrabajo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TECNOLOGIA>("SP_SelectTecnologiasPorTrabajo", idTrabajoParameter);
        }
    
        public virtual ObjectResult<TECNOLOGIA> SP_SelectTecnologiasPorTrabajo(Nullable<int> idTrabajo, MergeOption mergeOption)
        {
            var idTrabajoParameter = idTrabajo.HasValue ?
                new ObjectParameter("IdTrabajo", idTrabajo) :
                new ObjectParameter("IdTrabajo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TECNOLOGIA>("SP_SelectTecnologiasPorTrabajo", mergeOption, idTrabajoParameter);
        }
    }
}
