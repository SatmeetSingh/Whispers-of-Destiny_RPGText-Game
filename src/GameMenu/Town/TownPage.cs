using RpgTextGame.Models;
using RpgTextGame.Utilities;
using RpgTextGame.views.GameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Town
{
     class TownPage
    {
        public void ExploreTown(ICharacter character)
        {
            Console.Clear();
            Console.WriteLine("\n =================================================");
            Console.WriteLine("                 Explore the town                 ");
            Console.WriteLine(" =================================================");
            Console.WriteLine(" You step into the vibrant town filled with life and excitement.\n");

            Console.WriteLine(" Where would you like to go? ");
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine("\t1. Visit the MarketPlace ");
            Console.WriteLine("\t2. Stop by the BlackSmith ");
            Console.WriteLine("\t3. Check out the Tavern ");
            Console.WriteLine("\t4. Explore the town square ");
            Console.WriteLine("\t5. Return to Main Menu ");
            Console.WriteLine(" -------------------------------------------------\n");

            Console.Write("Enter your choice(1-5): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Visit the Market ");
                    break;
                case "2":
                    Console.WriteLine("Stop by the BlackSmith ");
                    break;
                case "3":
                    Console.WriteLine("Check out the Tavern");
                    break;
                case "4":
                    Console.WriteLine("Explore the town Square");
                    break;
                case "5":
                    Console.WriteLine("Return to main menu");
                    NavigationPage.NavigateFromGameMenuPage(character);
                    break;
                default:
                    Console.WriteLine("Invalid Choice , Please Press Any key to make choice again");
                    Console.ReadKey();
                    ExploreTown(character);     
                    break;
            }
        }
    }
}
