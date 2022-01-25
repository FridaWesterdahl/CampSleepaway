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
                "[3] Handle cabins\n" +
                "[4] Handle next of kins\n" +
                "[5] Register an arrival\n" +
                "[6] Register an earlier departure for camper");

            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    HandleCampers();
                    break;
                case 2:
                    HandleCounselors();
                    break;
                case 3:
                    HandleCabins();
                    break;
               case 4:
                    HandleNextOfKins();
                    break;
               case 5:
                    HandleArrivals();
                    break;
                case 6:
                    TimeManager.CamperDeparture();
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 1-5!");
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
                "[5] Look up all campers and their next of kins\n" +
                "[6] Search campers by cabin/counselor Id\n" +
                "[7] Search camper by current cabin and  show their next of kin\n" +
                "[0] Back to main menu");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    HandleTables.ReadCampers();
                    Console.ReadLine();
                    break;
                case 2:
                    HandleTables.InsertCamperToTable();
                    Console.ReadLine();
                    break;
                case 3:
                    HandleTables.UpdateCamper();
                    Console.ReadLine();
                    break;
                case 4:
                    HandleTables.DeleteCamper();
                    Console.ReadLine();
                    break;
                case 5:
                    HandleTables.ShowNextOfKinRelations();
                    Console.ReadLine();
                    break;
                case 6:
                    HandleTables.SearchCabin();
                    Console.ReadLine();
                    break;
                case 7:
                    HandleTables.SearchCamperAndKinsByCabin();
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-7!");
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
                    Console.ReadLine();
                    break;
                case 2:
                    HandleTables.InsertCounselorToTable();
                    Console.ReadLine();
                    break;
                case 3:
                    HandleTables.UpdateCounselor();
                    Console.ReadLine();
                    break;
                case 4:
                    HandleTables.DeleteCounselor();
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-4!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
        public void HandleCabins()
        {
            Console.WriteLine("What do you want to do? Enter the number below: \n" +
                "[1] View of all cabins\n" +
                "[2] Insert a new cabin\n" +
                "[3] Show all cabins and their stayings\n" +
                "[4] Search cabins and their stays by Id\n" +
                "[0] Back to main menu");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    HandleTables.ReadAllCabins();
                    Console.ReadLine();
                    break;
                case 2:
                    HandleTables.InsertCabinToTable();
                    Console.ReadLine();
                    break;
                case 3:
                    HandleTables.ShowCabinsWithStays();
                    Console.ReadLine();
                    break;
                case 4:
                    HandleTables.SearchCabin();
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-4!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
        public void HandleNextOfKins()
        {
            Console.WriteLine("What do you want to do? Enter the number below: \n" +
                "[1] View all next of kins\n" +
                "[2] Update next of kin\n" +
                "[3] Show next of kin relations\n" +
                "[0] Back to main menu");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    HandleTables.ShowNextOfKins();
                    Console.ReadLine();
                    break;
                case 2:
                    HandleTables.UpdateNextOfKin();
                    Console.ReadLine();
                    break;
                case 3:
                    HandleTables.ShowNextOfKinRelations();
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-3!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
        public void HandleArrivals()
        {
            Console.WriteLine("What do you want to do? Enter the number below: \n" +
                "[1] Register a camper\n" +
                "[2] Register a counselor\n" +
                "[3] Register a visitor\n" +
                "[0] Back to main menu");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    TimeManager.CamperArrival();
                    Console.ReadLine();
                    break;
                case 2:
                    TimeManager.CounselorArrival();
                    Console.ReadLine();
                    break;
                case 3:
                    TimeManager.VisitorArrival();
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to choose a number between 0-3!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }

    }
}
