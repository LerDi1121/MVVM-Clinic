using ClinicApp.Core;
using System;
using System.Collections.Generic;
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
        private string descrpition;
        private string patient;
        private string doctor;

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
        public string Descrpition
        {
            get { return descrpition; }
            set
            {
                if (descrpition != value)
                {
                    descrpition = value;
                    OnPropertyChanged("Descrpition");
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
        
        #endregion
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
            // DESCRIPTION
            if (String.IsNullOrWhiteSpace(this.descrpition))
            {
                this.ValidationErrors["Descrpition"] = "Required field!";
            }
            else if (Regex.IsMatch(this.descrpition.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Descrpition"] = "Can't start with number!";
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
        }
    }
}
