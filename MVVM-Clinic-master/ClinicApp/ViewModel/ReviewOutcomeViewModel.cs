using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class ReviewOutcomeViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string description;
        //private string doctors;
        private List<string> patients = new List<string>();
        private string selectedType;
        //private string outcome;
        private ObservableCollection<Ishod_Pregleda> ishodi = new ObservableCollection<Ishod_Pregleda>();

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
        public List<string> Patients
        {
            get { return patients; }
            set
            {
                if (patients != value)
                {
                    patients = value;
                    OnPropertyChanged("Patients");
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
        //public string Doctor
        //{
        //    get { return doctor; }
        //    set
        //    {
        //        if (doctor != value)
        //        {
        //            doctor = value;
        //            OnPropertyChanged("Doctor");
        //        }
        //    }
        //}
        //public string Outcome
        //{
        //    get { return outcome; }
        //    set
        //    {
        //        if (outcome != value)
        //        {
        //            outcome = value;
        //            OnPropertyChanged("Outcome");
        //        }
        //    }
        //}
        public ObservableCollection<Ishod_Pregleda> Ishodi
        {
            get { return ishodi; }
            set
            {
                if (ishodi != value)
                {
                    ishodi = value;
                    OnPropertyChanged("Ishodi");
                }
            }
        }
        #endregion

        #region Validations
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
            // PATIENT
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Patients"] = "Required field!";
            }
            //// DOCTOR
            //if (String.IsNullOrWhiteSpace(this.doctor))
            //{
            //    this.ValidationErrors["Doctor"] = "Required field!";
            //}
            //// OUTCOME
            //if (String.IsNullOrWhiteSpace(this.outcome))
            //{
            //    this.ValidationErrors["Outcome"] = "Required field!";
            //}
            //else if (Regex.IsMatch(this.outcome.Substring(0, 1), "[0-9]"))
            //{
            //    this.ValidationErrors["Outcome"] = "Can't start with number!";
            //}
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public ReviewOutcomeViewModel()
        {
            AddCommand = new MyICommand(OnAdd);

            //combobox
            Patients = DbContextHandler.Instance.GetAllPatientsList();

            //tabela
            DbContextHandler.Instance.GetAllReviewOutcome().ForEach(ishod => Ishodi.Add(ishod));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                int patientId = DbContextHandler.Instance.GetPatientIdByName(this.selectedType);

                DbContextHandler.Instance.CreateReviewOutcome(Name, Description, patientId);

                Ishodi.Clear();
                DbContextHandler.Instance.GetAllReviewOutcome().ForEach(ishod => Ishodi.Add(ishod));
            }
        }
        #endregion
    }
}
