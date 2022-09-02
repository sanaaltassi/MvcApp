namespace MvcApp.Models
{
    public class ExaminatonBookingModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime Birthday { get; set; }
        public string Illness { get; set; }

        public int PatientId { get; set; }
        public PatientsModel PatientsModels { get; set; }

    }
}
