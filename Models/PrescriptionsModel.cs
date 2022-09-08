namespace MvcApp.Models
{
    public class PrescriptionsModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public int PatientId { get; set; }
        public PatientsModel PatientsModels { get; set; }
    }
}
