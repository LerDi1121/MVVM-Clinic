using ClinicApp.Core;
//using ClinicApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class PatientViewModel : ValidationBase
    {
        /*  #region Fields and properties
          private string username;
          private string password;
          private string name;
          private string lastname;
          private string contact;
          private string street;
          private string number;
          private string city;
          private string email;

          private Pacijent selectedItem;
          private string btnContent;
          private bool isUpdate = false;

          private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();

          private int currentIndex;
          public string Username
          {
              get { return username; }
              set
              {
                  if (username != value)
                  {
                      username = value;
                      OnPropertyChanged("Username");
                  }
              }
          }
          public string Password
          {
              get { return password; }
              set
              {
                  if (password != value)
                  {
                      password = value;
                      OnPropertyChanged("Password");
                  }
              }
          }
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
          public string Lastname
          {
              get { return lastname; }
              set
              {
                  if (lastname != value)
                  {
                      lastname = value;
                      OnPropertyChanged("Lastname");
                  }
              }
          }
          public string Contact
          {
              get { return contact; }
              set
              {
                  if (contact != value)
                  {
                      contact = value;
                      OnPropertyChanged("Contact");
                  }
              }
          }
          public string Email
          {
              get { return email; }
              set
              {
                  if (email != value)
                  {
                      email = value;
                      OnPropertyChanged("Email");
                  }
              }
          }

          public string Street
          {
              get { return street; }
              set
              {
                  if (street != value)
                  {
                      street = value;
                      OnPropertyChanged("Street");
                  }
              }
          }
          public string Number
          {
              get { return number; }
              set
              {
                  if (number != value)
                  {
                      number = value;
                      OnPropertyChanged("Number");
                  }
              }
          }
          public string City
          {
              get { return city; }
              set
              {
                  if (city != value)
                  {
                      city = value;
                      OnPropertyChanged("City");
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
          public Pacijent SelectedItem
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
          public ObservableCollection<Pacijent> Pacijenti
          {
              get { return pacijenti; }
              set
              {
                  if (pacijenti != value)
                  {
                      pacijenti = value;
                      OnPropertyChanged("Pacijenti");
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
              // USERNAME
              if (String.IsNullOrWhiteSpace(this.username))
              {
                  this.ValidationErrors["Username"] = "Required field!";
              }
              else if (Regex.IsMatch(this.username.Substring(0, 1), "[0-9]"))
              {
                  this.ValidationErrors["Username"] = "Can't start with number!";
              }

              // PASSWORD
              if (String.IsNullOrWhiteSpace(this.password))
              {
                  this.ValidationErrors["Password"] = "Required field!";
              }
              else if (this.password.Trim().Length <= 6)
              {
                  this.ValidationErrors["Password"] = "Must have more than 6 characters!";
              }
              // NAME
              if (String.IsNullOrWhiteSpace(this.name))
              {
                  this.ValidationErrors["Name"] = "Required field!";
              }
              else if (Regex.IsMatch(this.name.Substring(0, this.name.Length), "[0-9]"))
              {
                  this.ValidationErrors["Name"] = "Can't contain a number!";
              }
              else if (this.name.Length < 3)
              {
                  this.ValidationErrors["Name"] = "Must have more than 3 characters";
              }
              else if (this.name.Length > 20)
              {
                  this.ValidationErrors["Name"] = "Must be less than 20 characters";
              }

              // LAST NAME
              if (String.IsNullOrWhiteSpace(this.lastname))
              {
                  this.ValidationErrors["Lastname"] = "Required field!";
              }
              else if (Regex.IsMatch(this.lastname.Substring(0, this.lastname.Length), "[0-9]"))
              {
                  this.ValidationErrors["Lastname"] = "Can't contain a number!";
              }
              else if (this.lastname.Length < 3)
              {
                  this.ValidationErrors["Lastname"] = "Must have more than 3 characters";
              }
              else if (this.lastname.Length > 20)
              {
                  this.ValidationErrors["Lastname"] = "Must be less than 20 characters";
              }

              // CONTACT
              if (String.IsNullOrWhiteSpace(this.contact))
              {
                  this.ValidationErrors["Contact"] = "Required field!";
              }
              else if (Regex.IsMatch(this.contact.Substring(0, this.contact.Length), "[^0-9]"))
              {
                  this.ValidationErrors["Contact"] = "Must have a number!";
              }

              // CITY
              if (String.IsNullOrWhiteSpace(this.city))
              {
                  this.ValidationErrors["City"] = "Required field!";
              }
              else if (Regex.IsMatch(this.city.Substring(0, 1), "[0-9]"))
              {
                  this.ValidationErrors["City"] = "Can't start with number!";
              }

              // STREET
              if (String.IsNullOrWhiteSpace(this.street))
              {
                  this.ValidationErrors["Street"] = "Required field!";
              }
              else if (Regex.IsMatch(this.street.Substring(0, 1), "[0-9]"))
              {
                  this.ValidationErrors["Street"] = "Can't start with number!";
              }

              // NUMBER
              if (String.IsNullOrWhiteSpace(this.number))
              {
                  this.ValidationErrors["Number"] = "Required field!";
              }
              else if (Regex.IsMatch(this.number.Substring(0, 1), "[^0-9]"))
              {
                  this.ValidationErrors["Number"] = "Must start with number!";
              } 
              // EMAIL
              if (String.IsNullOrWhiteSpace(this.email))
              {
                  this.ValidationErrors["Email"] = "Required field!";
              }
              else if (!(new EmailAddressAttribute().IsValid(this.email)))
              {
                  this.ValidationErrors["Email"] = "Invalid format for email address.";
              }
          }
          #endregion

          #region Constructor and metods
          public MyICommand AddCommand { get; set; }
          public MyICommand ChangeCommand { get; set; }
          public static RelayCommand DeleteCommand { get; set; }

          public PatientViewModel()
          {
              BtnContent = "Add";
              AddCommand = new MyICommand(OnAdd);
              ChangeCommand = new MyICommand(OnSaveChanges);
              DeleteCommand = new RelayCommand(OnDelete);       

              //tabela
              DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));
          }
          public void OnAdd()
          {
              this.Validate();
              if (this.IsValid)
              {
                  if (!isUpdate)
                  {
                      DbContextHandler.Instance.CreatePatient(Name, Lastname, Contact, Street, Number, City, Email, Username, Password);

                      Pacijenti.Clear();
                      DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));
                      Name = "";
                      Lastname = "";
                      Contact = "";
                      Email = "";
                      Username = "";
                      Password = "";
                      Street = "";
                      Number = "";
                      City = "";
                  }
                  else
                  {
                      BtnContent = "Update";
                      MessageBox.Show("Update data!");

                      DbContextHandler.Instance.UpdatePatient(SelectedItem.Pacijent_Id, name, lastname, contact, street, number, city, email, password, username);

                      Pacijenti.Clear();
                      DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));

                      isUpdate = false;
                      BtnContent = "Add";
                      Name = "";
                      Lastname = "";
                      Contact = "";
                      Email = "";
                      Username = "";
                      Password = "";
                      Street = "";
                      Number = "";
                      City = "";
                  }
              }
          }
          public void OnSaveChanges()
          {
              Username = SelectedItem.Korisnicko_Ime;
              Password = SelectedItem.Lozinka;
              Name = SelectedItem.Ime;
              Lastname = SelectedItem.Prezime;
              Contact = SelectedItem.Kontakt;
              Street = SelectedItem.Ulica;
              Number = SelectedItem.Broj;
              City = SelectedItem.Grad;
              Email = SelectedItem.Email;

              isUpdate = true;
              BtnContent = "Update";
          }
          public void OnDelete()
          {
              int patientId = Pacijenti.ElementAt(CurrentIndex).Pacijent_Id;

              DbContextHandler.Instance.DeletePatientById(patientId);
              MessageBox.Show("Delete data!");
              Pacijenti.RemoveAt(CurrentIndex);
          }
          #endregion*/
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
