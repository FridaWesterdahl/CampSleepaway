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
                Console.WriteLine("Enter the camper Id:");
                int camId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());
                var time = DateTime.Now;

                string query =
                $"INSERT INTO CamperStays (CamperId, CabinId, ArrivalDate) " +
                $"VALUES ({camId}, {cabId}, {time};)";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Camper {0} is registered! {1} ", camId, time);

            }
        }
        public static void CamperDeparture()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Enter the camper Id:");
                int camId = int.Parse(Console.ReadLine());

                var arr = new CamperStay()
                {
                    CamperId = camId,
                    DepartureDates = DateTime.Now

                };
                db.Add(arr);
                db.SaveChanges();
            }
        }
        public static void CounselorArrival()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Enter the counselor Id:");
                int conId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());

                var arr = new CounselorStay()
                {
                    CounselerId = conId,
                    ArrivalDates = DateTime.Now,
                    CabinId = cabId

                };
                db.Add(arr);
                db.SaveChanges();
            }
        }
        public static void CounselorDeparture()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Enter the counselor Id:");
                int conId = int.Parse(Console.ReadLine());

                var arr = new CounselorStay()
                {
                    CounselerId = conId,
                    DepartureDates = DateTime.Now

                };
                db.Add(arr);
                db.SaveChanges();
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
