using ClinicApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
        public class ReviewOutcomeViewModel : ValidationBase
        {
            #region Fields and properties
            private string dateAndTime;
            private string description;
            private string patient;
            private string doctor;
            private string outcome;

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
        public string Patient
        {
            get { return patient; }
            set
            {
                if (patient != value)
                {
                    patient = value;
                    OnPropertyChanged("Patient");
                }
            }
        }
        public string Doctor
        {
            get { return doctor; }
            set
            {
                if (doctor != value)
                {
                    doctor = value;
                    OnPropertyChanged("Doctor");
                }
            }
        }
        public string Outcome
        {
            get { return outcome; }
            set
            {
                if (outcome != value)
                {
                    outcome = value;
                    OnPropertyChanged("Outcome");
                }
            }
        }
        #endregion
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
            // PATIENT
            if (String.IsNullOrWhiteSpace(this.patient))
            {
                this.ValidationErrors["Patient"] = "Required field!";
            }
            // DOCTOR
            if (String.IsNullOrWhiteSpace(this.doctor))
            {
                this.ValidationErrors["Doctor"] = "Required field!";
            }
            // OUTCOME
            if (String.IsNullOrWhiteSpace(this.outcome))
            {
                this.ValidationErrors["Outcome"] = "Required field!";
            }
            else if (Regex.IsMatch(this.outcome.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Outcome"] = "Can't start with number!";
            }
        }
    }
}
