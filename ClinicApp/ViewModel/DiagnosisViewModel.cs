using ClinicApp.Core;
using ClinicApp.View.Add;
using ClinicApp.View.Change;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class DiagnosisViewModel: ValidationBase
    {
        #region Fields and properties

        public MyICommand AddCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public MyICommand RemoveCommand { get; set; }
        #endregion

        
        public DiagnosisViewModel()
        {
            AddCommand = new MyICommand(AddDiagnosis);
            ChangeCommand = new MyICommand(ChangeDiagnosis);
            RemoveCommand = new MyICommand(RemoveDiagnosis);
        }
        public void AddDiagnosis()
        {
            
        }
        public void ChangeDiagnosis()
        {
            
        }
        public void RemoveDiagnosis()
        {
           
        }
        protected override void ValidateSelf()
        {
            //throw new NotImplementedException();
        }
    }
}
