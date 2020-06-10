using ClinicApp.Core;
using ClinicApp.View.All;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ClinicApp.ViewModel
{
    public class MainWindowViewModel: ValidationBase
    {
        #region Fields and properties
        private int selectedTab;
        private object allDepartmentTab;
        private object allDoctorTab;
        private object allPatientTab;
        private object allReviewTab;
        private object allReviewOutcomeTab;
        private object allDiagnosisTab;
        private object allTherapyTab;
        private object allMedicalRecordTab;
        private object allTAgreementTab;

        public int SelectedTab
        {
            get { return selectedTab; }
            set
            {
                if (selectedTab != value)
                {
                    selectedTab = value;
                    OnPropertyChanged("SelectedTab");
                }
            }
        }
        public object AllDepartmentTab
        {
            get { return allDepartmentTab; }
            set
            {
                if (allDepartmentTab != value)
                {
                    allDepartmentTab = value;
                    OnPropertyChanged("AllDepartmentTab");
                }
            }
        }
        public object AllDoctorTab
        {
            get { return allDoctorTab; }
            set
            {
                if (allDoctorTab != value)
                {
                    allDoctorTab = value;
                    OnPropertyChanged("AllDoctorTab");
                }
            }
        }

        public object AllPatientTab
        {
            get { return allPatientTab; }
            set
            {
                if (allPatientTab != value)
                {
                    allPatientTab = value;
                    OnPropertyChanged("AllPatientTab");
                }
            }
        }
        public object AllReviewTab
        {
            get { return allReviewTab; }
            set
            {
                if (allReviewTab != value)
                {
                    allReviewTab = value;
                    OnPropertyChanged("AllReviewTab");
                }
            }
        }
        public object AllReviewOutcomeTab
        {
            get { return allReviewOutcomeTab; }
            set
            {
                if (allReviewOutcomeTab != value)
                {
                    allReviewOutcomeTab = value;
                    OnPropertyChanged("AllReviewOutcomeTab");
                }
            }
        }
        public object AllDiagnosisTab
        {
            get { return allDiagnosisTab; }
            set
            {
                if (allDiagnosisTab != value)
                {
                    allDiagnosisTab = value;
                    OnPropertyChanged("AllDiagnosisTab");
                }
            }
        }
        public object AllTherapyTab
        {
            get { return allTherapyTab; }
            set
            {
                if (allTherapyTab != value)
                {
                    allTherapyTab = value;
                    OnPropertyChanged("AllTherapyTab");
                }
            }
        }
        public object AllMedicalRecordTab
        {
            get { return allMedicalRecordTab; }
            set
            {
                if (allMedicalRecordTab != value)
                {
                    allMedicalRecordTab = value;
                    OnPropertyChanged("AllMedicalRecordTab");
                }
            }
        }
        public object AllTAgreementTab
        {
            get { return allTAgreementTab; }
            set
            {
                if (allTAgreementTab != value)
                {
                    allTAgreementTab = value;
                    OnPropertyChanged("AllTAgreementTab");
                }
            }
        }
        public static RelayCommand<int> ChangeTabCommand { get; set; }

        #endregion Fields and properties

        #region Constructor

        public MyICommand AddCommand { get; set; }
        public MyICommand RemoveCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }

        public MainWindowViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            RemoveCommand = new MyICommand(OnRemove);
            ChangeCommand = new MyICommand(OnChange);

            ChangeTabCommand = new RelayCommand<int>(OnChangeTab);

            AllDepartmentTab = new AllDepartment();
            AllDoctorTab = new AllDoctorView();
            AllPatientTab = new AllPatientView();
            AllReviewTab = new AllReviewView();
            AllReviewOutcomeTab = new AllReviewOutcome();
            AllDiagnosisTab = new AllDiagnosisView();
            AllTherapyTab = new AllTherapyView();
            AllTAgreementTab = new AllAgreementView();
            AllMedicalRecordTab = new AllMedicalRecords();
        }
        #endregion

        #region Methods
        public void OnChangeTab(int tabNum)
        {
            SelectedTab = tabNum;
        }
        public void OnAdd()
        {
            
        }
        public void OnRemove()
        {
        }
        public void OnChange()
        {
        }

        protected override void ValidateSelf()
        {
           // throw new NotImplementedException();
        }
        #endregion
    }
}
