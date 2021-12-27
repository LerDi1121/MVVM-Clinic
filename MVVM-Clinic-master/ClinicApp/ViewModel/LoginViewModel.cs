using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class LoginViewModel : ValidationBase
    {

        #region Fields and properties
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        #endregion Fields and properties

        #region Validation

        protected override void ValidateSelf()
        {
            if (String.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Required field!";
            }
            else if (Regex.IsMatch(this.username.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Username"] = "Can't start with number!";
            }

            if (String.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Required field!";
            }
            else if (this.password.Trim().Length <= 6)
            {
                this.ValidationErrors["Password"] = "Must have more than 6 characters!";
            }

            using (var dbContext = new ClinicDBEntities())
            {
                var user = dbContext.Korisniks.Where(x => x.Korisnicko_Ime == this.Username && x.Lozinka == this.Password).FirstOrDefault();
                if (user == null)
                {
                    this.ValidationErrors["Password"] = "Wrong Username or Password!";
                }
            }
        }
        #endregion Validation

        public MyICommand LogInCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LogInCommand = new MyICommand(OnLogIn);
            RegisterCommand = new MyICommand(OnRegister);
        }

        public void OnLogIn()
        {
            // validacija popunjenih polja
            this.Validate();

            if (this.IsValid)
            {
                string hashPassword = SecurityHandler.CreateHash(Password);
                using (var dbContext = new ClinicDBEntities())
                {
                    var user = dbContext.Korisniks.Where(korisnik => korisnik.Korisnicko_Ime == username && korisnik.Lozinka == password).FirstOrDefault();


                    if (user is Doktor)
                    {
                        var doktor = user as Doktor;
                        if (doktor.Uloga == DoctorType.DOCTOR_SPECIALIST.ToString())
                        {
                            DbContextHandler.Instance.Logging(Username, hashPassword);
                            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.DOCTOR_SPECIALIST_VIEW);
                        }
                        else
                        {
                            DbContextHandler.Instance.Logging(Username, hashPassword);
                            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.GENERAL_PRACTICIONER_VIEW);

                        }

                    }
                    else if (user is Pacijent)
                    {
                        DbContextHandler.Instance.Logging(Username, hashPassword);
                        MainWindowViewModel.ChangeViewCommand.Execute(ViewType.PATIENT_VIEW);
                    }
                }
            }
        }

        public void OnRegister()
        {
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.REGISTER_VIEW);
        }
    }
}
