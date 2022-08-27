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
                Age = 18,
                PatientsComplaint = "Skin"
            };
            return View(Patients);
        }

        public IActionResult Illnesses()
        {
            var Illnesses = new IllnessesModel
            {
                Name = "leather",
                IllnessesTypes = "Skin"
            };
            return View(Illnesses);
        }

        public IActionResult ExaminatonBooking()
        {
              var examinatonBookingModel = new ExaminatonBookingModel
              {

                  Id = 50,
                  Name = "Samer",
                  Age= 18,
                  Illness="head",
                     
              };
            return View(examinatonBookingModel);
        }

        public IActionResult Prescriptions()
        {
            var Prescriptions = new PrescriptionsModel
            {
                Name = "Baraa",
                Id = 50,
                Age=10
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