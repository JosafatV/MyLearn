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
    
    public partial class MENSAJE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENSAJE()
        {
            this.RESPUESTA = new HashSet<RESPUESTA>();
        }
    
        public long Id { get; set; }
        public string Contenido { get; set; }
        public string Adjunto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string NombreEmisor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESPUESTA> RESPUESTA { get; set; }
    }
}
