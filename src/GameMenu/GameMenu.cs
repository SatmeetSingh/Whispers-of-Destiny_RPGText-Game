using RpgTextGame.Models;
using RpgTextGame.src.GameMenu.Inn;
using RpgTextGame.Utilities;
using RpgTextGame.views.GameMenu.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.views.GameMenu
{
    class GameMenus
    {
        public void GameMenuPage(ICharacter character)
        {
            Console.Clear();


            Console.WriteLine(" =================================================");
            Console.WriteLine($"\n         Welcome, {character.Name}             ");
            Console.WriteLine($"         You are {character.CharClass}, Level {character.CurrentLevel}");
            Console.WriteLine("\n          Current location: Town \n");
            Console.WriteLine(" =================================================");

            Console.WriteLine(" What would you like to do: \n");

            Console.WriteLine("\t1. Explore the world");
            Console.WriteLine("\t2. View Character Stats");
            Console.WriteLine("\t3. Manage Inventory ");
            Console.WriteLine("\t4. Rest at the Inn");
            Console.WriteLine("\t5. Explore the town");
            Console.WriteLine("\t6. Save Game");
            Console.WriteLine("\t7. Return to Main Menu\n");

            Console.WriteLine(" =================================================\n");

            Console.Write(" Please enter your choice: ");
            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    Console.WriteLine(" Welcome to new world");
                    MapExploration mapExploration = new MapExploration();
                    mapExploration.ExploreWorld(character);
                    break;
                case "2":
                    character.Display();
                    character.ReturnMethod(character);
                    break;
                case "3":
                    Console.WriteLine(" Manage Inventory");
                    break;
                case "4": 
                    Console.WriteLine(" Resting at the inn");
                     NavigationPage.NavigateToInnPage(character);
                    break;  
                case "5":
                    Console.WriteLine(" Explore the town");

                    break;
                case "6":
                    Console.WriteLine(" Save game");
                    break;
                case "7":
                    Console.WriteLine(" Return to Main Menu");
                    Console.WriteLine(" Are you sure, you want to return to Main Menu, if you haven't saved your progress then you may lose all your progress");
                    Console.WriteLine(" Press any key to Return to Main Menu");

                    Console.ReadKey();
                    NavigationPage.NavigateToMainPage();
                    break;
                default:
                    Console.WriteLine(" Invalid Choice, Enter any key to try again");
                    Console.ReadKey();
                    GameMenuPage(character);
                    break;
            };
        }
    }
}
