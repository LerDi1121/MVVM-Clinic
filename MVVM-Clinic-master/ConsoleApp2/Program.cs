using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClinicDBEntities context = new ClinicDBEntities();
            Klinika klinika = new Klinika()
            {
                Broj = "123",
                Grad = "Jarak",
                Naziv = "Test Klinika",
                Telefon = "022/662129",
                Ulica = "Savska"
            };
            context.Klinikas.Add(klinika);
            context.SaveChanges();
            Departman departman = new Departman()
            {
                Naziv = "Test Departman",
                Sprat = "2",
                Klinika = klinika
            };
            context.Departmen.Add(departman);
            context.SaveChanges();
            Doktor doktorOP = new Doktor()
            {
                Departmen = departman,
                Uloga = "doktor",
                Broj = "11",
                Email = "email@test.com",
                Grad = "imegrada",
                Ime = "ime doktora",
                Kontakt = "kontakt",
                Korisnicko_Ime = "doktoropsteprakse",
                Lozinka = "lozinka123",
                Prezime = "prezimedoktora",
                Specijalizacija = null,
                Ulica = "ulica"
            };
            context.Korisniks.Add(doktorOP);
            context.SaveChanges();


            Pacijent pacijent = new Pacijent()
            {
                Ime = "pacijent",
                Prezime = "pacijent",
                Uloga = "pacijent",
                Broj = "111",
                Email = "pacijentmail@g,ail.com",
                Departmen = departman,
                Grad = "Grad",
                Kontakt = "kontakt",
                Korisnicko_Ime = "pacijent",
                Lozinka = "lozinka123",
                Ulica = "ulica"
            };
            context.Korisniks.Add(pacijent);
            context.SaveChanges();

            Termin termin = new Termin()
            {
                Datum = "01/01/2022",
                Vreme = "09.30"
            };

            context.Termins.Add(termin);
            context.SaveChanges();
            Pregled pregled = new Pregled()
            {
                Doktor = doktorOP,
                Obvljen = "NE",
                Termins = termin,
                Opis = "Bol u k",
                Pacijent = pacijent,
                Ishod_Pregleda = null
            };
            context.Pregleds.Add(pregled);
            context.SaveChanges();


        }
    }
}
