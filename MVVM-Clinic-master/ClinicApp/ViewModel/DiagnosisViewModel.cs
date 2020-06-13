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
    public class DiagnosisViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string description;
        //private List<string> patients = new List<string>();
        //private string selectedType;
        //private List<string> doctors = new List<string>();
        //private string selectedType2;

        private ObservableCollection<Dijagnoza_Specijaliste> dijagnoze = new ObservableCollection<Dijagnoza_Specijaliste>();

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
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        //public List<string> Patients
        //{
        //    get { return patients; }
        //    set
        //    {
        //        if (patients != value)
        //        {
        //            patients = value;
        //            OnPropertyChanged("Patients");
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
        //public List<string> Doctors
        //{
        //    get { return doctors; }
        //    set
        //    {
        //        if (doctors != value)
        //        {
        //            doctors = value;
        //            OnPropertyChanged("Doctors");
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
        public ObservableCollection<Dijagnoza_Specijaliste> Dijagnoze
        {
            get { return dijagnoze; }
            set
            {
                if (dijagnoze != value)
                {
                    dijagnoze = value;
                    OnPropertyChanged("Dijagnoze");
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
            // DESCRIPTION
            if (String.IsNullOrWhiteSpace(this.description))
            {
                this.ValidationErrors["Description"] = "Required field!";
            }
            else if (Regex.IsMatch(this.description.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Description"] = "Can't start with number!";
            }
            else if (this.description.Length < 3)
            {
                this.ValidationErrors["Description"] = "Must have more than 3 characters";
            }
            else if (this.description.Length > 200)
            {
                this.ValidationErrors["Description"] = "Must be less than 200 characters";
            }
            //// PATIENTS
            //if (String.IsNullOrWhiteSpace(this.selectedType))
            //{
            //    this.ValidationErrors["Patients"] = "Required field!";
            //}
            //// DOCTORS
            //if (String.IsNullOrWhiteSpace(this.selectedType2))
            //{
            //    this.ValidationErrors["Doctors"] = "Required field!";
            //}
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public DiagnosisViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new RelayCommand(OnDelete);

            //combobox
            //Patients = DbContextHandler.Instance.GetAllPatientForDiagnosis();
            //Doctors = DbContextHandler.Instance.GetAllDoctorForDiagnosis();

            //tabela
            DbContextHandler.Instance.GetAllDiagnozis().ForEach(dijagnoza => Dijagnoze.Add(dijagnoza));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                //int patientId = DbContextHandler.Instance.GetPatientIdByName(this.selectedType);
                //int doctorId = DbContextHandler.Instance.GetDoctorIdByName(this.selectedType2);

                DbContextHandler.Instance.CreateDiagnozis(Name, Description); // + patientId  + doctorId

                Dijagnoze.Clear();
                DbContextHandler.Instance.GetAllDiagnozis().ForEach(dijagnoza => Dijagnoze.Add(dijagnoza));
            }
        }

        public void OnDelete()
        {
            int diagnosisId = Dijagnoze.ElementAt(CurrentIndex).Dijagnoza_Id;

            DbContextHandler.Instance.DeleteDiagnosisById(diagnosisId);

            Dijagnoze.RemoveAt(CurrentIndex);
        }
        #endregion
    }
}
