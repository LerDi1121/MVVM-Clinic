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
    public class GeneralPracticionerViewModel : ValidationBase
    {
        #region Fields and properties

        private int selectedTab1;
        private object additionalReviewTab;
        private object logOutTab;

        public int SelectedTab1
        {
            get { return selectedTab1; }
            set
            {
                if (selectedTab1 != value)
                {
                    selectedTab1 = value;
                    OnPropertyChanged("SelectedTab1");
                }
            }
        }
        public object AdditionalReviewTab
        {
            get { return additionalReviewTab; }
            set
            {
                if (additionalReviewTab != value)
                {
                    additionalReviewTab = value;
                    OnPropertyChanged("AdditionalReviewTab");
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

        public GeneralPracticionerViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            RemoveCommand = new MyICommand(OnRemove);
            ChangeCommand = new MyICommand(OnChange);

            ChangeTabCommand = new RelayCommand<int>(OnChangeTab);

            AdditionalReviewTab = new AdditionalReview();

            LogOutCommand = new MyICommand(OnLogOut);
        }
        #endregion

        #region Methods
        public void OnChangeTab(int tabNum)
        {
            SelectedTab1 = tabNum;
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
