using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CampSleepaway1.Models;
using Microsoft.Data.SqlClient;

namespace CampSleepaway1
{
    public class TimeManager
    {
        public static void CamperArrival()
        {
            using (var db = new EFContext())
            {
                HandleTables.ReadCampers();
                Console.WriteLine("\nEnter the camper Id:");
                int camId = int.Parse(Console.ReadLine());
                HandleTables.ReadAllCabins();
                Console.WriteLine("\nEnter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());
                var arr = DateTime.Now;
                var dep = DateTime.Now.AddMonths(1);

                var cs = new CamperStay()
                {
                    CamperId = camId,
                    CabinId = cabId,
                    ArrivalDates = arr,
                    DepartureDates = dep

                };
                db.Add(cs);

                db.SaveChanges();
                Console.WriteLine("Camper {0} is registered {1}. Departure {2}", camId, arr, dep);

            }
        }

        public static void CounselorArrival()
        {
            using (var db = new EFContext())
            {
                HandleTables.ReadCounselors();
                Console.WriteLine("\nEnter the counselor Id:");
                int conId = int.Parse(Console.ReadLine());
                HandleTables.ReadAllCabins();
                Console.WriteLine("\nEnter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());
                var arr = DateTime.Now;
                var dep = DateTime.Now.AddMonths(1);

                var cs = new CounselorStay()
                {
                    CounselorId = conId,
                    CabinId = cabId,
                    ArrivalDates = arr,
                    DepartureDates = dep

                };
                db.Add(cs);

                db.SaveChanges();
                Console.WriteLine("Counselor {0} is registered {1}. Departure {2}", conId, arr, dep);
            }
        }
        public static void VisitorArrival()
        {
            using (var db = new EFContext())
            {
                HandleTables.ShowNextOfKinRelations();
                Console.WriteLine("Enter the camper Id you want to visit:");
                int camId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the next of kin Id:");
                int kinId = int.Parse(Console.ReadLine());

                var visit = new Visit()
                {
                    CamperId = camId,
                    NextOfKinId = kinId,
                    ArrivalDates = DateTime.Now

                };
                db.Add(visit);
                db.SaveChanges();
            }
        }
        public static void VisitorDeparture()
        {
            using (var db = new EFContext())
            {
                HandleTables.ShowNextOfKinRelations();
                Console.WriteLine("Enter the counselor Id:");
                int conId = int.Parse(Console.ReadLine());

                var visit = new Visit()
                {
                
                    DepartureDates = DateTime.Now

                };
                db.Add(visit);
                db.SaveChanges();
            }
        }

    }
}
