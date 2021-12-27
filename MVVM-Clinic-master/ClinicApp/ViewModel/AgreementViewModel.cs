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

namespace ClinicApp.ViewModel
{
    public class AgreementViewModel : ValidationBase
    {
        /*  #region Fields and properties

          private string type;
          private DateTime selectedDate;
          private bool specialization;
          private bool isPartTime;
          private string doctor;

          private Ugovor selectedItem;
          private string btnContent;
          private bool isUpdate = false;

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
          public bool IsPartTime
          {
              get { return isPartTime; }
              set
              {
                  if (isPartTime != value)
                  {
                      isPartTime = value;
                      OnPropertyChanged("IsPartTime");
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
          public Ugovor SelectedItem
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
          #endregion

          #region Validation
          protected override void ValidateSelf()
          {
              // DOCTOR
              if (String.IsNullOrWhiteSpace(this.doctor))
              {
                  this.ValidationErrors["Doctor"] = "Required field!";
              }
              else if (Regex.IsMatch(this.doctor.Substring(0, this.doctor.Length), "[0-9]"))
              {
                  this.ValidationErrors["Doctor"] = "Can't contain a number!";
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
          public MyICommand ChangeCommand { get; set; }

          public AgreementViewModel()
          {
              BtnContent = "Add";
              AddCommand = new MyICommand(OnAdd);
              ChangeCommand = new MyICommand(OnSaveChanges);
              DeleteCommand = new RelayCommand(OnDelete);

              SelectedDate = DateTime.Now;

              DbContextHandler.Instance.GetAllAgreements().ForEach(ugovor => Ugovori.Add(ugovor));
          }
          public void OnAdd()
          {
              this.Validate();
              if (this.IsValid)
              {
                  if (!isUpdate)
                  {
                      DbContextHandler.Instance.CreateAgreement(IsPartTime, SelectedDate, Specialization, Doctor);

                      Ugovori.Clear();
                      DbContextHandler.Instance.GetAllAgreements().ForEach(ugovor => Ugovori.Add(ugovor));
                      Doctor = "";
                  }
                  else
                  {
                      BtnContent = "Update";
                      MessageBox.Show("Update data!");
                      DbContextHandler.Instance.UpdateAgreement(SelectedItem.Ugovor_Id, type, selectedDate, specialization, doctor);

                      Ugovori.Clear();
                      DbContextHandler.Instance.GetAllAgreements().ForEach(ugovor => Ugovori.Add(ugovor));

                      isUpdate = false;
                      BtnContent = "Add";
                      Doctor = "";
                  }
              }
          }
          public void OnSaveChanges()
          {
              Type = SelectedItem.Vrsta_Ugovora;
              SelectedDate = SelectedItem.Datum_Vazenja;
              Specialization = SelectedItem.Specijalizacija;
              Doctor = SelectedItem.Doktor;

              isUpdate = true;
              BtnContent = "Update";
          }

          public void OnDelete()
          {
              int ugovorId = Ugovori.ElementAt(CurrentIndex).Ugovor_Id;

              DbContextHandler.Instance.DeleteAgreementById(ugovorId);
              MessageBox.Show("Delete data!");
              Ugovori.RemoveAt(CurrentIndex);
          }
          #endregion   */
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
