using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.Core
{
    public class DbContextHandler
    {
        private static DbContextHandler instance;

        public static DbContextHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbContextHandler();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }

        #region Departman
        public List<string> GetAllDepartmentsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        select departman.Naziv).ToList();
            }             
        }

        public int GetDeparmentIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        where departman.Naziv == name
                        select departman.Departman_Id).First();
            }
        }
        #endregion
        #region CRUD DOKTOR

        // C-Create
        public void CreateDoctor(string ime, string prezime, string specijalizacija, int klinika_Id, int departman_Id, string kontakt)
        {
            Doktor doktor = new Doktor(ime, prezime, specijalizacija, klinika_Id, departman_Id, kontakt, 0);
            using (var db = new ClinicDBEntities())
            {
                db.Doktors.Add(doktor);
                db.SaveChanges();
            }
        }
        // R-Read
        public List<Doktor> GetAllDoctors()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Doktors
                        select doktor).ToList();
            }
        }
        // U = UPDATE
        public void UpdateDoctor(int doctorId, string ime, string prezime, string specijalizacija, int klinika_Id, int departman_Id, string kontakt)
        {
            Doktor doktor;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                doktor = db.Doktors.Where(x => x.Doktor_Id == doctorId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!doktor.Ime.Equals(ime))
            {
                doktor.Ime = ime;
                haveChanges = true;
            }

            if (!doktor.Prezime.Equals(prezime))
            {
                doktor.Prezime = prezime;
                haveChanges = true;
            }

            if (!doktor.Specijalizacija.Equals(specijalizacija))
            {
                doktor.Specijalizacija = specijalizacija;
                haveChanges = true;
            }

            if (!doktor.Klinika_Id.Equals(klinika_Id))
            {
                doktor.Klinika_Id = klinika_Id;
                haveChanges = true;
            }

            if (!doktor.Departman_Id.Equals(departman_Id))
            {
                doktor.Departman_Id = departman_Id;
                haveChanges = true;
            }

            if (!doktor.Kontakt.Equals(kontakt))
            {
                doktor.Kontakt = kontakt;
                haveChanges = true;
            }

            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(doktor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // D-Delete
        public void DeleteDoctorById(int doctorId)
        {          
            Doktor doktor;

            using (var db = new ClinicDBEntities())
            {
                doktor = db.Doktors.Where(x => x.Doktor_Id == doctorId).FirstOrDefault();
                db.Entry(doktor).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }         
        }
        #endregion

        #region CRUD PATIENT

        // C = CREATE
        public void CreatePatient(string ime, string prezime, string kontakt, string adresa)
        {
            Pacijent pacijent = new Pacijent(ime, prezime, kontakt, adresa);
            using (var db = new ClinicDBEntities())
            {
                db.Pacijents.Add(pacijent);
                db.SaveChanges();
            }
        }

        // R = Read
        public List<Pacijent> GetAllPatients()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Pacijents
                        select pacijent).ToList();
            }
        }
        // U = UPDATE
        public void UpdatePatient(int patientId, string ime, string prezime, string kontakt, string adresa)
        {
            Pacijent pacijent;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                pacijent = db.Pacijents.Where(x => x.Pacijent_Id == patientId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!pacijent.Ime.Equals(ime))
            {
                pacijent.Ime = ime;
                haveChanges = true;
            }

            if (!pacijent.Prezime.Equals(prezime))
            {
                pacijent.Prezime = prezime;
                haveChanges = true;
            }
            if (!pacijent.Kontakt.Equals(kontakt))
            {
                pacijent.Kontakt = kontakt;
                haveChanges = true;
            }

            if (!pacijent.Adresa.Equals(adresa))
            {
                pacijent.Adresa = adresa;
                haveChanges = true;
            }
         
            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(pacijent).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }


        // D = Delete
        public void DeletePatientById(int patientId)
        {
            Pacijent pacijent;

            using (var db = new ClinicDBEntities())
            {
                pacijent = db.Pacijents.Where(x => x.Pacijent_Id == patientId).FirstOrDefault();
                db.Entry(pacijent).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion

        #region Clinic
        public List<string> GetAllClinicsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from klinika in db.Klinikas
                        select klinika.Naziv).ToList();
            }
        }

        public int GetClinicIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from klinika in db.Klinikas
                        where klinika.Naziv == name
                        select klinika.Klinika_Id).First();
            }
        }
        #endregion
        #region CRUD DEPARTMENT

        // C = Create
        public void CreateDepartment(string naziv, string sprat, int clinicId)
        {
            // dodavanje u tabelu departman
            Departman departman = new Departman(naziv, sprat);
            using (var db = new ClinicDBEntities())
            {
                db.Departmen.Add(departman);
                db.SaveChanges();
            }

            // dodavanje u medjutabelu
            Klinika_Departman kd = new Klinika_Departman()
            {
                KlinikaKlinika_Id = clinicId,
                DepartmanDepartman_Id = departman.Departman_Id
            };

            using (var db = new ClinicDBEntities())
            {
                db.Klinika_Departman.Add(kd);
                db.SaveChanges();
            }
        }

        // R = Read
        public List<GetAllDepartments_Result> GetAllDepartments()
        {
            //using (var db = new ClinicDBEntities())
            //{
            //    return (from departman in db.Departmen
            //            select departman).ToList();
            //}

            //using (var db = new ClinicDBEntities())
            //{
            //    return (from departman in db.Departmen
            //            from clinic in db.Klinikas
            //            from kd in db.Klinika_Departman
            //            where departman.Departman_Id == kd.DepartmanDepartman_Id && clinic.Klinika_Id == kd.KlinikaKlinika_Id
            //            select new ExtendedDepartment { Name = departman.Naziv, Floor = departman.Sprat, DepartmanId = departman.Departman_Id, ClinicName = clinic.Naziv}).ToList();
            //}

            // funkcija
            using (var db = new ClinicDBEntities())
            {
                return db.GetAllDepartments().ToList();
            }
        }
    
        // za update 
        public string GetDepartmentNameById(int departmentId)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        where departman.Departman_Id == departmentId
                        select departman.Naziv).FirstOrDefault();
            }
        }

        // U = Update
        public void UpdateDepartment(int departmanId, string naziv, string sprat)
        {
            Departman departman;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                departman = db.Departmen.Where(x => x.Departman_Id == departmanId).FirstOrDefault();
            }
          
            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!departman.Naziv.Equals(naziv))
            {
                departman.Naziv = naziv;
                haveChanges = true;
            }

            if (!departman.Sprat.Equals(sprat))
            {
                departman.Sprat = sprat;
                haveChanges = true;
            }

            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(departman).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        // da li doktor radi na nekom departmanu
        public List<int> GetAllDepartmentIds()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Doktors
                        select doktor.Departman_Id).ToList();
            }
        }

        // D-Delete
        public bool DeleteDepartmentById(int departmentId)
        {
            using (var db = new ClinicDBEntities())
            {
                List<int> departmentIds = GetAllDepartmentIds();

                if (departmentIds.Contains(departmentId))
                {
                    MessageBox.Show("Ne mozete obrisati departman dok god na njemu rade neki doktori!");
                    return false;
                }
                else
                {
                    try
                    {
                        // trigger
                        Klinika_Departman departmanKlinika = db.Klinika_Departman.Where(x => x.DepartmanDepartman_Id == departmentId).FirstOrDefault();
                        db.Entry(departmanKlinika).State = System.Data.Entity.EntityState.Deleted;
                        //departman = db.Departmen.Where(x => x.Departman_Id == departmentId).FirstOrDefault();
                        //db.Entry(departman).State = System.Data.Entity.EntityState.Deleted;                      
                        db.SaveChanges();
                        return true;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Ne mozete obrisati departman dok god na njemu rade neki doktori / \nleze neki pacijenti!");
                        return false;
                    }              
                }             
            }
        }
        #endregion

        #region Patient
        public List<string> GetAllPatientsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Pacijents
                        select pacijent.Ime).ToList();
            }
        }

        public int GetPatientIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Pacijents
                        where pacijent.Ime == name
                        select pacijent.Pacijent_Id).First();
            }
        }
        #endregion
        #region Doctor
        public List<string> GetAllDoctorsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Doktors
                        select doktor.Ime).ToList();
            }
        }

        public int GetDoctorIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Doktors
                        where doktor.Ime == name
                        select doktor.Doktor_Id).First();
            }
        }
        #endregion
        #region CRUD DIAGNOSIS

        // C = CREATE
        public void CreateDiagnozis(string naziv, string opis)
        {
            Dijagnoza_Specijaliste dijagnoza = new Dijagnoza_Specijaliste(naziv, opis);
            using (var db = new ClinicDBEntities())
            {
                db.Dijagnoza_Specijaliste.Add(dijagnoza);
                db.SaveChanges();
            }
        }
        public List<Dijagnoza_Specijaliste> GetAllDiagnozis()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from dijagnoza in db.Dijagnoza_Specijaliste
                        select dijagnoza).ToList();
            }
        }
        // U = UPDATE
        public void UpdateDiagnosis(int dijagnozaId, string naziv, string opis)
        {
            Dijagnoza_Specijaliste dijagnoza;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                dijagnoza = db.Dijagnoza_Specijaliste.Where(x => x.Dijagnoza_Id == dijagnozaId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!dijagnoza.Naziv.Equals(naziv))
            {
                dijagnoza.Naziv = naziv;
                haveChanges = true;
            }

            if (!dijagnoza.Opis.Equals(opis))
            {
                dijagnoza.Opis = opis;
                haveChanges = true;
            }
           
            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(dijagnoza).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // D-Delete
        public void DeleteDiagnosisById(int diagnosisId)
        {
            Dijagnoza_Specijaliste dijagnoza;

            using (var db = new ClinicDBEntities())
            {
                dijagnoza = db.Dijagnoza_Specijaliste.Where(x => x.Dijagnoza_Id == diagnosisId).FirstOrDefault();
                db.Entry(dijagnoza).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion

        #region CRUD MEDICAL RECORD

        // C = CREATE
        public void CreateMedicalRecord(string ime, string prezime, string JMBG, string evidencija, int pacId, int klinikaId, int departmanId)
        {
            Zdravstveni_Karton karton = new Zdravstveni_Karton(ime, prezime, JMBG, evidencija, 1, klinikaId, departmanId);
            using (var db = new ClinicDBEntities())
            {
                db.Zdravstveni_Karton.Add(karton);
                db.SaveChanges();
            }
        }
        // R = Read
        public List<Zdravstveni_Karton> GetAllMedicalRecords()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from karton in db.Zdravstveni_Karton
                        select karton).ToList();
            }
        }
        // za update 
        public string GetClinicNameById(int clinicId)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from klinika in db.Klinikas
                        where klinika.Klinika_Id == clinicId
                        select klinika.Naziv).FirstOrDefault();
            }
        }
        // U = UPDATE
        public void UpdateRecord(int kartonId, string ime, string prezime, string JMBG, string evidencija)
        {
            Zdravstveni_Karton karton;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                karton = db.Zdravstveni_Karton.Where(x => x.Karton_Id == kartonId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!karton.Ime.Equals(ime))
            {
                karton.Ime = ime;
                haveChanges = true;
            }

            if (!karton.Prezime.Equals(prezime))
            {
                karton.Prezime = prezime;
                haveChanges = true;
            }

            if (!karton.JMBG.Equals(JMBG))
            {
                karton.JMBG = JMBG;
                haveChanges = true;
            }

            if (!karton.Evidencija.Equals(evidencija))
            {
                karton.Evidencija = evidencija;
                haveChanges = true;
            }

            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(karton).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // D-Delete
        public void DeleteRecordById(int recordId)
        {
            Zdravstveni_Karton karton;

            using (var db = new ClinicDBEntities())
            {
                karton = db.Zdravstveni_Karton.Where(x => x.Karton_Id == recordId).FirstOrDefault();
                db.Entry(karton).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        
        #endregion

        #region CRUD AGREEMENT

        // C = CREATE
        public void CreateAgreement(bool isPartTime, DateTime datum_Vazenja, bool specijalizacija, string doktor)
        {
            string vrsta_Ugovora = isPartTime == true ? "part-time" : "full-time";

            Ugovor ugovor = new Ugovor(vrsta_Ugovora, datum_Vazenja, specijalizacija, doktor);
            using (var db = new ClinicDBEntities())
            {
                db.Ugovors.Add(ugovor);
                db.SaveChanges();
            }
        }
        public List<Ugovor> GetAllAgreements()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from ugovor in db.Ugovors
                        select ugovor).ToList();
            }
        }
        // U = UPDATE
        public void UpdateAgreement(int ugovorId, string vrsta_Ugovora, DateTime datum_Vazenja, bool specijalizacija, string doktor)
        {
            Ugovor ugovor;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                ugovor = db.Ugovors.Where(x => x.Ugovor_Id == ugovorId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!ugovor.Vrsta_Ugovora.Equals(vrsta_Ugovora))
            {
                ugovor.Vrsta_Ugovora = vrsta_Ugovora;
                haveChanges = true;
            }

            if (!ugovor.Datum_Vazenja.Equals(datum_Vazenja))
            {
                ugovor.Datum_Vazenja = datum_Vazenja;
                haveChanges = true;
            }

            if (!ugovor.Specijalizacija.Equals(specijalizacija))
            {
                ugovor.Specijalizacija = specijalizacija;
                haveChanges = true;
            }

            if (!ugovor.Doktor.Equals(doktor))
            {
                ugovor.Doktor = doktor;
                haveChanges = true;
            }

            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(ugovor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // D-Delete
        public void DeleteAgreementById(int agreementId)
        {
            Ugovor ugovor;

            using (var db = new ClinicDBEntities())
            {
                ugovor = db.Ugovors.Where(x => x.Ugovor_Id == agreementId).FirstOrDefault();
                db.Entry(ugovor).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion  

        #region CRUD REVIEW

        // C = CREATE
        public void CreateReview(string opis, string vreme, int doktorId)
        {
            Pregled pregled = new Pregled(opis, vreme, doktorId);
            using (var db = new ClinicDBEntities())
            {
                db.Pregleds.Add(pregled);
                db.SaveChanges();
            }
        }
        // R = Read
        public List<Pregled> GetAllReviews()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pregled in db.Pregleds
                        select pregled).ToList();
            }
        }
        // U = UPDATE
        public void UpdateReview(int pregledId, string opis, string vreme)
        {
            Pregled pregled;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                pregled = db.Pregleds.Where(x => x.Pregled_Id == pregledId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!pregled.Opis.Equals(opis))
            {
                pregled.Opis = opis;
                haveChanges = true;
            }

            if (!pregled.Vreme.Equals(vreme))
            {
                pregled.Vreme = vreme;
                haveChanges = true;
            }

            //if (!pregled.Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id.Equals(doktorId))
            //{
            //    pregled.Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id = doktorId;
            //    haveChanges = true;
            //}
            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(pregled).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // D-Delete
        public void DeleteReviewById(int reviewId)
        {
            Pregled pregled;

            using (var db = new ClinicDBEntities())
            {
                pregled = db.Pregleds.Where(x => x.Pregled_Id == reviewId).FirstOrDefault();
                db.Entry(pregled).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        
        #endregion

        #region CRUD REVIEW OUTCOME

        // C = CREATE
        public void CreateReviewOutcome(string naziv, string opis, int pacijentId, bool isDiagnozis)
        {
            string ishodStr = isDiagnozis == true ? "Dijagnoza" : "Uput";

            Ishod_Pregleda ishod = new Ishod_Pregleda(naziv, opis, pacijentId);
            using (var db = new ClinicDBEntities())
            {
                db.Ishod_Pregleda.Add(ishod);
                db.SaveChanges();
            }
        }

        public List<ExtendedOutcome> GetAllReviewOutcome()
        {
            //using (var db = new ClinicDBEntities())
            //{
            //    return (from ishod in db.Ishod_Pregleda
            //            select ishod).ToList();
            //}

            using (var db = new ClinicDBEntities())
            {
                return (from ishod in db.Ishod_Pregleda
                        from gerund in db.Doktor_op_pr_Pregled_Pacijent
                        from doktor in db.Doktors
                        from pacijent in db.Pacijents
                        where ishod.Doktor_op_pr_Pregled_Pacijent.PacijentPacijent_Id == pacijent.Pacijent_Id &&
                              gerund.PacijentPacijent_Id == ishod.Doktor_op_pr_Pregled_Pacijent.PacijentPacijent_Id &&
                              ishod.Doktor_op_pr_Pregled_Pacijent.Doktor_opste_prakse_Pregled_Doktor_opste_prakseDoktor_Id == doktor.Doktor_Id
                        select new ExtendedOutcome() { Name = ishod.Naziv, Description = ishod.Opis, Doctor = doktor.Ime, Patient = pacijent.Ime, Ishod_Id = ishod.Ishod_Id, Outcome = ishod.Naziv}).ToList();
            }
        }
        // U = UPDATE
        public void UpdateOutcome(int ishodId, string naziv, string opis, int pacijentId)
        {
            Ishod_Pregleda ishod;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                ishod = db.Ishod_Pregleda.Where(x => x.Ishod_Id == ishodId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!ishod.Naziv.Equals(naziv))
            {
                ishod.Naziv = naziv;
                haveChanges = true;
            }

            if (!ishod.Opis.Equals(opis))
            {
                ishod.Opis = opis;
                haveChanges = true;
            }

            if (!ishod.Doktor_pregled_Pacijent_PacijentPacijent_Id.Equals(pacijentId))
            {
                ishod.Doktor_pregled_Pacijent_PacijentPacijent_Id = pacijentId;
                haveChanges = true;
            }
           
            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(ishod).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        // D-Delete
        public void DeleteOutcomeById(int outcomeId)
        {
            Ishod_Pregleda ishod;

            using (var db = new ClinicDBEntities())
            {
                ishod = db.Ishod_Pregleda.Where(x => x.Ishod_Id == outcomeId).FirstOrDefault();
                db.Entry(ishod).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        
        #endregion

        #region CRUD THERAPY

        // C = CREATE
        public void CreateTherapy(string naziv, string opis, string vrsta_Terapije)
        {
            Terapija terapija = new Terapija(naziv, opis, vrsta_Terapije);
            using (var db = new ClinicDBEntities())
            {
                db.Terapijas.Add(terapija);
                db.SaveChanges();
            }
        }

        public List<Terapija> GetAllTherapies()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from terapija in db.Terapijas
                        select terapija).ToList();
            }
        }
        // U = UPDATE
        public void UpdateTherapy(int terapijaId, string naziv, string opis, string vrstaTerapije)
        {
            Terapija terapija;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                terapija = db.Terapijas.Where(x => x.Terapija_Id == terapijaId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!terapija.Naziv.Equals(naziv))
            {
                terapija.Naziv = naziv;
                haveChanges = true;
            }

            if (!terapija.Opis.Equals(opis))
            {
                terapija.Opis = opis;
                haveChanges = true;
            }

            if (!terapija.Vrsta_Terapije.Equals(vrstaTerapije))
            {
                terapija.Vrsta_Terapije = vrstaTerapije;
                haveChanges = true;
            }
            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(terapija).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        // D-Delete
        public void DeleteTherapyById(int therapyId)
        {
            Terapija terapija;

            using (var db = new ClinicDBEntities())
            {
                terapija = db.Terapijas.Where(x => x.Terapija_Id == therapyId).FirstOrDefault();
                db.Entry(terapija).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion

        public int CountDailyExamsForDoctor(int doctorId, string date)
        {
            // poziv SQL Stored Procedure 
            ObjectParameter retval = new ObjectParameter("count", typeof(Int32));

            using (var dbContext = new ClinicDBEntities())
            {
                dbContext.BrojacDnevnihPregledaZaDoktora(doctorId, date, retval);
            }

            return Convert.ToInt32(retval.Value);
        }
    }
}
