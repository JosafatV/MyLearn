//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class VIEW_PROYECTOS
    {
        public string IdEstudiante { get; set; }
        public string IdProfesor { get; set; }
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string Problematica { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdCurso { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFinal { get; set; }
        public string DocumentoAdicional { get; set; }
        public Nullable<byte> NotaObtenida { get; set; }
        public string EstadoProyecto { get; set; }
        public string NOMBRE_EST { get; set; }
        public string APELLIDO_EST { get; set; }
    }
}
