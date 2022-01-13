using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepaway1.Models;

namespace CampSleepaway1
{
    public class LoadDB
    {
        public void InsertCamper()
        {
            using (var db = new EFContext())
            {
                Camper camper = new Camper();
                camper.FirstName = "Frida";
                camper.LastName = "Westerdahl";
                camper.Age = 26;
                
                db.Add(camper);
                db.SaveChanges();
                Console.WriteLine("Camper inserted!");
            }
            return;
        }
    }
}
