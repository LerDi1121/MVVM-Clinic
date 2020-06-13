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

namespace ClinicApp.ViewModel
{
    public class AgreementViewModel : ValidationBase
    {
        #region Fields and properties

        private string type;
        private DateTime expirationDate;
        private bool specialization;
        private string doctor;

        private ObservableCollection<Ugovor> ugovori = new ObservableCollection<Ugovor>();

        private int currentIndex;

        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                if (expirationDate != value)
                {
                    expirationDate = value;
                    OnPropertyChanged("ExpirationDate");
                }
            }
        }
        public bool Specialization
        {
            get { return specialization; }
            set
            {
                if (specialization != value)
                {
                    specialization = value;
                    OnPropertyChanged("Specialization");
                }
            }

        }
        public string Doctor
        {
            get { return doctor; }
            set
            {
                if (doctor != value)
                {
                    doctor = value;
                    OnPropertyChanged("Doctor");
                }
            }
        }

        public ObservableCollection<Ugovor> Ugovori
        {
            get { return ugovori; }
            set
            {
                if (ugovori != value)
                {
                    ugovori = value;
                    OnPropertyChanged("Ugovori");
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
            // EXPIRATION DATE
            //if (String.IsNullOrWhiteSpace(this.expirationDate))
            //{
            //    this.ValidationErrors["ExpirationDate"] = "Required field!";
            //}
            //else if (Regex.IsMatch(this.expirationDate.Substring(0, 1), "[0-9]"))
            //{
            //    this.ValidationErrors["ExpirationDate"] = "Can't start with number!";
            //}
            //else if (this.expirationDate.Length < 3)
            //{
            //    this.ValidationErrors["ExpirationDate"] = "Must have more than 3 characters";
            //}
            //else if (this.expirationDate.Length > 20)
            //{
            //    this.ValidationErrors["ExpirationDate"] = "Must be less than 20 characters";
            //}

            //// SPECIALIZATION
            //if (String.IsNullOrWhiteSpace(this.specialization))
            //{
            //    this.ValidationErrors["Specialization"] = "Required field!";
            //}
            //else if (Regex.IsMatch(this.specialization.Substring(0, 1), "[0-9]"))
            //{
            //    this.ValidationErrors["Specialization"] = "Can't start with number!";
            //}
            //else if (this.specialization.Length < 3)
            //{
            //    this.ValidationErrors["Specialization"] = "Must have more than 3 characters";
            //}
            //else if (this.specialization.Length > 20)
            //{
            //    this.ValidationErrors["Specialization"] = "Must be less than 20 characters";
            //}

            // DOCTOR
            if (String.IsNullOrWhiteSpace(this.doctor))
            {
                this.ValidationErrors["Doctor"] = "Required field!";
            }
            else if (Regex.IsMatch(this.doctor.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Doctor"] = "Can't start with number!";
            }
            else if (this.doctor.Length < 5)
            {
                this.ValidationErrors["Doctor"] = "Must have more than 5 characters";
            }
            else if (this.doctor.Length > 40)
            {
                this.ValidationErrors["Doctor"] = "Must be less than 40 characters";
            }
        }

        #endregion

        #region Constructor and metods

        public MyICommand AddCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public AgreementViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new RelayCommand(OnDelete);

            DbContextHandler.Instance.GetAllAgreements().ForEach(ugovor => Ugovori.Add(ugovor));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                DbContextHandler.Instance.CreateAgreement(Type, ExpirationDate, Specialization, Doctor);

                Ugovori.Clear();
                DbContextHandler.Instance.GetAllAgreements().ForEach(ugovor => Ugovori.Add(ugovor));
            }
        }

        public void OnDelete()
        {
            int ugovorId = Ugovori.ElementAt(CurrentIndex).Ugovor_Id;

            DbContextHandler.Instance.DeleteAgreementById(ugovorId);

            Ugovori.RemoveAt(CurrentIndex);
        }
        #endregion      
    }
}
