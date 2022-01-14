using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CampSleepaway1.Models
{
    public class EFContext : DbContext
    {
        public const string connectionString = "Data Source=LAPTOP-MOP66LEC\\SQLEXPRESS;Initial Catalog=CS_Frida_Westerdahl;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Camper> Campers { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<CamperStay> CamperStays { get; set; }
        public DbSet<CounselorStay> CounselorStays { get; set; }
        public DbSet<CamperNextOfKin> CamperNextOfKins { get; set; }

    }
}

