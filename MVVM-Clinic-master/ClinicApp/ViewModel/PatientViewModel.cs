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
    public class PatientViewModel : ValidationBase
    {
        #region Fields and properties
        private string name;
        private string lastname;
        private string contact;
        private string address;

        private Pacijent selectedItem;
        private string btnContent;
        private bool isUpdate = false;

        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();

        private int currentIndex;

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

        public string Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
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

            // ADDRESS
            if (String.IsNullOrWhiteSpace(this.address))
            {
                this.ValidationErrors["Address"] = "Required field!";
            }
            else if (Regex.IsMatch(this.address.Substring(0, this.address.Length), "[0-9]"))
            {
                this.ValidationErrors["Address"] = "Can't contain a number!";
            }
            else if (this.address.Length < 3)
            {
                this.ValidationErrors["Address"] = "Must have more than 3 characters";
            }
            else if (this.address.Length > 40)
            {
                this.ValidationErrors["Address"] = "Must be less than 40 characters";
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
                    DbContextHandler.Instance.CreatePatient(Name, Lastname, Contact, Address);

                    Pacijenti.Clear();
                    DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));
                    Name = "";
                    Lastname = "";
                    Contact = "";
                    Address = "";
                }
                else
                {
                    BtnContent = "Update";
                    MessageBox.Show("Update data!");

                    DbContextHandler.Instance.UpdatePatient(SelectedItem.Pacijent_Id, name, lastname, contact, address);

                    Pacijenti.Clear();
                    DbContextHandler.Instance.GetAllPatients().ForEach(pacijent => Pacijenti.Add(pacijent));

                    isUpdate = false;
                    BtnContent = "Add";
                    Name = "";
                    Lastname = "";
                    Contact = "";
                    Address = "";
                }
            }
        }
        public void OnSaveChanges()
        {
            Name = SelectedItem.Ime;
            Lastname = SelectedItem.Prezime;
            Contact = SelectedItem.Kontakt;
            Address = SelectedItem.Adresa;

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
        #endregion
    }
}
