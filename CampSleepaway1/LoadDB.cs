using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepaway1.Models;
using Microsoft.Data.SqlClient;

namespace CampSleepaway1
{
    public class LoadDB
    {
        public void LoadAll()
        {
            LoadCampers();
            LoadCounselors();
            LoadCabins();
            LoadNextOfKins();
            LoadNextOfKinRelations();
        }
        public void LoadCampers()
        {
            using (var db = new EFContext())
            {
                db.Campers.Add(new Camper { FirstName = "Frida", LastName = "Westerdahl", Age = 26 });
                db.Campers.Add(new Camper { FirstName = "Fredrik", LastName = "Lam", Age = 28 });
                db.Campers.Add(new Camper { FirstName = "Noah", LastName = "Maktabi", Age = 30 });
                db.Campers.Add(new Camper { FirstName = "Paul", LastName = "Tannenberg", Age = 27 });
                db.Campers.Add(new Camper { FirstName = "Daniel", LastName = "Bjärefors", Age = 8 });
                db.Campers.Add(new Camper { FirstName = "Lily", LastName = "Fiskorv", Age = 5 });
                db.Campers.Add(new Camper { FirstName = "Isadora", LastName = "Fiskorv", Age = 7 });
                db.Campers.Add(new Camper { FirstName = "Niklas", LastName = "Lindblad", Age = 10 });
                db.Campers.Add(new Camper { FirstName = "Daniel", LastName = "Lindeberg", Age = 12 });
                db.Campers.Add(new Camper { FirstName = "Julia", LastName = "Loman", Age = 7 });
                db.Campers.Add(new Camper { FirstName = "Inaas", LastName = "Isse", Age = 7 });
                db.Campers.Add(new Camper { FirstName = "Hanna", LastName = "Westerdahl", Age = 3 });
                db.Campers.Add(new Camper { FirstName = "Rano", LastName = "Zangana", Age = 10 });
                db.Campers.Add(new Camper { FirstName = "Susannah", LastName = "Andersson", Age = 8 });
                db.Campers.Add(new Camper { FirstName = "Sebastian", LastName = "Schavon", Age = 5 });
                db.Campers.Add(new Camper { FirstName = "Sinah", LastName = "Almahmoud", Age = 10 });
                db.Campers.Add(new Camper { FirstName = "Alwa", LastName = "Larsson", Age = 3 });
                db.Campers.Add(new Camper { FirstName = "Philip", LastName = "Nettelblad", Age = 5 });

                db.SaveChanges();
            }
          
        }
        public void LoadCounselors()
        {
            using (var db = new EFContext())
            {
                db.Counselors.Add(new Counselor { FirstName = "Micke", LastName = "O", Title = "Lord" });
                db.Counselors.Add(new Counselor { FirstName = "Jason", LastName = "Bourne", Title = "Survivor" });
                db.Counselors.Add(new Counselor { FirstName = "Scrappy", LastName = "Coco", Title = "Genius" });
                db.Counselors.Add(new Counselor { FirstName = "Kevin", LastName = "Hart", Title = "Sunshine" });

                db.SaveChanges();
            }
          
        }
        public void LoadCabins()
        {
            using (var db = new EFContext())
            {
                db.Cabins.Add(new Cabin { Name = "Green", CapacityCampers = 4, CapacityCounselor = 1 });
                db.Cabins.Add(new Cabin { Name = "Yellow", CapacityCampers = 4, CapacityCounselor = 1 });
                db.Cabins.Add(new Cabin { Name = "Blue", CapacityCampers = 4, CapacityCounselor = 1 });
                db.Cabins.Add(new Cabin { Name = "Purple", CapacityCampers = 4, CapacityCounselor = 1 });

                db.SaveChanges();
            }
            
        }
        public void LoadNextOfKins()
        {
            using (var db = new EFContext())
            {
                db.NextOfKins.Add(new NextOfKin { FirstName = "Lena", LastName = "Larsson", PhoneNumber = "048589489" });
                db.NextOfKins.Add(new NextOfKin { FirstName = "Barba", LastName = "Pappa", PhoneNumber = "048586644" });
                db.NextOfKins.Add(new NextOfKin { FirstName = "Tomte", LastName = "Far", PhoneNumber = "048349565" });
                db.NextOfKins.Add(new NextOfKin { FirstName = "Ove", LastName = "Sundberg", PhoneNumber = "0438955345" });
                db.NextOfKins.Add(new NextOfKin { FirstName = "Brev", LastName = "Bäraren", PhoneNumber = "047654697" });


                db.SaveChanges();
            }
            
        }
        public void LoadNextOfKinRelations()
        {
            using (var db = new EFContext())
            {
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 1, NextOfKinId = 1 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 2, NextOfKinId = 4 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 3, NextOfKinId = 4 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 4, NextOfKinId = 2 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 5, NextOfKinId = 3 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 6, NextOfKinId = 5 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 7, NextOfKinId = 3 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 8, NextOfKinId = 5 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 9, NextOfKinId = 5 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 10, NextOfKinId = 3 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 11, NextOfKinId = 2 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 12, NextOfKinId = 1 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 13, NextOfKinId = 3 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 14, NextOfKinId = 5 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 15, NextOfKinId = 2 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 16, NextOfKinId = 5 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 1004, NextOfKinId = 5 });
                db.CamperNextOfKins.Add(new CamperNextOfKin { CamperId = 1005, NextOfKinId = 5 });

                db.SaveChanges();
            }

        }

    }
}
