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
        public List<string> GetAllDepartments()
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
    }
}
