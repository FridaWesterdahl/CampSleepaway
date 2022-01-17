using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepaway1
{
    public class Menu
    {
        public void Logo()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
                                         
 \    /   _   |   _   _   ._ _    _   | 
  \/\/   (/_  |  (_  (_)  | | |  (/_  o  
                                                 
                                        ");

            Console.ResetColor();
        }
       
        public Menu ShowMenu()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("What do you want to do? Enter the number below: \n" +
                "[1] Handle campers\n" +
                "[2] Handle counselors\n" +
                "[3] Update the address for a employee\n" +
                "[4] Show sales for a country of your choosing\n" +
                "[5] Make a new order\n" +
                "[6] Delete a customer and its orders");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    HandleCampers();
                    break;
                case 2:
                    HandleCounselors();
                    break;
                /*case 3:
                    _handler.UpdateEmployee();
                    Console.ReadLine();
                    break;
                case 4:
                    _handler.ShowCountrySales();
                    Console.ReadLine();
                    break;
                case 5:
                    _handler.AddNewOrder();
                    Console.ReadLine();
                    break;
                case 6:
                    _handler.DeleteOrderAndCustomer();
                    Console.ReadLine();
                    break;*/
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 1-6!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
            return ShowMenu();
        }
        public void HandleCampers()
        {
            Console.WriteLine("What do you want to do? Enter the number below: \n" +
                "[1] Read all registered campers that has visited\n" +
                "[2] Insert a camper\n" +
                "[3] Update a campers name and age\n" +
                "[4] Delete a camper by Id\n" +
                "[0] Back to main menu");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    HandleTables.ReadCampers();
                    break;
                case 2:
                    HandleTables.InsertCamperToTable();
                    break;
                case 3:
                    HandleTables.UpdateCamper();
                    break;
                case 4:
                    HandleTables.DeleteCamper();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-4!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }       
        }
        public void HandleCounselors()
        {
            Console.WriteLine("What do you want to do? Enter the number below: \n" +
                "[1] Read all registered counselors\n" +
                "[2] Insert a counselor\n" +
                "[3] Update a counselors name and title\n" +
                "[4] Delete a counselor by Id\n" +
                "[0] Back to main menu");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    HandleTables.ReadCounselors();
                    break;
                case 2:
                    HandleTables.InsertCounselorToTable();
                    break;
                case 3:
                    HandleTables.UpdateCounselor();
                    break;
                case 4:
                    HandleTables.DeleteCounselor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-4!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
    }
}
