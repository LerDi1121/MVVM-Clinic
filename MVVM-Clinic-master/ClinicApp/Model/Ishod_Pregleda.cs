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
    
    public partial class Ishod_Pregleda
    {
        public Ishod_Pregleda(string naziv, string opis, int doktor_pregled_Pacijent_PacijentPacijent_Id)
        {
            Naziv = naziv;
            Opis = opis;
            Doktor_pregled_Pacijent_PacijentPacijent_Id = doktor_pregled_Pacijent_PacijentPacijent_Id;
        }
        public int Ishod_Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Doktor_pregled_Pacijent_PacijentPacijent_Id { get; set; }
    
        public virtual Ishod_Pregleda_Dijagnoza Ishod_Pregleda_Dijagnoza { get; set; }
        public virtual Ishod_Pregleda_Uput Ishod_Pregleda_Uput { get; set; }
        public virtual Doktor_op_pr_Pregled_Pacijent Doktor_op_pr_Pregled_Pacijent { get; set; }
    }
}
