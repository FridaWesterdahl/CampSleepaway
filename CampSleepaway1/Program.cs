// See https://aka.ms/new-console-template for more information
using CampSleepaway1.Models;
using CampSleepaway1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampSleepaway1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uncomment for loading the database
            //LoadDB loadDB = new LoadDB();
            //loadDB.LoadAll();

            Menu menu = new Menu();
            menu.ShowMenu();



        }
    }

}
