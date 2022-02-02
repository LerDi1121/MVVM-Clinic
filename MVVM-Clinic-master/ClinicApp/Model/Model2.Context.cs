﻿
namespace ConsoleApp2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class ClinicDBEntities : DbContext
    {
        public ClinicDBEntities()
            : base("name=ClinicDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Klinika> Klinikas { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<Termin> Termins { get; set; }
        public DbSet<Pregled> Pregleds { get; set; }
        public DbSet<Ishod_Pregleda> Ishod_Pregleda { get; set; }
        public DbSet<Terapija> Terapijas { get; set; }
        public DbSet<Pregled_Specijaliste> Pregled_Specijaliste { get; set; }
        public DbSet<Termin_Specijaliste> Termin_Specijaliste { get; set; }
    
        [EdmFunction("ClinicDBEntities", "GetAllDepartments")]
        public virtual IQueryable<GetAllDepartments_Result> GetAllDepartments()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetAllDepartments_Result>("[ClinicDBEntities].[GetAllDepartments]()");
        }
    
        public virtual int BrojacDnevnihPregledaZaDoktora(Nullable<int> doctorId, string date, ObjectParameter count)
        {
            var doctorIdParameter = doctorId.HasValue ?
                new ObjectParameter("doctorId", doctorId) :
                new ObjectParameter("doctorId", typeof(int));
    
            var dateParameter = date != null ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BrojacDnevnihPregledaZaDoktora", doctorIdParameter, dateParameter, count);
        }
    }
}
