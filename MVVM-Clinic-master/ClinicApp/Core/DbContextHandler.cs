using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void CreateDoctor(string ime, string prezime, string specijalizacija, int klinika_Id, int departman_Id, string kontakt)
        {
            Doktor doktor = new Doktor(ime, prezime, specijalizacija, klinika_Id, departman_Id, kontakt);
            using (var db = new ClinicDBEntities())
            {
                db.Doktors.Add(doktor);
                db.SaveChanges();
            }
        }

        public List<Doktor> GetAllDoctors()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Doktors
                        select doktor).ToList();
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

        public List<Pacijent> GetAllPatients()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Pacijents
                        select pacijent).ToList();
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

        // C = CREATE
        public void CreateDepartment(string naziv, string sprat)
        {
            Departman departman = new Departman(naziv, sprat);
            using (var db = new ClinicDBEntities())
            {
                db.Departmen.Add(departman);
                db.SaveChanges();
            }
        }

        public List<Departman> GetAllDepartments()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        select departman).ToList();
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
        #region CRUD DIAGNOZIS

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
        #endregion

        #region CRUD MEDICAL RECORD

        // C = CREATE
        public void CreateMedicalRecord(string ime, string prezime, string JMBG, string evidencija, int pacijentId, int klinikaId, int departmanId)
        {
            Zdravstveni_Karton karton = new Zdravstveni_Karton(ime, prezime, JMBG, evidencija, pacijentId, klinikaId, departmanId);
            using (var db = new ClinicDBEntities())
            {
                db.Zdravstveni_Karton.Add(karton);
                db.SaveChanges();
            }
        }

        public List<Zdravstveni_Karton> GetAllMedicalRecords()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from karton in db.Zdravstveni_Karton
                        select karton).ToList();
            }
        }
        #endregion


        #region CRUD AGREEMENT

        // C = CREATE
        public void CreateAgreement(string vrsta_Ugovora, DateTime datum_Vazenja, bool specijalizacija, string doktor)
        {
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

        public List<Pregled> GetAllReviews()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pregled in db.Pregleds
                        select pregled).ToList();
            }
        }
        #endregion


        #region CRUD REVIEW OUTCOME

        // C = CREATE
        public void CreateReviewOutcome(string naziv, string opis, int pacijentId)
        {
            Ishod_Pregleda ishod = new Ishod_Pregleda(naziv, opis, pacijentId);
            using (var db = new ClinicDBEntities())
            {
                db.Ishod_Pregleda.Add(ishod);
                db.SaveChanges();
            }
        }

        public List<Ishod_Pregleda> GetAllReviewOutcome()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from ishod in db.Ishod_Pregleda
                        select ishod).ToList();
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
        #endregion
    }
}
