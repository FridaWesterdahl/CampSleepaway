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
                camper.FirstName = "Majs";
                camper.LastName = "Majsson";
                camper.Age = 5;
                
                db.Add(camper);
                db.SaveChanges();
                Console.WriteLine("Camper {0} {1} inserted!", camper.FirstName, camper.LastName);
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
                Console.WriteLine("Counselor {0} {1} inserted!", counselor.FirstName, counselor.LastName);
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
                Console.WriteLine("Cabin {0} {1} inserted!", cabin.Id, cabin.Name);
            }
            return;
        }
        public void InsertNextOfKin()
        {
            using (var db = new EFContext())
            {
                NextOfKin nok = new NextOfKin();
                nok.FirstName = "Brev";
                nok.LastName = "Bäraren";
                nok.PhoneNumber = "047654697";

                db.Add(nok);
                db.SaveChanges();
                Console.WriteLine("{0} {1} inserted as kin!", nok.FirstName, nok.LastName);
            }
            return;
        }
        public void FixNextOfKinRelations()
        {
            using (var db = new EFContext())
            {
                var cnok = new CamperNextOfKin()
                {
                    CamperId = 1005,
                    NextOfKinId = 5
                };
                db.Add(cnok);
                db.SaveChanges();
            }
        }
    }
}
