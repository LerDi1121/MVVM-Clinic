//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ugovor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ugovor()
        {
            this.Doktor_Departman = new HashSet<Doktor_Departman>();
        }
    
        public int Ugovor_Id { get; set; }
        public string Vrsta_Ugovora { get; set; }
        public System.DateTime Datum_Vazenja { get; set; }
        public bool Specijalizacija { get; set; }
        public string Doktor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doktor_Departman> Doktor_Departman { get; set; }
    }
}
