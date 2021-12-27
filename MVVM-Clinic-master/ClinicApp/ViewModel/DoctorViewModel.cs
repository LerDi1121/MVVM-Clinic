using ClinicApp.Core;
//using ClinicApp.Model;
using ClinicApp.View.All;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class DoctorViewModel : ValidationBase
    {
       #region Fields and properties
        private string name;
        private string lastname;
        private string username;
        private string password;
        private string contact; 
        private string street;
        private string number;
        private string city;
        private string email;
        private string specialization;
        private List<string> departments = new List<string>();
        private string selectedType;

        //private Doktor selectedDoktor;
        private string btnContent;
        private bool isUpdate = false;

        private bool isDoctorSpecialist;

        //private ObservableCollection<Doktor> doktori = new ObservableCollection<Doktor>();

        private int currentIndex;
  
        public string BtnContent
        {
            get { return btnContent; }
            set
            {
                if (btnContent != value)
                {
                    btnContent = value;
                    OnPropertyChanged("BtnContent");
                }
            }
        }     
        public bool IsDoctorSpecialist
        {
            get { return isDoctorSpecialist; }
            set
            {
                if (isDoctorSpecialist != value)
                {
                    isDoctorSpecialist = value;
                    OnPropertyChanged("IsDoctorSpecialist");
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    OnPropertyChanged("Lastname");
                }
            }
        }
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
        public string Contact
        {
            get { return contact; }
            set
            {
                if (contact != value)
                {
                    contact = value;
                    OnPropertyChanged("Contact");
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (street != value)
                {
                    street = value;
                    OnPropertyChanged("Street");
                }
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        public string Specialization
        {
            get { return specialization; }
            set
            {
                if (specialization != value)
                {
                    specialization = value;
                    OnPropertyChanged("Specialization");
                }
            }
        }
        public List<string> Departments
        {
            get { return departments; }
            set
            {
                if (departments != value)
                {
                    departments = value;
                    OnPropertyChanged("Departments");
                }
            }
        }
        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                if (selectedType != value)
                {
                    selectedType = value;
                    OnPropertyChanged("SelectedType");
                }
            }
        }
       /* public Doktor SelectedDoktor
        {
            get { return selectedDoktor; }
            set
            {
                if (selectedDoktor != value)
                {
                    selectedDoktor = value;
                    OnPropertyChanged("SelectedDoktor");
                }
            }
        }*/

      /*  public ObservableCollection<Doktor> Doktori
        {
            get { return doktori; }
            set
            {
                if (doktori != value)
                {
                    doktori = value;
                    OnPropertyChanged("Doktori");
                }
            }
        }*/

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    OnPropertyChanged("CurrentIndex");
                }
            }
        }
        #endregion

        #region Validation
        protected override void ValidateSelf()
        {
            // USERNAME
            if (String.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Required field!";
            }
            else if (Regex.IsMatch(this.username.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Username"] = "Can't start with number!";
            }

            // PASSWORD
            if (String.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Required field!";
            }
            else if (this.password.Trim().Length <= 6)
            {
                this.ValidationErrors["Password"] = "Must have more than 6 characters!";
            }
            // NAME
            if (String.IsNullOrWhiteSpace(this.name))
            {
                this.ValidationErrors["Name"] = "Required field!";
            }
            else if (Regex.IsMatch(this.name.Substring(0, this.name.Length), "[0-9]"))
            {
                this.ValidationErrors["Name"] = "Can't contain a number!";
            }
            else if (this.name.Length < 3)
            {
                this.ValidationErrors["Name"] = "Must have more than 3 characters";
            }
            else if (this.name.Length > 20)
            {
                this.ValidationErrors["Name"] = "Must be less than 20 characters";
            }

            // LAST NAME
            if (String.IsNullOrWhiteSpace(this.lastname))
            {
                this.ValidationErrors["Lastname"] = "Required field!";
            }
            else if (Regex.IsMatch(this.lastname.Substring(0, this.lastname.Length), "[0-9]"))
            {
                this.ValidationErrors["Lastname"] = "Can't contain a number!";
            }
            else if (this.lastname.Length < 3 )
            {
                this.ValidationErrors["Lastname"] = "Must have more than 3 characters";
            }
            else if (this.lastname.Length > 20)
            {
                this.ValidationErrors["Lastname"] = "Must be less than 20 characters";
            }

            // CONTACT
            if (String.IsNullOrWhiteSpace(this.contact))
            {
                this.ValidationErrors["Contact"] = "Required field!";
            }
            else if (Regex.IsMatch(this.contact.Substring(0, this.contact.Length), "[^0-9]"))
            {
                this.ValidationErrors["Contact"] = "Must have a number!";
            }
            // CITY
            if (String.IsNullOrWhiteSpace(this.city))
            {
                this.ValidationErrors["City"] = "Required field!";
            }
            else if (Regex.IsMatch(this.city.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["City"] = "Can't start with number!";
            }

            // STREET
            if (String.IsNullOrWhiteSpace(this.street))
            {
                this.ValidationErrors["Street"] = "Required field!";
            }
            else if (Regex.IsMatch(this.street.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Street"] = "Can't start with number!";
            }

            // NUMBER
            if (String.IsNullOrWhiteSpace(this.number))
            {
                this.ValidationErrors["Number"] = "Required field!";
            }
            else if (Regex.IsMatch(this.number.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["Number"] = "Must start with number!";
            }
            // EMAIL
            if (String.IsNullOrWhiteSpace(this.email))
            {
                this.ValidationErrors["Email"] = "Required field!";
            }
            else if (!(new EmailAddressAttribute().IsValid(this.email)))
            {
                this.ValidationErrors["Email"] = "Invalid format for email address.";
            }
            // DEPARTMENTS
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Departments"] = "Required field!";
            }
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }

      /*  public DoctorViewModel()
        {
            BtnContent = "Add";
            AddCommand = new MyICommand(OnAdd);
            ChangeCommand = new MyICommand(OnSaveChanges);
            DeleteCommand = new RelayCommand(OnDelete);

            Departments = DbContextHandler.Instance.GetAllDepartmentsList();

            DbContextHandler.Instance.GetAllDoctors().ForEach(doktor => Doktori.Add(doktor));

            foreach(Doktor d in Doktori)
            {
                // d.NumExams = DbContextHandler.Instance.CountDailyExamsForDoctor(d.Doktor_Id, DateTime.Now.ToShortDateString());
            }
        }
        public void OnAdd()
        {
            this.Validate();

            if (this.IsValid)
            {
                if(!isUpdate)
                {
                    int departmentId = DbContextHandler.Instance.GetDeparmentIdByName(this.selectedType);
                    if (!IsDoctorSpecialist)
                    {
                        Specialization = "opsta praksa";
                    }
                    else
                        Specialization = "specijalista";

                    DbContextHandler.Instance.CreateDoctor(Name, Lastname, Specialization, 1, departmentId, Contact, Username, Password, Email, Street, City, Number);

                    Doktori.Clear();
                    DbContextHandler.Instance.GetAllDoctors().ForEach(doktor => Doktori.Add(doktor));
                    foreach (Doktor d in Doktori)
                    {
                       // d.NumExams = DbContextHandler.Instance.CountDailyExamsForDoctor(d.Doktor_Id, DateTime.Now.ToShortDateString());
                    }
                    Name = "";
                    Lastname = "";
                    Specialization = "";
                    Contact = "";
                    SelectedType = null;
                    Email = "";
                    Username = "";
                    Password = "";
                    Street = "";
                    Number = "";
                    City = "";
                }
                else
                {                   
                    MessageBox.Show("Update data!");
                    int departmentId = DbContextHandler.Instance.GetDeparmentIdByName(this.selectedType);
                    if (!IsDoctorSpecialist)
                    {
                        Specialization = "opsta praksa";
                    }
                    else
                        Specialization = "specijalista";

                    DbContextHandler.Instance.UpdateDoctor(SelectedDoktor.Doktor_Id, name, lastname, specialization, 1, departmentId, contact, password, username, street, city, number, email);
                    
                    Doktori.Clear();
                    DbContextHandler.Instance.GetAllDoctors().ForEach(doktor => Doktori.Add(doktor));
                    foreach (Doktor d in Doktori)
                    {
                       // d.NumExams = DbContextHandler.Instance.CountDailyExamsForDoctor(d.Doktor_Id, DateTime.Now.ToShortDateString());
                    }
                    Name = "";
                    Lastname = "";
                    Specialization = "";
                    Contact = "";
                    SelectedType = null;
                    isUpdate = false;
                    BtnContent = "Add";
                    Email = "";
                    Username = "";
                    Password = "";
                    Street = "";
                    Number = "";
                    City = "";
                }
            }
        }
        public void OnDelete()
        {
            int doctorId = Doktori.ElementAt(CurrentIndex).Doktor_Id;

            DbContextHandler.Instance.DeleteDoctorById(doctorId);
            MessageBox.Show("Delete data!");
            Doktori.RemoveAt(CurrentIndex);
        }

        public void OnSaveChanges()
        {
            Username = SelectedDoktor.Korisnicko_Ime;
            Password = SelectedDoktor.Lozinka;
            Name = SelectedDoktor.Ime;
            Lastname = SelectedDoktor.Prezime;
            Specialization = SelectedDoktor.Specijalizacija;
            Contact = SelectedDoktor.Kontakt;
            SelectedType = DbContextHandler.Instance.GetDepartmentNameById(SelectedDoktor.Departman_Id);
            Street = SelectedDoktor.Ulica;
            Number = SelectedDoktor.Broj;
            City = SelectedDoktor.Grad;
            Email = SelectedDoktor.Email;

            isUpdate = true;
            BtnContent = "Update";
        }*/
        #endregion
    }
}
