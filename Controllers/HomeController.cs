using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Doctor()
        {
            var doctor = new DoctorModels
            {
               
                Id = 50,
                Name = "Sana",
                Specialing="Brain",
                Experience=7
            };
            return View(doctor);
        }
        public IActionResult Patients()
        {
            var Patients = new PatientsModel
            {
                Id = 80,
                Name = "leather",
                PatientId = 23,
                Birthday =DateTime.Now 
               
            };
            return View(Patients);
        }

        public IActionResult Illnesses()
        {
            var Illnesses = new IllnessesModel
            {
                Name = "leather",
                IllnessesType = "Skin",
                IllnessesId=12
            };
            return View(Illnesses);
        }

        public IActionResult ExaminatonBooking()
        {
              var ExaminatonBooking = new ExaminatonBookingModel
              {

                  Id = 50,
                  Name = "Samer",
                  Birthday= DateTime.Now,
                  Illness ="head",
                  PatientId=19
              };
            return View(ExaminatonBooking);
        }

        public IActionResult Prescriptions()
        {
            var Prescriptions = new PrescriptionsModel
            {
                Name = "Baraa",
                Id = 50,
                Birthday= DateTime.Now,
                PatientId =12
            };
            return View(Prescriptions);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}