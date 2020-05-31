using ClinicApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class DepartmentViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string floor;
        private string clinic;

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
        public string Floor
        {
            get { return floor; }
            set
            {
                if (floor != value)
                {
                    floor = value;
                    OnPropertyChanged("Floor");
                }
            }
        }
        public string Clinic
        {
            get { return clinic; }
            set
            {
                if (clinic != value)
                {
                    clinic = value;
                    OnPropertyChanged("Clinic");
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
            // FLOOR
            if (String.IsNullOrWhiteSpace(this.floor))
            {
                this.ValidationErrors["Floor"] = "Required field!";
            }
            else if (Regex.IsMatch(this.floor.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["Floor"] = "Must start with number!";
            }
            // CLINIC
            if (String.IsNullOrWhiteSpace(this.clinic))
            {
                this.ValidationErrors["Clinic"] = "Required field!";
            }
        }
        #endregion
       
    }
}
