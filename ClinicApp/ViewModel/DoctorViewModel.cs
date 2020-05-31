using ClinicApp.Core;
using ClinicApp.View.All;
using System;
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
        private string department;

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
        public string Department
        {
            get { return department; }
            set
            {
                if (department != value)
                {
                    department = value;
                    OnPropertyChanged("Department");
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
            // LAST NAME
            if (String.IsNullOrWhiteSpace(this.lastname))
            {
                this.ValidationErrors["Lastname"] = "Required field!";
            }
            else if (Regex.IsMatch(this.lastname.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Lastname"] = "Can't start with number!";
            }
            // SPECIALISATION
            if (String.IsNullOrWhiteSpace(this.specialization))
            {
                this.ValidationErrors["Specialization"] = "Required field!";
            }
           // else if(textBoxNazivVina.Text.Length > 20)
            else if (Regex.IsMatch(this.specialization.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Specialization"] = "Can't start with number!";
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
            // DEPARTMENT
            if (String.IsNullOrWhiteSpace(this.department))
            {
                this.ValidationErrors["Department"] = "Required field!";
            }  
        }
        #endregion
    }
}
