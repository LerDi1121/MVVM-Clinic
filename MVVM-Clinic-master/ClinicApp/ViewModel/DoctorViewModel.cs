using ClinicApp.Core;
using ClinicApp.Model;
using ClinicApp.View.All;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClinicApp.ViewModel
{
    public class DoctorViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string lastname;
        private string contact;
        private string specialization;
        private List<string> departments = new List<string>();
        private string selectedType;

        private ObservableCollection<Doktor> doktori = new ObservableCollection<Doktor>();

        private int currentIndex;

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


        public ObservableCollection<Doktor> Doktori
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
        }


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
            // NAME
            if (String.IsNullOrWhiteSpace(this.name))
            {
                this.ValidationErrors["Name"] = "Required field!";
            }
            else if (Regex.IsMatch(this.name.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Name"] = "Can't start with number!";
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
            else if (Regex.IsMatch(this.lastname.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Lastname"] = "Can't start with number!";
            }
            else if (this.lastname.Length < 3 )
            {
                this.ValidationErrors["Lastname"] = "Must have more than 3 characters";
            }
            else if (this.lastname.Length > 20)
            {
                this.ValidationErrors["Lastname"] = "Must be less than 20 characters";
            }

            // SPECIALIZATION
            if (String.IsNullOrWhiteSpace(this.specialization))
            {
                this.ValidationErrors["Specialization"] = "Required field!";
            }
            else if (Regex.IsMatch(this.specialization.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Specialization"] = "Can't start with number!";
            }
            else if (this.specialization.Length < 3)
            {
                this.ValidationErrors["Specialization"] = "Must have more than 3 characters";
            }
            else if (this.specialization.Length > 20)
            {
                this.ValidationErrors["Specialization"] = "Must be less than 20 characters";
            }

            // CONTACT
            if (String.IsNullOrWhiteSpace(this.contact))
            {
                this.ValidationErrors["Contact"] = "Required field!";
            }
            else if (Regex.IsMatch(this.contact.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["Contact"] = "Must start with number!";
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
        public DoctorViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new RelayCommand(OnDelete);

            Departments = DbContextHandler.Instance.GetAllDepartmentsList();

            DbContextHandler.Instance.GetAllDoctors().ForEach(doktor => Doktori.Add(doktor));
        }
        public void OnAdd()
        {
            this.Validate();

            if (this.IsValid)
            {
                int departmentId = DbContextHandler.Instance.GetDeparmentIdByName(this.selectedType);

                DbContextHandler.Instance.CreateDoctor(Name, Lastname, Specialization, 1, departmentId, Contact);

                Doktori.Clear();
                DbContextHandler.Instance.GetAllDoctors().ForEach(doktor => Doktori.Add(doktor));
            }
        }
        public void OnDelete()
        {
            int doctorId = Doktori.ElementAt(CurrentIndex).Doktor_Id;

            DbContextHandler.Instance.DeleteDoctorById(doctorId);

            Doktori.RemoveAt(CurrentIndex);
        }
        #endregion
    }
}
