using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
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

            using (var context = new EFContext())
            {
                
                var countCabinCampers = context.CamperStays.Count(x => x.DepartureDates > DateTime.Now && x.CabinId == cabId);
                var countCabinCounselors = context.CounselorStays.Count(x => x.DepartureDates > DateTime.Now && x.CabinId == cabId);
                var alreadyStaying = context.CamperStays.Count(x => x.DepartureDates > DateTime.Now && x.CamperId == camId);

                Console.Clear();
                Console.WriteLine($"Counselors staying: {countCabinCounselors}\nCampers staying: {countCabinCampers}\n");

                if (countCabinCounselors == 0)
                {
                    Console.WriteLine("You cannot check in without a counselor staying!");
                }
                else if (countCabinCampers < 4 && alreadyStaying == 0)
                {
                    var cs = new CamperStay()
                    {
                        CamperId = camId,
                        CabinId = cabId,
                        ArrivalDates = arr,
                        DepartureDates = dep

                    };
                    context.CamperStays.Add(cs);
                    context.SaveChanges();
                    Console.WriteLine("Camper {0} is registered {1}. Latest departure is {2}.", camId, arr, dep);
                    
                }
                else
                {
                    Console.WriteLine($"Cabin is either full or Camper {camId} is already staying in a cabin.\n" +
                        $"Choose another one cabin or camper.");
                    Console.ReadLine();
                    Console.Clear();
                    CamperArrival();
                }
            }
        }
        public static void CamperDeparture()
        {
            using (var context = new EFContext())
            {
                Console.WriteLine("Cabins and their current stays:\n");

                var query =
                    (from cams in context.CamperStays
                     join c in context.Cabins on cams.CabinId equals c.Id
                     join cam in context.Campers on cams.CamperId equals cam.Id
                     select new { c, cams, cam })
                     .Where(x => x.cams.DepartureDates > DateTime.Now)
                     .Select(x => new
                     {
                         CamperId = x.cam.Id + ", " + x.cams.Camper.FirstName + " " + x.cams.Camper.LastName,
                         CabinId = x.c.Id + ", " + x.c.Name 
                     })
                     .OrderBy(x => x.CabinId);

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nEnter the camper Id:");
                int camId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());

                var departureDateUpdate = context.CamperStays
                    .FirstOrDefault(x => x.CabinId == cabId && x.CamperId == camId && x.DepartureDates > DateTime.Now);

                departureDateUpdate.DepartureDates = DateTime.Now;

                context.CamperStays.Update(departureDateUpdate);
                context.SaveChanges();
                Console.WriteLine("Camper {0} is registered departured {1}.\n" +
                    "Welcome back another time!", camId, DateTime.Now);
            }
        }

        public static void CounselorArrival()
        {
            using (var context = new EFContext())
            {

                HandleTables.ReadCounselors();
                Console.WriteLine("\nEnter the counselor Id:");
                int conId = int.Parse(Console.ReadLine());
                HandleTables.ReadAllCabins();
                Console.WriteLine("\nEnter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());
                var arr = DateTime.Now;
                var dep = DateTime.Now.AddMonths(1);

                var countCabinCounselors = context.CounselorStays.Count(x => x.DepartureDates > DateTime.Now && x.CabinId == cabId);

                if (countCabinCounselors == 0)
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
                        Console.WriteLine("Counselor {0} is registered {1}. Departure is {2}.", conId, arr, dep);
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
        public static void CounselorUpdate()
        {
            using (var context = new EFContext())
            {
                Console.WriteLine("Cabins and their current stays:\n");

                var query =
                    (from cons in context.CounselorStays
                     join c in context.Cabins on cons.CabinId equals c.Id
                     join con in context.Counselors on cons.CounselorId equals con.Id
                     select new { c, cons, con })
                     .Where(x => x.cons.DepartureDates > DateTime.Now)
                     .Select(x => new
                     {
                         CounselorId = x.con.Id + ", " + x.cons.Counselor.FirstName + " " + x.cons.Counselor.LastName,
                         CabinId = x.c.Id + ", " + x.c.Name
                     })
                     .OrderBy(x => x.CabinId);

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nEnter the counselor Id that is going home:");
                int conId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the cabin Id:");
                int cabId = int.Parse(Console.ReadLine());

                var departureDateUpdate = context.CounselorStays
                    .FirstOrDefault(x => x.CabinId == cabId && x.CounselorId == conId && x.DepartureDates > DateTime.Now);

                departureDateUpdate.DepartureDates = DateTime.Now;

                context.CounselorStays.Update(departureDateUpdate);
                context.SaveChanges();
                Console.WriteLine("Camper {0} is registered departured {1}.\n" +
                    "Welcome back to your next shift!", conId, DateTime.Now);
                Console.ReadKey();
                Console.Clear();

                HandleTables.ReadCounselors();
                Console.WriteLine("\nEnter the new counselor Id:");
                int conId2 = int.Parse(Console.ReadLine());
                var arr = DateTime.Now;
                var dep = DateTime.Now.AddMonths(1);

                var countCabinCounselors = context.CounselorStays.Count(x => x.DepartureDates > DateTime.Now && x.CabinId == cabId);

                if (countCabinCounselors == 0)
                {
                    using (var db = new EFContext())
                    {
                        var cs = new CounselorStay()
                        {
                            CounselorId = conId2,
                            CabinId = cabId,
                            ArrivalDates = arr,
                            DepartureDates = dep

                        };
                        db.Add(cs);
                        db.SaveChanges();
                        Console.WriteLine("Counselor {0} is registered {1} in cabin {3}. Departure is {2}.", conId2, arr, dep, cabId);
                    }
                }

            }
        }
        public static void VisitorArrival()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Current staying campers and their next of kins:\n");

                var q =
                    (from cnok in db.CamperNextOfKins
                     join c in db.Campers on cnok.CamperId equals c.Id
                     join nok in db.NextOfKins on cnok.NextOfKinId equals nok.Id
                     join cams in db.CamperStays on c.Id equals cams.CamperId
                          select new { c, nok, cams })
                     .Where(x => x.cams.DepartureDates > DateTime.Now)
                     .Select(x => new {
                         CamperId = x.c.Id + " " + x.c.FirstName + " " + x.c.LastName,
                         NextOfKinId = x.nok.Id + " " + x.nok.FirstName + " " + x.nok.LastName
                     });

                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nEnter the camper Id you want to visit:");
                int camId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the next of kin Id:");
                int kinId = int.Parse(Console.ReadLine());
                Console.WriteLine("For how long do you want to vistit?\n1, 2 or max 3 hours. Enter below:");
                int time = int.Parse(Console.ReadLine());

                if (DateTime.Now.Hour < 10 || DateTime.Now.Hour >= 20)
                {
                    Console.WriteLine("Visit hours are between 10-20.");
                    return;
                }
               
                if (time > 3)
                {
                    Console.WriteLine("You can only visit max 3 hours.");
                }
                else 
                {
                    var visit = new Visit()
                    {
                        CamperId = camId,
                        NextOfKinId = kinId,
                        VisitTime = time,
                        ArrivalDates = DateTime.Now,
                        DepartureDates = DateTime.Now.AddHours(time)

                    };
                    if (visit.DepartureDates.Hour >= 20)
                    {
                        visit.DepartureDates = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 59, 59);
                    }

                    db.Add(visit);
                    db.SaveChanges();
                    Console.WriteLine($"Visitor arrived {DateTime.Now}. Leaving {DateTime.Now.AddHours(time)}.");

                    var query =
                    (from c in db.Cabins
                     join cams in db.CamperStays on c.Id equals cams.CabinId
                     join cons in db.CounselorStays on c.Id equals cons.CounselorId
                     select new { c, cams, cons })
                     .Where(x => x.cams.DepartureDates > DateTime.Now && x.cams.CamperId == camId)
                     .Select(x => new
                     {
                         Camper = x.cams.Camper.FirstName + " " + x.cams.Camper.LastName,
                         Cabin = x.c.Name,
                         Counselor = x.cons.Counselor.FirstName    
                     })

                    foreach (var item in query)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

    }
}
