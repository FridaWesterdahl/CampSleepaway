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
       /* public SqlConnection dbcon;
        public HandleTables()
        {
            string connectionString = "Data Source=LAPTOP-MOP66LEC\\SQLEXPRESS;Initial Catalog=CS_Frida_Westerdahl;Integrated Security=True";
            dbcon = new SqlConnection(connectionString);
        }*/
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
                Console.WriteLine("Age (enter a number:" +
                    "\n-----------------------------");
                int age = Convert.ToInt32(Console.ReadLine());

                string query =
                    $"INSERT INTO Campers (FirstName, LastName, Age) " +
                    $"VALUES('{firstName}','{lastName}','{age}');";
                SqlCommand command = new SqlCommand(query);

                db.SaveChanges();
                Console.WriteLine("Camper is added!");
            }
            
           
            

        }
        /* static void UpdateCamper()
         {
             using (var db = new EFContext())
             {


                 Console.WriteLine("Write the EmployeeID of the employee you want to change:");
                 int EmployeeID = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter the new address:");
                 string userAddress = Console.ReadLine();

                 string sqlUpdateEmployee =
                     $"UPDATE Addresses SET AddressText = '{userAddress}'" +
                     $"WHERE EmployeeID = '{EmployeeID}';";
                 SqlCommand command = new SqlCommand(sqlUpdateEmployee, dbcon);
                 command.Connection = dbcon;
                 int returnValue = command.ExecuteNonQuery();

                 db.SaveChanges();
                 Console.WriteLine("Camper updated!");
             }
             return;
         }*/
    }
}
