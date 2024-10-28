using RpgTextGame.Models;
using RpgTextGame.src.GameMenu.Map.Outskirts;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.views.GameMenu.Map
{
    internal class MapExploration
    {
        public void ExploreWorld(ICharacter character)
        {
            Console.Clear();
            Console.WriteLine(" =================================================");
            Console.WriteLine("                   Explore the map                ");
            Console.WriteLine(" =================================================");

            Console.WriteLine("\n Where would you like to go? \n");
            Console.WriteLine("\t1. Dark Forest(Recommented levels 3-5)");
            Console.WriteLine("\t2. Village Market");
            Console.WriteLine("\t3. Village Outskirts(Recommended levels 0-3)");
            Console.WriteLine("\t4. Ancient Ruins(Recommended levels 5-7)");
            Console.WriteLine("\t5. Mountain Pass(Recommended levels 7-10)");
            Console.WriteLine("\t6. Another Map(Min level 10 Required) ");
            Console.WriteLine("\t7. Return to Camp");
            Console.WriteLine("\n ================================================= \n");
            Console.Write(" Please enter your choice: ");
            string Choice = Console.ReadLine();
            Console.WriteLine();
            switch (Choice)
            {
                case "1":
                    Console.WriteLine("Dark Forest");
                    Forest forest = new Forest();
                    forest.ForestMap();
                    break;
                case "2":
                    Console.WriteLine("Village Market");
                    Market villageMarket = new Market();
                    villageMarket.VillageMarket();
                    break;
                case "3":
                    Console.WriteLine("Village Outskirts");
                    VillageOutskirts outskirt = new VillageOutskirts();
                    outskirt.Outskirt(character);
                    break;
                case "4":
                    Console.WriteLine("Ancient Ruins");                   
                    break;
                case "5":
                    Console.WriteLine("Mountain Pass");
                    break;
                case "6":
                    Console.WriteLine("Another Map");
                    break;
                case "7":
                    Console.WriteLine("Return to camp");
                    NavigationPage.NavigateFromGameMenuPage(character);
                    break;
                default:
                    Console.WriteLine("Invalid Option, please any key to try again");
                    Console.ReadKey();
                    ExploreWorld(character);
                    break;
            }
        }
    }
}
