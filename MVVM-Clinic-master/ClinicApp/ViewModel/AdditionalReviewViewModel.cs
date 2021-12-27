using ClinicApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class AdditionalReviewViewModel : ValidationBase
    {
        #region Fields and properties

        private List<string> doctors = new List<string>();
        private string selectedType;
        private List<string> patients = new List<string>();
        private string selectedType2;
        private string description;
        private DateTime selectedDate;

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
                }
            }
        }

        #endregion Fields and properties

        protected override void ValidateSelf()
        {
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Doctors"] = "Required field!";
            }
            if (String.IsNullOrWhiteSpace(this.selectedType2))
            {
                this.ValidationErrors["Patients"] = "Required field!";
            }
            if (String.IsNullOrWhiteSpace(this.description))
            {
                this.ValidationErrors["Description"] = "Required field!";
            }
        }

        public MyICommand BackCommand { get; set; }
        public MyICommand AddExamCommand { get; set; }

        public AdditionalReviewViewModel()
        {
            BackCommand = new MyICommand(OnBack);
            AddExamCommand = new MyICommand(OnAddExam);

            SelectedDate = DateTime.Now;

            //combobox
         //   Doctors = DbContextHandler.Instance.GetAllDoctorsList();
          //  Patients = DbContextHandler.Instance.GetAllPatientsList();
        }

        public void OnBack()
        {
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.PATIENT_VIEW);
        }

        public void OnAddExam()
        {
            this.Validate();

            if (this.IsValid)
            {
            //    DbContextHandler.Instance.AddExamination(SingletonUser.Instance.UserId, SelectedType, Description, SelectedDate);
                MainWindowViewModel.ChangeViewCommand.Execute(ViewType.DOCTOR_VIEW);
            }
        }
    }
}
