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
    public class PatientPageViewModel : ValidationBase
    {
        #region Fields and properties

        private object newReviewTab;
        private int selectedTab3;
        private object logOutTab;

        public object NewReviewTab
        {
            get { return newReviewTab; }
            set
            {
                if (newReviewTab != value)
                {
                    newReviewTab = value;
                    OnPropertyChanged("NewReviewTab");
                }
            }
        }
        public int SelectedTab3
        {
            get { return selectedTab3; }
            set
            {
                if (selectedTab3 != value)
                {
                    selectedTab3 = value;
                    OnPropertyChanged("SelectedTab3");
                }
            }
        }
        public object LogOutTab
        {
            get { return logOutTab; }
            set
            {
                if (logOutTab != value)
                {
                    logOutTab = value;
                    OnPropertyChanged("LogOutTab");
                }
            }
        }
        public static RelayCommand<int> ChangeTabCommand { get; set; }
        #endregion

        #region Constructor

        public MyICommand AddCommand { get; set; }
        public MyICommand RemoveCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public MyICommand LogOutCommand { get; set; }

        public PatientPageViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            RemoveCommand = new MyICommand(OnRemove);
            ChangeCommand = new MyICommand(OnChange);

            ChangeTabCommand = new RelayCommand<int>(OnChangeTab);

            NewReviewTab = new NewReview();

            LogOutCommand = new MyICommand(OnLogOut);
        }
        #endregion

        #region Methods
        public void OnChangeTab(int tabNum)
        {
            SelectedTab3 = tabNum;
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
        public void OnLogOut()
        {
            SingletonUser.Instance = null;
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.LOGIN_VIEW);
        }

        protected override void ValidateSelf()
        {
            // throw new NotImplementedException();
        }
        #endregion
    }
}
