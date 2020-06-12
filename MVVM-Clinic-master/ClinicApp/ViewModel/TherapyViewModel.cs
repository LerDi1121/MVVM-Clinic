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
    public enum typeTherapy
    {
        DRUG,
        MASSAGE,
        EXERCISES,
        SPA
    }
    public class TherapyViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string description;
        private List<string> types = new List<string>();
        private string selectedType;

        private ObservableCollection<Terapija> terapije = new ObservableCollection<Terapija>();

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
        public List<string> Types
        {
            get { return types; }
            set
            {
                if (types != value)
                {
                    types = value;
                    OnPropertyChanged("Types");
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

        public ObservableCollection<Terapija> Terapije
        {
            get { return terapije; }
            set
            {
                if (terapije != value)
                {
                    terapije = value;
                    OnPropertyChanged("Terapije");
                }
            }
        }
        #endregion

        #region Validations
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

            // TYPES
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Types"] = "Required field!";
            }

            //// DIAGNOSIS
            //if (String.IsNullOrWhiteSpace(this.diagnosis))
            //{
            //    this.ValidationErrors["Diagnosis"] = "Required field!";
            //}
            //else if (Regex.IsMatch(this.diagnosis.Substring(0, 1), "[0-9]"))
            //{
            //    this.ValidationErrors["Diagnosis"] = "Can't start with number!";
            //}
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public TherapyViewModel()
        {
            AddCommand = new MyICommand(OnAdd);

            //combobox            
            //Types = typeTherapy.DRUG; 

            //tabela
            DbContextHandler.Instance.GetAllTherapies().ForEach(terapija => Terapije.Add(terapija));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
               

               // DbContextHandler.Instance.CreateTherapy(Name, Description, Types);

                Terapije.Clear();
                DbContextHandler.Instance.GetAllTherapies().ForEach(terapija => Terapije.Add(terapija));
            }
        }
        #endregion
    }
}
