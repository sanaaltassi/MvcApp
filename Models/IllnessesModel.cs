
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class IllnessesModel
    {
        [Key]
        public string Name { get; set; }

        public string IllnessesType { get; set; }

        public int IllnessesId { get; set; }
        public ICollection<PatientsModel> Patients { get; set; }
    }
}
