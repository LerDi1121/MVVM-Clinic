using ClinicApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class TherapyViewModel: ValidationBase
    {
        #region Fields and properties
        private string name;
        private string description;
        private string type;
        private string diagnosis;

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
        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Diagnosis
        {
            get { return diagnosis; }
            set
            {
                if (diagnosis != value)
                {
                    diagnosis = value;
                    OnPropertyChanged("Diagnosis");
                }
            }
        }
        #endregion
        protected override void ValidateSelf()
        {// NAME
            if (String.IsNullOrWhiteSpace(this.name))
            {
                this.ValidationErrors["Name"] = "Required field!";
            }
            else if (Regex.IsMatch(this.name.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Name"] = "Can't start with number!";
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
            // TYPE
            if (String.IsNullOrWhiteSpace(this.type))
            {
                this.ValidationErrors["Type"] = "Required field!";
            }
            else if (Regex.IsMatch(this.type.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Type"] = "Can't start with number!";
            }
            // DIAGNOSIS
            if (String.IsNullOrWhiteSpace(this.diagnosis))
            {
                this.ValidationErrors["Diagnosis"] = "Required field!";
            }
            else if (Regex.IsMatch(this.diagnosis.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Diagnosis"] = "Can't start with number!";
            }
        }
    }
}
