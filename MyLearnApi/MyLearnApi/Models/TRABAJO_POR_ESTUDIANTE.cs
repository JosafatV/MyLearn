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
    
    public partial class TRABAJO_POR_ESTUDIANTE
    {
        public int IdTrabajo { get; set; }
        public string IdEstudiante { get; set; }
        public Nullable<int> Monto { get; set; }
        public Nullable<System.DateTime> FechaFinalizacion { get; set; }
        public string Comentario { get; set; }
        public string Estado { get; set; }
    }
}
