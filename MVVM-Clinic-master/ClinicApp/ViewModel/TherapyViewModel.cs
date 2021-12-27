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
    public class TherapyViewModel : ValidationBase
    {
        #region Fields and properties
         private string name;
         private string description;
         private string selectedType;
         private List<string> types = new List<string>() { "Drug", "Massage", "Exercises", "Spa" };

         private Terapija selectedItem;
         private string btnContent;
         private bool isUpdate = false;

         private ObservableCollection<Terapija> terapije = new ObservableCollection<Terapija>();

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
         public string Description
         {
             get { return description; }
             set
             {
                 if (description != value)
                 {
                     description = value;
                     OnPropertyChanged("Description");
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
         public List<string> Types
         {
             get { return types; }
             set
             {
                 if (types != value)
                 {
                     types = value;
                     OnPropertyChanged("Types");
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
         public Terapija SelectedItem
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

         public ObservableCollection<Terapija> Terapije
         {
             get { return terapije; }
             set
             {
                 if (terapije != value)
                 {
                     terapije = value;
                     OnPropertyChanged("Terapije");
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

         #region Validations
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

             // DESCRIPTION
             if (String.IsNullOrWhiteSpace(this.description))
             {
                 this.ValidationErrors["Description"] = "Required field!";
             }
             else if (Regex.IsMatch(this.description.Substring(0, 1), "[0-9]"))
             {
                 this.ValidationErrors["Description"] = "Can't start with number!";
             }
             else if (this.description.Length < 3)
             {
                 this.ValidationErrors["Description"] = "Must have more than 3 characters";
             }
             else if (this.description.Length > 200)
             {
                 this.ValidationErrors["Description"] = "Must be less than 200 characters";
             }

             // TYPES
             if (String.IsNullOrWhiteSpace(this.Types.ToString()))
             {
                 this.ValidationErrors["Types"] = "Required field!";
             }

         }
         #endregion

         #region Constructor and metods
         public MyICommand AddCommand { get; set; }
         public MyICommand ChangeCommand { get; set; }
         public static RelayCommand DeleteCommand { get; set; }

         public TherapyViewModel()
         {
             BtnContent = "Add";
             AddCommand = new MyICommand(OnAdd);
             ChangeCommand = new MyICommand(OnSaveChanges);
             DeleteCommand = new RelayCommand(OnDelete);

             //tabela
             DbContextHandler.Instance.GetAllTherapies().ForEach(terapija => Terapije.Add(terapija));
         }
         public void OnAdd()
         {
             this.Validate();
             if (this.IsValid)
             {
                 if (!isUpdate)
                 {
                     DbContextHandler.Instance.CreateTherapy(Name, Description, Types[0].ToString());

                     Terapije.Clear();
                     DbContextHandler.Instance.GetAllTherapies().ForEach(terapija => Terapije.Add(terapija));

                     Name = "";
                     Description = "";
                     Types = null;
                 }
                 else
                 {
                     BtnContent = "Update";
                     MessageBox.Show("Update data!");

                     DbContextHandler.Instance.UpdateTherapy(SelectedItem.Terapija_Id, name, description, types.ToString());

                     Terapije.Clear();
                     DbContextHandler.Instance.GetAllTherapies().ForEach(terapija => Terapije.Add(terapija));

                     isUpdate = false;
                     BtnContent = "Add";
                     Name = "";
                     Description = "";
                     Types = null;
                 }
             }
         }
             public void OnSaveChanges()
             {
                 Name = SelectedItem.Naziv;
                 Description = SelectedItem.Opis;
                 //Types = SelectedItem.Vrsta_Terapije.;

                 isUpdate = true;
                 BtnContent = "Update";
             }
             public void OnDelete()
         {
             int therapyId = Terapije.ElementAt(CurrentIndex).Terapija_Id;

             DbContextHandler.Instance.DeleteTherapyById(therapyId);
             MessageBox.Show("Delete data!");
             Terapije.RemoveAt(CurrentIndex);
         }
         #endregion

    }
}
