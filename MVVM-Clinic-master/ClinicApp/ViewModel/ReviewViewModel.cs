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
    public class ReviewViewModel : ValidationBase
    {
        #region Fields and properties
        private string dateAndTime;
        private string description;
        private List<string> doctors = new List<string>();
        private string selectedType;

        private Pregled selectedItem;
        private string btnContent;
        private bool isUpdate = false;

        private ObservableCollection<Pregled> pregledi = new ObservableCollection<Pregled>();

        private int currentIndex;

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
       
        public List<string> Doctors
        {
            get { return doctors; }
            set
            {
                if (doctors != value)
                {
                    doctors = value;
                    OnPropertyChanged("Doctors");
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
        public Pregled SelectedItem
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
        public ObservableCollection<Pregled> Pregledi
        {
            get { return pregledi; }
            set
            {
                if (pregledi != value)
                {
                    pregledi = value;
                    OnPropertyChanged("Pregledi");
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
            // DATE
            if (String.IsNullOrWhiteSpace(this.dateAndTime))
            {
                this.ValidationErrors["DateAndTime"] = "Required field!";
            }
            else if (Regex.IsMatch(this.dateAndTime.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["DateAndTime"] = "Valid format: day/month/year!";
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

            // DOCTOR
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Doctors"] = "Required field!";
            }
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public ReviewViewModel()
        {
            BtnContent = "Add";
            AddCommand = new MyICommand(OnAdd);
            ChangeCommand = new MyICommand(OnSaveChanges);
            DeleteCommand = new RelayCommand(OnDelete);

            //combobox
            Doctors = DbContextHandler.Instance.GetAllDoctorsList();

            //tabela
            DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                if (!isUpdate)
                {
                    int doctorId = DbContextHandler.Instance.GetDoctorIdByName(this.selectedType);

                    DbContextHandler.Instance.CreateReview(Description, DateAndTime, doctorId);

                    Pregledi.Clear();
                    DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));
                    DateAndTime = "";
                    Description = "";
                    SelectedType = null;
                }
                else
                {
                    BtnContent = "Update";
                    MessageBox.Show("Update data!");

                    //int doctorId = DbContextHandler.Instance.GetDoctorIdByName(this.selectedType);
                    DbContextHandler.Instance.UpdateReview(SelectedItem.Pregled_Id, description, dateAndTime);

                    Pregledi.Clear();
                    DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));

                    isUpdate = false;
                    BtnContent = "Add";
                    DateAndTime = "";
                    Description = "";
                    SelectedType = null;
                }
            }
        }
        public void OnSaveChanges()
        {
            DateAndTime = SelectedItem.Vreme;
            Description = SelectedItem.Opis;

            isUpdate = true;
            BtnContent = "Update";
        }
        public void OnDelete()
        {
            int pregledId = Pregledi.ElementAt(CurrentIndex).Pregled_Id;

            DbContextHandler.Instance.DeleteReviewById(pregledId);

            MessageBox.Show("Delete data!");
            Pregledi.RemoveAt(CurrentIndex);
        }
        #endregion
    }
}
