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
    public class NewReviewViewModel : ValidationBase
    {
        #region Fields and properties

        private List<string> doctors = new List<string>();
        private string selectedType;
        private string description;
        private DateTime selectedDate = DateTime.Now;
        private List<string> time;
        private string selectedType2;

        private Pregled selectedItem;
        private string btnContent;
        private bool isUpdate = false;

        private ObservableCollection<Pregled> pregledi = new ObservableCollection<Pregled>();

        private int currentIndex;
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

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged("SelectedDate");
                    int doctorId = DbContextHandler.Instance.GetDoctorIdByName(this.selectedType);
                    Time = StaticTerms.GetFreeTerms(selectedDate, doctorId).ToList();
                }
            }
        }
        public List<string> Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        public string SelectedType2
        {
            get { return selectedType2; }
            set
            {
                if (selectedType2 != value)
                {
                    selectedType2 = value;
                    OnPropertyChanged("SelectedType2");
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
        #endregion Fields and properties

        protected override void ValidateSelf()
        {
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

            // TIME
            if (String.IsNullOrWhiteSpace(this.selectedType2))
            {
                this.ValidationErrors["Time"] = "Required field!";
            }
        }

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public NewReviewViewModel()
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

                    var splits = selectedDate.ToString().Split(' ');
                    var selectedTerm = splits[0] + " " + SelectedType2;
                    DateTime datum = DateTime.Parse(selectedTerm);
                    DbContextHandler.Instance.CreateReview(Description, datum, doctorId);

                    Pregledi.Clear();
                    DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));

                    Description = "";
                    SelectedType = null;
                }
                else
                {
                    BtnContent = "Update";
                    MessageBox.Show("Update data!");

                    //    DbContextHandler.Instance.UpdateReview(SelectedItem.Pregled_Id, description, selectedType2);

                    Pregledi.Clear();
                    DbContextHandler.Instance.GetAllReviews().ForEach(pregled => Pregledi.Add(pregled));

                    isUpdate = false;
                    BtnContent = "Add";

                    Description = "";
                    SelectedType = null;
                }
            }
        }
        public void OnSaveChanges()
        {
            //   Termin = SelectedItem.Termin;
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


