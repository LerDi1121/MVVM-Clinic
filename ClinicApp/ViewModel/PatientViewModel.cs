using ClinicApp.Core;
using System;
using System.Collections.Generic;
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
            private string department;
            private string view;

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
        public string View
        {
            get { return view; }
            set
            {
                if (view != value)
                {
                    view = value;
                    OnPropertyChanged("View");
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
            // LAST NAME
            if (String.IsNullOrWhiteSpace(this.lastname))
            {
                this.ValidationErrors["Lastname"] = "Required field!";
            }
            else if (Regex.IsMatch(this.lastname.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Lastname"] = "Can't start with number!";
            }
            // ADDRESS
            if (String.IsNullOrWhiteSpace(this.address))
            {
                this.ValidationErrors["Address"] = "Required field!";
            }
            // else if(textBoxNazivVina.Text.Length > 20)
            else if (Regex.IsMatch(this.address.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Address"] = "Can't start with number!";
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
            // VIEW
            if (String.IsNullOrWhiteSpace(this.view))
            {
                this.ValidationErrors["View"] = "Required field!";
            }
        }
    }
}
