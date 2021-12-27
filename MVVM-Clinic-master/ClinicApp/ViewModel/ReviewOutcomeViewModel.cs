using ClinicApp.Core;
//using ClinicApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ClinicApp.ViewModel
{
    public class ReviewOutcomeViewModel : ValidationBase
    {/*
        #region Fields and properties
        private string name;
        private string description;
        private List<string> patients = new List<string>();
        private string selectedType;

        private bool isDiagnozis;

        private ExtendedOutcome selectedItem;
        private string btnContent;
        private bool isUpdate = false;

        private ObservableCollection<ExtendedOutcome> ishodi = new ObservableCollection<ExtendedOutcome>();

        private int currentIndex;

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

        public bool IsDiagnozis
        {
            get { return isDiagnozis; }
            set
            {
                if (isDiagnozis != value)
                {
                    isDiagnozis = value;
                    OnPropertyChanged("IsDiagnozis");
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
        public string BtnContent
        {
            get { return btnContent; }
            set
            {
                if (btnContent != value)
                {
                    btnContent = value;
                    OnPropertyChanged("BtnContent");
                }
            }
        }
        public ExtendedOutcome SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
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
    
        public ObservableCollection<ExtendedOutcome> Ishodi
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

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    OnPropertyChanged("CurrentIndex");
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
            else if (Regex.IsMatch(this.name.Substring(0, this.name.Length), "[0-9]"))
            {
                this.ValidationErrors["Name"] = "Can't contain a number!";
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
           
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
       
        public ReviewOutcomeViewModel()
        {
            BtnContent = "Add";
            AddCommand = new MyICommand(OnAdd);
            ChangeCommand = new MyICommand(OnSaveChanges);
            DeleteCommand = new RelayCommand(OnDelete);

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
                if (!isUpdate)
                {
                    int patientId = DbContextHandler.Instance.GetPatientIdByName(this.selectedType);

                    DbContextHandler.Instance.CreateReviewOutcome(Name, Description, patientId, isDiagnozis);

                    Ishodi.Clear();
                    DbContextHandler.Instance.GetAllReviewOutcome().ForEach(ishod => Ishodi.Add(ishod));
                    Name = "";
                    Description = "";
                    SelectedType = null;
                }
                else
                {
                    BtnContent = "Update";
                    MessageBox.Show("Update data!");

                    int patientId = DbContextHandler.Instance.GetPatientIdByName(this.selectedType);
                    DbContextHandler.Instance.UpdateOutcome(SelectedItem.Ishod_Id, name, description, patientId);


                    Ishodi.Clear();
                    DbContextHandler.Instance.GetAllReviewOutcome().ForEach(ishod => Ishodi.Add(ishod));
                    Name = "";
                    Description = "";
                    SelectedType = null;
                }
            }
        }
        public void OnSaveChanges()
        {
            Name = SelectedItem.Name;
            Description = SelectedItem.Description;

            isUpdate = true;
            BtnContent = "Update";
        }

        public void OnDelete()
        {
            int ishodId = Ishodi.ElementAt(CurrentIndex).Ishod_Id;

            DbContextHandler.Instance.DeleteOutcomeById(ishodId);

            MessageBox.Show("Delete data!");
            Ishodi.RemoveAt(CurrentIndex);
        }
        #endregion*/
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
