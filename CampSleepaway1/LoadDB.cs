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
        public void InsertCamper()
        {
            using (var db = new EFContext())
            {
                Camper camper = new Camper();
                camper.FirstName = "Alwa";
                camper.LastName = "Larsson";
                camper.Age = 3;
                
                db.Add(camper);
                db.SaveChanges();
                Console.WriteLine("Camper inserted!");
            }
            return;
        }
        public void InsertCounselor()
        {
            using (var db = new EFContext())
            {
                Counselor counselor = new Counselor();
                counselor.FirstName = "Kevin";
                counselor.LastName = "Hart";
                counselor.Title = "Sunshine";

                db.Add(counselor);
                db.SaveChanges();
                Console.WriteLine("Counselor inserted!");
            }
            return;
        }
        public void InsertCabin()
        {
            using (var db = new EFContext())
            {
                Cabin cabin = new Cabin();
                cabin.Name = "Purple";
                cabin.CapacityCounselor = 1;
                cabin.CapacityCampers = 4;

                db.Add(cabin);
                db.SaveChanges();
                Console.WriteLine("Cabin inserted!");
            }
            return;
        }
        public void InsertNextOfKin()
        {
            using (var db = new EFContext())
            {
                NextOfKin nok = new NextOfKin();
                nok.FirstName = "Lena";
                nok.LastName = "Larsson";
                nok.PhoneNumber = "048589489";

                db.Add(nok);
                db.SaveChanges();
                Console.WriteLine("Kin inserted!");
            }
            return;
        }

    }
}
