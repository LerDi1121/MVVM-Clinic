using ClinicApp.Core;
using ClinicApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class DiagnosisViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string description;

        private Dijagnoza_Specijaliste selectedItem;
        private string btnContent;
        private bool isUpdate = false;

        private ObservableCollection<Dijagnoza_Specijaliste> dijagnoze = new ObservableCollection<Dijagnoza_Specijaliste>();

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
        public Dijagnoza_Specijaliste SelectedItem
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
        public ObservableCollection<Dijagnoza_Specijaliste> Dijagnoze
        {
            get { return dijagnoze; }
            set
            {
                if (dijagnoze != value)
                {
                    dijagnoze = value;
                    OnPropertyChanged("Dijagnoze");
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
            //// PATIENTS
            //if (String.IsNullOrWhiteSpace(this.selectedType))
            //{
            //    this.ValidationErrors["Patients"] = "Required field!";
            //}
            //// DOCTORS
            //if (String.IsNullOrWhiteSpace(this.selectedType2))
            //{
            //    this.ValidationErrors["Doctors"] = "Required field!";
            //}
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public DiagnosisViewModel()
        {
            BtnContent = "Add";
            AddCommand = new MyICommand(OnAdd);
            ChangeCommand = new MyICommand(OnSaveChanges);
            DeleteCommand = new RelayCommand(OnDelete);
        
            //tabela
            DbContextHandler.Instance.GetAllDiagnozis().ForEach(dijagnoza => Dijagnoze.Add(dijagnoza));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                if (!isUpdate)
                {
                    DbContextHandler.Instance.CreateDiagnozis(Name, Description);

                    Dijagnoze.Clear();
                    DbContextHandler.Instance.GetAllDiagnozis().ForEach(dijagnoza => Dijagnoze.Add(dijagnoza));
                    Name = "";
                    Description = "";
                }
                else
                {
                    BtnContent = "Update";
                    MessageBox.Show("Update data!");

                    DbContextHandler.Instance.UpdateDiagnosis(SelectedItem.Dijagnoza_Id, name, description);

                    Dijagnoze.Clear();
                    DbContextHandler.Instance.GetAllDiagnozis().ForEach(dijagnoza => Dijagnoze.Add(dijagnoza));

                    isUpdate = false;
                    BtnContent = "Add";
                    Name = "";
                    Description = "";
                }
            }
        }
        public void OnSaveChanges()
        {
            Name = SelectedItem.Naziv;
            Description = SelectedItem.Opis;

            isUpdate = true;
            BtnContent = "Update";
        }
        public void OnDelete()
        {
            int diagnosisId = Dijagnoze.ElementAt(CurrentIndex).Dijagnoza_Id;

            DbContextHandler.Instance.DeleteDiagnosisById(diagnosisId);

            MessageBox.Show("Delete data!");
            Dijagnoze.RemoveAt(CurrentIndex);
        }
        #endregion
    }
}
