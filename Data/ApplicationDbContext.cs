using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<MvcApp.Models.DoctorModels>? DoctorModels { get; set; }
        public DbSet<MvcApp.Models.IllnessesModel>? IllnessesModel { get; set; }
        public DbSet<MvcApp.Models.PatientsModel>? PatientsModel { get; set; }
        public DbSet<MvcApp.Models.PrescriptionsModel>? PrescriptionsModel { get; set; }
        public DbSet<MvcApp.Models.ExaminatonBookingModel>? ExaminatonBookingModel { get; set; }
    }
}