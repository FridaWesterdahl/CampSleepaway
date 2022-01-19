using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepaway1.Models;
using Microsoft.Data.SqlClient;

namespace CampSleepaway1
{
    public class HandleTables
    {
        public static void InsertCamperToTable()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Firstname:" +
                           "\n-----------------------------");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname:" +
                    "\n-----------------------------");
                string lastName = Console.ReadLine();
                Console.WriteLine("Age (enter a number):" +
                    "\n-----------------------------");
                int age = Convert.ToInt32(Console.ReadLine());

                string query =
                    $"INSERT INTO Campers (FirstName, LastName, Age) " +
                    $"VALUES('{firstName}','{lastName}','{age}');";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Camper {0} {1} is added!", firstName, lastName);
            }
        }
        public static void ReadCampers()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("All registered campers:\n");
                List<Camper> campers = db.Campers.ToList();
                foreach (Camper c in campers)
                {
                    Console.WriteLine($"Id {c.Id}: {c.FirstName} {c.LastName} ");
                }
            }
            return;
        }
        public static void UpdateCamper()
        {
            using (var db = new EFContext())
            {
                ReadCampers();
                Console.WriteLine("Write the Camper Id of the camper you want to change:");
                int camperId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Firstname:" +
                           "\n-----------------------------");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname:" +
                    "\n-----------------------------");
                string lastName = Console.ReadLine();
                Console.WriteLine("Age (enter a number):" +
                    "\n-----------------------------");
                int age = Convert.ToInt32(Console.ReadLine());

                string query =
                    $"UPDATE Campers SET FirstName = {firstName}, LastName = {lastName}, Age = {age}) " +
                    $"WHERE CamperId = {camperId};";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Camper {0} {1} is updated!", firstName, lastName);
            }
        }
        public static void DeleteCamper()
        {
            using (var db = new EFContext())
            {
                ReadCampers();
                Console.WriteLine("Write the Camper Id of the camper you want to delete:");
                int Id = Convert.ToInt32(Console.ReadLine());

                string query =
                    $"DELETE Campers " +
                    $"WHERE CamperId = {Id};";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Camper {0} is deleted!", Id);
            }
        }

        public static void InsertCounselorToTable()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Firstname:" +
                           "\n-----------------------------");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname:" +
                    "\n-----------------------------");
                string lastName = Console.ReadLine();
                Console.WriteLine("Title:" +
                    "\n-----------------------------");
                string title = Console.ReadLine();

                string query =
                    $"INSERT INTO Counselors (FirstName, LastName, Title) " +
                    $"VALUES('{firstName}','{lastName}','{title}');";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Counselor {0} {1} is added!", firstName, lastName);
            }
        }
        public static void ReadCounselors()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("All registered counselors:\n");
                List<Counselor> counselors = db.Counselors.ToList();
                foreach (Counselor c in counselors)
                {
                    Console.WriteLine($"Id {c.Id}: {c.FirstName} {c.LastName} ");
                }
            }
            return;
        }
        public static void UpdateCounselor()
        {
            using (var db = new EFContext())
            {
                ReadCounselors();
                Console.WriteLine("Write the Counselor Id of the counselor you want to change:");
                int counselorId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Firstname:" +
                           "\n-----------------------------");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname:" +
                    "\n-----------------------------");
                string lastName = Console.ReadLine();
                Console.WriteLine("Age (enter a number):" +
                    "\n-----------------------------");
                string title = Console.ReadLine();

                string query =
                    $"UPDATE Counselors SET FirstName = {firstName}, LastName = {lastName}, Title = {title}) " +
                    $"WHERE CounselorId = {counselorId};";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Camper {0} {1} is updated!", firstName, lastName);
            }
        }
        public static void DeleteCounselor()
        {
            using (var db = new EFContext())
            {
                ReadCounselors();
                Console.WriteLine("Write the Counselor Id of the counselor you want to delete:");
                int Id = Convert.ToInt32(Console.ReadLine());

                string query =
                    $"DELETE Counselors " +
                    $"WHERE CounselorId = {Id};";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Counselor {0} is deleted!", Id);
            }
        }

        public static void ReadAllCabins()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("All cabins:\n");
                List<Cabin> cabins = db.Cabins.ToList();
                foreach (Cabin c in cabins)
                {
                    Console.WriteLine($"Id {c.Id}: {c.Name}");
                }
            }
            return;
        }
        public static void InsertCabinToTable()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("What should the cabin be called?" +
                           "\n-----------------------------");
                string name = Console.ReadLine();

                string query =
                    $"INSERT INTO Cabins (CabinName, CapacityCampers, CapacityCounselor) " +
                    $"VALUES('{name}', 4, 1);";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Cabin {0} is added!", name);
            }
        }

        public static void ShowNextOfKinRelations()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Campers and next of kins:");

                var q =
                    (from cnok in db.CamperNextOfKins
                     join c in db.Campers on cnok.CamperId equals c.Id
                     join nok in db.NextOfKins on cnok.NextOfKinId equals nok.Id
                     select new { c, cnok, nok })
                     .Select(x => new { Name = x.c.FirstName + " " + x.c.LastName,
                         NextOfKin = x.nok.FirstName + " " + x.nok.LastName, Phone = x.nok.PhoneNumber });

                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static void ShowNextOfKins()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("All registered next of kins:");

                var q =
                    (from nok in db.NextOfKins
                     select new { nok })
                     .Select(x => new { Name = x.nok.FirstName + " " + x.nok.LastName, Phone = x.nok.PhoneNumber });

                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static void UpdateNextOfKin()
        {
            using (var db = new EFContext())
            {
                ShowNextOfKins();
                Console.WriteLine("Write the NextOfKin Id of the kin you want to change:");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Firstname:" +
                           "\n-----------------------------");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname:" +
                    "\n-----------------------------");
                string lastName = Console.ReadLine();
                Console.WriteLine("Phonenumber:" +
                    "\n-----------------------------");
                string phone = Console.ReadLine();

                string query =
                    $"UPDATE NextOfKins SET FirstName = {firstName}, LastName = {lastName}, PhoneNumber = {phone}) " +
                    $"WHERE NextOfKinId = {Id};";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Kin {0} {1} is updated!", firstName, lastName);
            }
        }
        public static void InsertNextOfKin()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Firstname:" +
                           "\n-----------------------------");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname:" +
                    "\n-----------------------------");
                string lastName = Console.ReadLine();
                Console.WriteLine("Phonenumber:" +
                    "\n-----------------------------");
                string phone = Console.ReadLine();

                string query =
                    $"INSERT INTO NextOfKins (FirstName, LastName, PhoneNumber) " +
                    $"VALUES ('{firstName}', '{lastName}', '{phone}';";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Kin {0} {1} is updated!", firstName, lastName);
            }
        }
    }

}
