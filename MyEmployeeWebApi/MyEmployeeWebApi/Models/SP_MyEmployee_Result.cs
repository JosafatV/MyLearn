//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyEmployeeWebApi.Models
{
    using System;
    using System.Runtime.Serialization;
    public partial class SP_MyEmployee_Result
    {
        [IgnoreDataMember]
        public string IdEstudiante { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        [IgnoreDataMember]
        public Nullable<double> Performance { get; set; }
    }
}
