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
    public class ReviewViewModel : ValidationBase
    {
        #region Fields and properties
        private string dateAndTime;
        private string description;
        //private string patient;
        private List<string> doctors = new List<string>();
        private string selectedType;
        private ObservableCollection<Pregled> pregledi = new ObservableCollection<Pregled>();

        public string DateAndTime
        {
            get { return dateAndTime; }
            set
            {
                if (dateAndTime != value)
                {
                    dateAndTime = value;
                    OnPropertyChanged("DateAndTime");
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
        //public string Patient
        //{
        //    get { return patient; }
        //    set
        //    {
        //        if (patient != value)
        //        {
        //            patient = value;
        //            OnPropertyChanged("Patient");
        //        }
        //    }
        //}
        public List<string> Doctors
        {
            get { return doctors; }
            set
            {
                if (doctors != value)
                {
                    doctors = value;
                    OnPropertyChanged("Doctors");
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


        public ObservableCollection<Pregled> Pregledi
        {
            get { return pregledi; }
            set
            {
                if (pregledi != value)
                {
                    pregledi = value;
                    OnPropertyChanged("Pregledi");
                }
            }
        }
        #endregion

        #region Validations
        protected override void ValidateSelf()
        {
            // DATE
            if (String.IsNullOrWhiteSpace(this.dateAndTime))
            {
                this.ValidationErrors["DateAndTime"] = "Required field!";
            }
            else if (Regex.IsMatch(this.dateAndTime.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["DateAndTime"] = "Must start with number!";
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
            //// PATIENT
            //if (String.IsNullOrWhiteSpace(this.patient))
            //{
            //    this.ValidationErrors["Patient"] = "Required field!";
            //}

            // DOCTOR
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Doctors"] = "Required field!";
            }
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public ReviewViewModel()
        {
            AddCommand = new MyICommand(OnAdd);

            //combobox
            Doctors = DbContextHandler.Instance.GetAllDoctorsList();

            //tabela
            DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                int doctorId = DbContextHandler.Instance.GetDoctorIdByName(this.selectedType);

                DbContextHandler.Instance.CreateReview(Description, DateAndTime, doctorId);

                Pregledi.Clear();
                DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));
            }
        }
        #endregion
    }
}
