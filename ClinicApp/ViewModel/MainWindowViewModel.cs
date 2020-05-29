using ClinicApp.Core;
using ClinicApp.View.All;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public enum ViewType
    {
        DOCTOR_VIEW,
        PATIENT_VIEW,
        DIAGNOSIS_VIEW,
        REVIEW_VIEW,
        REVIEW_OUTCOME_VIEW,
        THERAPY_VIEW
    }

    public class MainWindowViewModel: ValidationBase
    {
        #region Fields and properties
        private object currentView;
        private int selectedTab;
        private object allDoctorTab;
        private object allPatientTab;
        private object allReviewTab;
        private object allReviewOutcomeTab;
        private object allDiagnosisTab;
        private object allTherapyTab;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
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
        #endregion Fields and properties

        public static RelayCommand<int> ChangeTabCommand { get; set; }
        public static RelayCommand<ViewType> ChangeViewCommand { get; set; }

        public MainWindowViewModel()
        {
            ChangeTabCommand = new RelayCommand<int>(OnChangeTab);
            // ChangeViewCommand = new RelayCommand<ViewType>(OnChangeView);
            AllDoctorTab = new AllDoctorView();
            AllPatientTab = new AllDoctorView();
            AllReviewTab = new AllDoctorView();
            AllReviewOutcomeTab = new AllDoctorView();
            AllDiagnosisTab = new AllDoctorView();
            AllTherapyTab = new AllDoctorView();


        }

        public void OnChangeTab(int tabNum)
        {
            SelectedTab = tabNum; 
            //if(SelectedTab == 0)
            //{
            //    ChangeViewCommand.Execute(ViewType.DOCTOR_VIEW);
            //}
        }

        public void OnChangeView(ViewType nextView)
        {
            switch (nextView)
            {
                case ViewType.DOCTOR_VIEW:
                    CurrentView = new AllDoctorView();
                    break;

                //case ViewType.PATIENT_VIEW:
                //    CurrentView = new AllDoctorView();
                //    break;

                //case ViewType.REVIEW_VIEW:
                //    CurrentView = new AllDoctorView();
                //    break;

                //case ViewType.REVIEW_OUTCOME_VIEW:
                //    CurrentView = new AllDoctorView();
                //    break;

                //case ViewType.DIAGNOSIS_VIEW:
                //    CurrentView = new AllDoctorView();
                //    break;
                //case ViewType.THERAPY_VIEW:
                //    CurrentView = new AllDoctorView();
                //    break;
                default:
                    break;
            }
        }

        protected override void ValidateSelf()
        {
           // throw new NotImplementedException();
        }
    }
}
