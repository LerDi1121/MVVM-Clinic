using ClinicApp.Core;
using ClinicApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class PatientViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string lastname;
        private string contact;
        private string address;
        //private List<string> departments = new List<string>();
        //private string selectedType;
        //private List<string> views = new List<string>();
        //private string selectedType2;

        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();

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

        public string Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        //public List<string> Departments
        //{
        //    get { return departments; }
        //    set
        //    {
        //        if (departments != value)
        //        {
        //            departments = value;
        //            OnPropertyChanged("Departments");
        //        }
        //    }
        //}
        //public string SelectedType
        //{
        //    get { return selectedType; }
        //    set
        //    {
        //        if (selectedType != value)
        //        {
        //            selectedType = value;
        //            OnPropertyChanged("SelectedType");
        //        }
        //    }
        //}
        //public List<string> Views
        //{
        //    get { return views; }
        //    set
        //    {
        //        if (views != value)
        //        {
        //            views = value;
        //            OnPropertyChanged("Views");
        //        }
        //    }
        //}
        //public string SelectedType2
        //{
        //    get { return selectedType2; }
        //    set
        //    {
        //        if (selectedType2 != value)
        //        {
        //            selectedType2 = value;
        //            OnPropertyChanged("SelectedType2");
        //        }
        //    }
        //}

        public ObservableCollection<Pacijent> Pacijenti
        {
            get { return pacijenti; }
            set
            {
                if (pacijenti != value)
                {
                    pacijenti = value;
                    OnPropertyChanged("Pacijenti");
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
            else if (this.lastname.Length < 3)
            {
                this.ValidationErrors["Lastname"] = "Must have more than 3 characters";
            }
            else if (this.lastname.Length > 20)
            {
                this.ValidationErrors["Lastname"] = "Must be less than 20 characters";
            }
            // ADDRESS
            if (String.IsNullOrWhiteSpace(this.address))
            {
                this.ValidationErrors["Address"] = "Required field!";
            }
            else if (Regex.IsMatch(this.address.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Address"] = "Can't start with number!";
            }
            else if (this.address.Length < 3)
            {
                this.ValidationErrors["Address"] = "Must have more than 3 characters";
            }
            else if (this.address.Length > 40)
            {
                this.ValidationErrors["Address"] = "Must be less than 20 characters";
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
            //// DEPARTMENT
            //if (String.IsNullOrWhiteSpace(this.selectedType))
            //{
            //    this.ValidationErrors["Departments"] = "Required field!";
            //}
            //// VIEW
            //if (String.IsNullOrWhiteSpace(this.selectedType2))
            //{
            //    this.ValidationErrors["Views"] = "Required field!";
            //}
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public PatientViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new RelayCommand(OnDelete);

            //combobox
            //Departments = DbContextHandler.Instance.GetAllDepartmentsForDoctor();
            //Views = DbContextHandler.Instance.GetAllViewsForPatient();
            //tabela
            DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
               // int departmentId = DbContextHandler.Instance.GetDeparmentIdByName(this.selectedType);
               // int viewId = DbContextHandler.Instance.GetPatientIdByName(this.selectedType2);

                DbContextHandler.Instance.CreatePatient(Name, Lastname, Contact, Address);

                Pacijenti.Clear();
                DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));
            }
        }

        public void OnDelete()
        {
            int patientId = Pacijenti.ElementAt(CurrentIndex).Pacijent_Id;

            DbContextHandler.Instance.DeletePatientById(patientId);

            Pacijenti.RemoveAt(CurrentIndex);
        }
        #endregion
    }
}
