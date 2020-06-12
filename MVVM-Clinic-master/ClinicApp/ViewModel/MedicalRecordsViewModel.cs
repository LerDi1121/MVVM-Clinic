using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class MedicalRecordsViewModel : ValidationBase
    {
        #region Fields and properties

        private string name;
        private string lastname;
        private string jMBG;
        private string history;

        private List<string> patients = new List<string>();
        private string selectedType;
        private List<string> clinics = new List<string>();
        private string selectedType2;
        private List<string> departments = new List<string>();
        private string selectedType3;

        private ObservableCollection<Zdravstveni_Karton> kartoni = new ObservableCollection<Zdravstveni_Karton>();

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
        public string JMBG
        {
            get { return jMBG; }
            set
            {
                if (jMBG != value)
                {
                    jMBG = value;
                    OnPropertyChanged("JMBG");
                }
            }

        }
        public string History
        {
            get { return history; }
            set
            {
                if (history != value)
                {
                    history = value;
                    OnPropertyChanged("History");
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

        public List<string> Departments
        {
            get { return departments; }
            set
            {
                if (departments != value)
                {
                    departments = value;
                    OnPropertyChanged("Departments");
                }
            }
        }
        public string SelectedType3
        {
            get { return selectedType3; }
            set
            {
                if (selectedType3 != value)
                {
                    selectedType3 = value;
                    OnPropertyChanged("SelectedType3");
                }
            }
        }
        public ObservableCollection<Zdravstveni_Karton> Kartoni
        {
            get { return kartoni; }
            set
            {
                if (kartoni != value)
                {
                    kartoni = value;
                    OnPropertyChanged("Kartoni");
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
            else if (Regex.IsMatch(this.name.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Name"] = "Can't start with number!";
            }
            else if (this.name.Length < 3)
            {
                this.ValidationErrors["Name"] = "Must have more than 3 characters";
            }
            else if (this.name.Length > 20)
            {
                this.ValidationErrors["Name"] = "Must be less than 20 characters";
            }

            // LASTNAME
            if (String.IsNullOrWhiteSpace(this.lastname))
            {
                this.ValidationErrors["Lastname"] = "Required field!";
            }
            else if (Regex.IsMatch(this.lastname.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Lastname"] = "Can't start with number!";
            }
            else if (this.lastname.Length < 3)
            {
                this.ValidationErrors["Lastname"] = "Must have more than 3 characters";
            }
            else if (this.lastname.Length > 20)
            {
                this.ValidationErrors["Lastname"] = "Must be less than 20 characters";
            }
            // JMBG
            if (String.IsNullOrWhiteSpace(this.jMBG))
            {
                this.ValidationErrors["JMBG"] = "Required field!";
            }
            else if (Regex.IsMatch(this.jMBG.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["JMBG"] = "Must start with number!";
            }

            // HISTORY
            if (String.IsNullOrWhiteSpace(this.history))
            {
                this.ValidationErrors["History"] = "Required field!";
            }
            else if (Regex.IsMatch(this.history.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["History"] = "Can't start with number!";
            }
            else if (this.history.Length < 3)
            {
                this.ValidationErrors["History"] = "Must have more than 3 characters";
            }
            else if (this.history.Length > 200)
            {
                this.ValidationErrors["History"] = "Must be less than 200 characters";
            }

            // PATIENTS
            if (String.IsNullOrWhiteSpace(this.selectedType))
            {
                this.ValidationErrors["Patients"] = "Required field!";
            }
            // CLINICS
            if (String.IsNullOrWhiteSpace(this.selectedType2))
            {
                this.ValidationErrors["Clinics"] = "Required field!";
            }
            // DEPARTMENTS
            if (String.IsNullOrWhiteSpace(this.selectedType3))
            {
                this.ValidationErrors["Departments"] = "Required field!";
            }
        }

        #endregion

        #region Constructor and metods

        public MyICommand AddCommand { get; set; }

        public MedicalRecordsViewModel()
        {
            AddCommand = new MyICommand(OnAdd);

            Patients = DbContextHandler.Instance.GetAllPatientsList();
            Clinics = DbContextHandler.Instance.GetAllClinicsList();
            Departments = DbContextHandler.Instance.GetAllDepartmentsList();

            DbContextHandler.Instance.GetAllMedicalRecords().ForEach(karton => Kartoni.Add(karton));
        }
        public void OnAdd()
        {
            this.Validate();
            if (this.IsValid)
            {
                int patientId = DbContextHandler.Instance.GetPatientIdByName(this.selectedType);
                int clinicId = DbContextHandler.Instance.GetClinicIdByName(this.selectedType2);
                int departmentId = DbContextHandler.Instance.GetDeparmentIdByName(this.selectedType3);

                DbContextHandler.Instance.CreateMedicalRecord(Name, Lastname, JMBG, History, patientId, clinicId, departmentId);

                Kartoni.Clear();
                DbContextHandler.Instance.GetAllMedicalRecords().ForEach(karton => Kartoni.Add(karton));
            }
        }
        #endregion      
    }
}
