using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CampSleepaway1.Models;
using Microsoft.Data.SqlClient;

namespace CampSleepaway1
{
    public class TimeManager
    {
        const string connectionString =
            "Data Source=LAPTOP-MOP66LEC\\SQLEXPRESS;Initial Catalog=CS_Frida_Westerdahl;Integrated Security=True";
        private static SqlConnection dbcon;

        public static void CamperArrival()
        {
            HandleTables.ReadCampers();
            Console.WriteLine("\nEnter the camper Id:");
            int camId = int.Parse(Console.ReadLine());
            HandleTables.ReadAllCabins();
            Console.WriteLine("\nEnter the cabin Id:");
            int cabId = int.Parse(Console.ReadLine());
            var arr = DateTime.Now;
            var dep = DateTime.Now.AddMonths(1);

            using (dbcon = new SqlConnection(connectionString))
            {
                string query =
              $"SELECT COUNT(*) FROM CamperStays WHERE cabinId = {cabId};";

                int countCabinCampers = 0;
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        countCabinCampers = (int)reader[0];
                    }  
                }
                dbcon.Close();

                string query2 =
                    $"SELECT COUNT(*) FROM CounselorStays WHERE cabinId = {cabId};";

                int countCabinCounselor = 0;
                SqlCommand command2 = new SqlCommand(query2, dbcon);
                dbcon.Open();
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        countCabinCounselor = (int)reader2[0];
                    }
                }
                Console.Clear();
                Console.WriteLine($"Counselors staying: {countCabinCounselor}\nCampers staying: {countCabinCampers}");
                dbcon.Close();

                if (countCabinCounselor == 0)
                {
                    Console.WriteLine("You cannot check in without a counselor staying!");
                }
                else if (countCabinCampers < 4)
                {
                    using (var db = new EFContext())
                    {
                        var cs = new CamperStay()
                        {
                            CamperId = camId,
                            CabinId = cabId,
                            ArrivalDates = arr,
                            DepartureDates = dep

                        };
                        db.Add(cs);
                        db.SaveChanges();
                        Console.WriteLine("Camper {0} is registered {1}. Latest departure is {2}.", camId, arr, dep);
                    }
                }
                else
                {
                    Console.WriteLine("Cabin is full! Choose another one.");
                    Console.ReadLine();
                    Console.Clear();
                    CamperArrival();
                }
            }
        }

        public static void CounselorArrival()
        {
            
                HandleTables.ReadCounselors();
                Console.WriteLine("\nEnter the counselor Id:");
                int conId = int.Parse(Console.ReadLine());
                HandleTables.ReadAllCabins();
                Console.WriteLine("\nEnter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());
                var arr = DateTime.Now;
                var dep = DateTime.Now.AddMonths(1);

            using (dbcon = new SqlConnection(connectionString))
            {
                string query =
                    $"SELECT COUNT(*) FROM CounselorStays WHERE cabinId = {cabId};";

                int countCabinCounselor = 0;
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        countCabinCounselor = (int)reader[0];
                    }
                }
                dbcon.Close();

                if (countCabinCounselor == 0)
                {
                    using (var db = new EFContext())
                    {
                        var cs = new CounselorStay()
                        {
                            CounselorId = conId,
                            CabinId = cabId,
                            ArrivalDates = arr,
                            DepartureDates = dep

                        };
                        db.Add(cs);
                        db.SaveChanges();
                        Console.WriteLine("Counselor {0} is registered {1}. Latest departure is {2}.", conId, arr, dep);
                    }
                }
                else
                {
                    Console.WriteLine("The cabin already have a counselor staying!");
                    Console.ReadLine();
                    Console.Clear();
                    CounselorArrival();
                }
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

                //var earliestVisit = DateTime.SpecifyKind()

                var visit = new Visit()
                {
                    CamperId = camId,
                    NextOfKinId = kinId,
                    MaxVisitTime = 3,
                    EarliestVisit = DateTime.MinValue

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
