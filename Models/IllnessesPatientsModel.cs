
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class IllnessesPatientsModel
    {
        public int IllnessesId { get; set; }
        public IllnessesModel Illnesses { get; set; }

        public int PatientId { get; set; }
        public PatientsModel Patients { get; set; }
    }
}
