using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepaway1.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CampSleepaway1
{
    public class HandleTables
    {
        
            const string connectionString =
            "Data Source=LAPTOP-MOP66LEC\\SQLEXPRESS;Initial Catalog=CS_Frida_Westerdahl;Integrated Security=True";
        private static SqlConnection dbcon;
        
        public static void InsertCamperToTable()
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
                
            dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
            dbcon.Open();
            
            int returnValue = command.ExecuteNonQuery();
            Console.WriteLine("Camper {0} {1} is added!", firstName, lastName);
            dbcon.Close();
            
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
                    $"UPDATE Campers SET FirstName = '{firstName}', LastName = '{lastName}', Age = {age} " +
                    $"WHERE CamperId = {camperId};";

                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();
                Console.WriteLine("Camper {0} {1} is updated!", firstName, lastName);
                dbcon.Close();
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
                
                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();

                Console.WriteLine("Camper {0} is deleted!", Id);
                dbcon.Close();
            }
        }
        public static void SearchCamperAndKinsByCabin()
        {
            ReadAllCabins();
            Console.WriteLine("\nEnter the cabin Id:");
            int Id = int.Parse(Console.ReadLine());

            string query =
          $"SELECT c.CabinName AS Cabin, cam.FirstName + ' ' + cam.LastName AS Camper, nok.FirstName + ' ' + nok.LastName AS NextOfKin " +
          $"FROM CamperNextOfKins cnok " +
          $"JOIN Campers cam on cnok.CamperId = cam.CamperId " +
          $"JOIN NextOfKins nok on cnok.NextOfKinId = nok.NextOfKinId " +
          $"JOIN CamperStays cams on cam.CamperId = cams.CamperId " +
          $"JOIN Cabins c on cams.CabinId = c.CabinId " +
          $"WHERE c.CabinId = {Id} AND DepartureDate > SYSDATETIME() " +
          $"ORDER BY c.CabinName";

            dbcon = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, dbcon);
            dbcon.Open();
            SqlDataReader reader = command.ExecuteReader();


            using (reader)
            {
                while (reader.Read())
                {
                    string Cabin = (string)reader["Cabin"];
                    string Camper = (string)reader["Camper"];
                    string NextOfKin = (string)reader["NextOfKin"];
                    Console.WriteLine("Cabin: {0}, Camper: {1}, NextOfKin: {2}", Cabin, Camper, NextOfKin);
                }
            }
            int returnValue = command.ExecuteNonQuery();

            dbcon.Close();
            Console.ReadLine();
        }

        public static void InsertCounselorToTable()
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
                
                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();

                Console.WriteLine("Counselor {0} {1} is added!", firstName, lastName);
                dbcon.Close();   
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
                ReadCounselors();
                Console.WriteLine("Write the Counselor Id of the counselor you want to change:");
                int counselorId = Convert.ToInt32(Console.ReadLine());
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
                    $"UPDATE Counselors SET FirstName = '{firstName}', LastName = '{lastName}', Title = {title} " +
                    $"WHERE CounselorId = {counselorId};";
               
                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();

                Console.WriteLine("Camper {0} {1} is updated!", firstName, lastName);
                dbcon.Close();
            
        }
        public static void DeleteCounselor()
        {
                ReadCounselors();
                Console.WriteLine("Write the Counselor Id of the counselor you want to delete:");
                int Id = Convert.ToInt32(Console.ReadLine());

                string query =
                    $"DELETE Counselors " +
                    $"WHERE CounselorId = {Id};";

                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();

                Console.WriteLine("Counselor {0} is deleted!", Id);
                dbcon.Close();  
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
                Console.WriteLine("What should the cabin be called?" +
                           "\n-----------------------------");
                string name = Console.ReadLine();

                string query =
                    $"INSERT INTO Cabins (CabinName, CapacityCampers, CapacityCounselor) " +
                    $"VALUES('{name}', 4, 1);";

                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();

                Console.WriteLine("Cabin {0} is added!", name);
                dbcon.Close();
            
        }
        public static void ShowCabinsWithStays()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Cabins and their current stays:");

                var query =
                    (from c in db.Cabins
                     join cons in db.CounselorStays on c.Id equals cons.CabinId
                     join cams in db.CamperStays on c.Id equals cams.CabinId
                     join con in db.Counselors on cons.CounselorId equals con.Id
                     join cam in db.Campers on cams.CamperId equals cam.Id
                     where cons.DepartureDates > DateTime.Now
                     where cams.DepartureDates > DateTime.Now
                     select new { c, cams, cons, con })
                     .Select(x => new
                     {
                         Cabin = x.c.Name,
                         Counselor = x.con.FirstName,
                         Camper = x.cams.Camper.FirstName + " " + x.cams.Camper.LastName
                     })
                     .OrderBy(x => x.Cabin);

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static void SearchCabin()
        {
                Console.WriteLine("Do you want to search by cabin or counselor?\n" +
                    "[1] Cabin\n" +
                    "[2] Counselor");
                int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ByCabinId();
                    break;
                case 2:
                    Console.Clear();
                    ByCounselorId();
                    break;
    
            }

            static void ByCabinId()
            {
                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    ReadAllCabins();
                    Console.WriteLine("\nEnter the cabins Id:");
                    int Id = int.Parse(Console.ReadLine());

                    string query2 =
                  $"select c.CabinName AS Cabin, cam.FirstName + ' ' + cam.LastName AS Camper, con.FirstName + ' ' + con.LastName AS Counselor " +
                  $"from Cabins c " +
                  $"join CounselorStays cons on c.CabinId = cons.CabinId " +
                  $"join CamperStays cams on c.CabinId = cams.CabinId " +
                  $"JOIN Counselors con on cons.CounselorId = con.CounselorId " +
                  $"join Campers cam on cams.CamperId = cam.CamperId " +
                  $"where cons.DepartureDate > SYSDATETIME() " +
                  $"and cams.DepartureDate > SYSDATETIME() " +
                  $"and c.CabinId = {Id} ";

                    SqlCommand command2 = new SqlCommand(query2, dbcon);
                    dbcon.Open();
                    SqlDataReader reader2 = command2.ExecuteReader();


                    using (reader2)
                    {
                        while (reader2.Read())
                        {
                            string Cabin = (string)reader2["Cabin"];
                            string Camper = (string)reader2["Camper"];
                            string Counselor = (string)reader2["Counselor"];
                            Console.WriteLine("Cabin: {0}, Camper: {1}, Counselor: {2}", Cabin, Camper, Counselor);
                        }
                    }
                    Console.ReadLine();

                    string query = $"SELECT COUNT(*) FROM CounselorStays WHERE counselorId = {Id} AND DepartureDate > SYSDATETIME();";
                    int counselorStays = 0;

                    SqlCommand command = new SqlCommand(query, dbcon);
                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            counselorStays = (int)reader[0];
                        }
                    }

                    if (counselorStays == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no counselor staying!");
                        Console.ResetColor();  
                    }
                    dbcon.Close();
                    
                }
                
                    
            }
            static void ByCounselorId()
            {
                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    ReadCounselors();
                    Console.WriteLine("\nEnter the counselors Id:");
                    int Id = int.Parse(Console.ReadLine());

                    string query2 =
                  $"select c.CabinName AS Cabin, cam.FirstName + ' ' + cam.LastName AS Camper, con.FirstName + ' ' + con.LastName AS Counselor " +
                  $"from Cabins c " +
                  $"join CounselorStays cons on c.CabinId = cons.CabinId " +
                  $"join CamperStays cams on c.CabinId = cams.CabinId " +
                  $"JOIN Counselors con on cons.CounselorId = con.CounselorId " +
                  $"join Campers cam on cams.CamperId = cam.CamperId " +
                  $"where cons.DepartureDate > SYSDATETIME() " +
                  $"and cams.DepartureDate > SYSDATETIME() " +
                  $"and cons.CounselorId = {Id} ";

                    SqlCommand command2 = new SqlCommand(query2, dbcon);
                    dbcon.Open();
                    SqlDataReader reader2 = command2.ExecuteReader();

                    using (reader2)
                    {
                        while (reader2.Read())
                        {
                            string Cabin = (string)reader2["Cabin"];
                            string Camper = (string)reader2["Camper"];
                            string Counselor = (string)reader2["Counselor"];
                            Console.WriteLine("Cabin: {0}, Camper: {1}, Counselor: {2}", Cabin, Camper, Counselor);
                        }
                    }
                    string query = $"SELECT COUNT(*) FROM CounselorStays WHERE counselorId = {Id} AND DepartureDate > SYSDATETIME();";
                    int counselorStays = 0;

                    SqlCommand command = new SqlCommand(query, dbcon);
                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            counselorStays = (int)reader[0];
                        }
                    }

                    if (counselorStays == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"There is no counselor {Id} staying!");
                        Console.ResetColor();
                        ByCounselorId();
                    }
                    dbcon.Close();
                }
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
                     select new { c, nok })
                     .Select(x => new { Name = x.c.FirstName + " " + x.c.LastName,
                         NextOfKin = x.nok.FirstName + " " + x.nok.LastName, Phone = x.nok.PhoneNumber })
                     .OrderBy(x => x.Name);

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
                     .Select(x => new { Id = x.nok.Id + " " +  x.nok.FirstName + " " + x.nok.LastName, Phone = x.nok.PhoneNumber });

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
                    $"UPDATE NextOfKins SET FirstName = '{firstName}', LastName = '{lastName}', PhoneNumber = '{phone}' " +
                    $"WHERE NextOfKinId = {Id};";
                dbcon = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, dbcon);
                dbcon.Open();

                int returnValue = command.ExecuteNonQuery();
                Console.WriteLine("Kin {0} {1} is updated!", firstName, lastName);
                dbcon.Close();
                db.SaveChanges();
            }
        }
        public static void InsertNextOfKin()
        {
            using (var db = new EFContext())
            {
                Kin();
                Relation();
                void Kin()
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
                        $"VALUES ('{firstName}', '{lastName}', '{phone}');";

                    dbcon = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(query, dbcon);
                    dbcon.Open();

                    int returnValue = command.ExecuteNonQuery();
                    Console.WriteLine("Kin {0} {1} is inserted!", firstName, lastName);
                    Console.ReadKey();
                    dbcon.Close();
                }
                void Relation()
                {
                    Console.Clear();
                    ShowNextOfKins();
                    Console.WriteLine("We need to know your relation with a camper.\n" +
                        "Enter the next of kin Id:");
                    int kinId = Int32.Parse(Console.ReadLine());
                    ReadCampers();
                    Console.WriteLine("Then enter the Id of the camper:");
                    int camId = Int32.Parse(Console.ReadLine());

                    var cnok = new CamperNextOfKin()
                    {
                        CamperId = camId,
                        NextOfKinId = kinId
                    };
                    db.Add(cnok);
                    Console.WriteLine($"Relation between kin Id: {kinId}, camper Id: {camId} is registered.");

                    db.SaveChanges();
                }
                
                
            }
               
        }
       
    }

}
