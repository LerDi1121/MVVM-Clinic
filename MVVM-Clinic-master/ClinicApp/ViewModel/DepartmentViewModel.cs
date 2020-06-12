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
    public class DepartmentViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string floor;
        //private List<string> clinics = new List<string>();
        //private string selectedType;

        private ObservableCollection<Departman> departmani = new ObservableCollection<Departman>();

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
        //public List<string> Clinics
        //{
        //    get { return clinics; }
        //    set
        //    {
        //        if (clinics != value)
        //        {
        //            clinics = value;
        //            OnPropertyChanged("Clinics");
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

        public ObservableCollection<Departman> Departmani
        {
            get { return departmani; }
            set
            {
                if (departmani != value)
                {
                    departmani = value;
                    OnPropertyChanged("Departmani");
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

            // FLOOR
            if (String.IsNullOrWhiteSpace(this.floor))
            {
                this.ValidationErrors["Floor"] = "Required field!";
            }
            else if (Regex.IsMatch(this.floor.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["Floor"] = "Must start with number!";
            }
            else if (this.floor.Length < 1)
            {
                this.ValidationErrors["Floor"] = "Must have more than 1 characters";
            }
            else if (this.floor.Length > 3)
            {
                this.ValidationErrors["Floor"] = "Must be less than 3 characters";
            }

            //// CLINIC
            //if (String.IsNullOrWhiteSpace(this.selectedType))
            //{
            //    this.ValidationErrors["Clinics"] = "Required field!";
            //}
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public DepartmentViewModel()
        {
            AddCommand = new MyICommand(OnAdd);

            //combobox
            // Clinics = DbContextHandler.Instance.GetAllClinicsForDepartment();

            //tabela
            DbContextHandler.Instance.GetAllDepartments().ForEach(departman => Departmani.Add(departman));
        }

        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                //int clinicId = DbContextHandler.Instance.GetClinicIdByName(this.selectedType);

                DbContextHandler.Instance.CreateDepartment(Name, Floor); // + clinicId

                Departmani.Clear();
                DbContextHandler.Instance.GetAllDepartments().ForEach(departman => Departmani.Add(departman));
            }
        }
        #endregion
    }
}
