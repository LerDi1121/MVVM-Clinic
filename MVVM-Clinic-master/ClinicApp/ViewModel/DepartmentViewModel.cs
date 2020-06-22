using ClinicApp.Core;
using ClinicApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class DepartmentViewModel : ValidationBase
    {
        #region Fields and properties

        private string name;
        private string floor;
        private List<string> clinics = new List<string>();
        private string selectedType;

        private GetAllDepartments_Result selectedDepartment;
        private string btnContent;
        private bool isUpdate = false;

        private ObservableCollection<GetAllDepartments_Result> departmani = new ObservableCollection<GetAllDepartments_Result>();
      
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
        public string Floor
        {
            get { return floor; }
            set
            {
                if (floor != value)
                {
                    floor = value;
                    OnPropertyChanged("Floor");
                }
            }
        }
        public List<string> Clinics
        {
            get { return clinics; }
            set
            {
                if (clinics != value)
                {
                    clinics = value;
                    OnPropertyChanged("Clinics");
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
        public GetAllDepartments_Result SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                if (selectedDepartment != value)
                {
                    selectedDepartment = value;
                    OnPropertyChanged("SelectedDepartment");
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
        public ObservableCollection<GetAllDepartments_Result> Departmani
        {
            get { return departmani; }
            set
            {
                if (departmani != value)
                {
                    departmani = value;
                    OnPropertyChanged("Departmani");
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

            // FLOOR
            if (String.IsNullOrWhiteSpace(this.floor))
            {
                this.ValidationErrors["Floor"] = "Required field!";
            }
            else if (Regex.IsMatch(this.floor.Substring(0, this.floor.Length), "[^0-9]"))
            {
                this.ValidationErrors["Floor"] = "Must have a number!";
            }           
            else if (this.floor.Length > 3)
            {
                this.ValidationErrors["Floor"] = "Must be less than 3 characters";
            }

            // CLINIC
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Clinics"] = "Required field!";
            }
        }
        #endregion

        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public DepartmentViewModel()
        {
            BtnContent = "Add";
            AddCommand = new MyICommand(OnAdd);
            ChangeCommand = new MyICommand(OnSaveChanges);
            DeleteCommand = new RelayCommand(OnDelete);

            //combobox
            Clinics = DbContextHandler.Instance.GetAllClinicsList();
            //tabela
            DbContextHandler.Instance.GetAllDepartments().ForEach(departman => Departmani.Add(departman));
        }

        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                if (!isUpdate)
                {
                    int clinicId = DbContextHandler.Instance.GetClinicIdByName(this.selectedType);

                    DbContextHandler.Instance.CreateDepartment(Name, Floor, clinicId);

                    Departmani.Clear();
                    DbContextHandler.Instance.GetAllDepartments().ForEach(departman => Departmani.Add(departman));
                    Name = " ";
                    Floor = " ";
                    SelectedType = null;
                }
                else
                {
                    BtnContent = "Update";
                    MessageBox.Show("Update data!");
                  
                    DbContextHandler.Instance.UpdateDepartment((int)SelectedDepartment.DepartmanId, name, floor);

                    Departmani.Clear();
                    DbContextHandler.Instance.GetAllDepartments().ForEach(departman => Departmani.Add(departman));

                    isUpdate = false;
                    BtnContent = "Add";
                    Name = " ";
                    Floor = " ";
                    SelectedType = null;
                }
            }
        }
        public void OnSaveChanges()
        {
            Name = SelectedDepartment.Name;
            Floor = ((int)SelectedDepartment.Floor).ToString();
          
            isUpdate = true;
            BtnContent = "Update";
        }

        public void OnDelete()
        {
            int departmanId = (int)Departmani.ElementAt(CurrentIndex).DepartmanId;

            if(DbContextHandler.Instance.DeleteDepartmentById(departmanId))
            {
                MessageBox.Show("Delete data!");
                Departmani.RemoveAt(CurrentIndex);
            }
        }
        #endregion
    }
}
