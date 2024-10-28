using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.views.MainMenu
{
    internal class GameSettingsPage
    {
        public static void GameSettings()
        {
            Console.Clear();

            Console.WriteLine("\n =================================================\n");
            Console.WriteLine("                    Game Settings                     ");
            Console.WriteLine("\n =================================================\n");

            Console.WriteLine("\t1. Adjust Text Speed");
            Console.WriteLine("\t2. Change Difficulty Level (Easy/Medium/Hard)");
            Console.WriteLine("\t3. Enable/disable sound");
            Console.WriteLine("\t4. Back to Main Menu");

            Console.Write("Please choose an option: ");
            string option = Console.ReadLine();

            switch (option) {
                case "1":
                    Console.WriteLine("Adjusting text speed");
                    break;
                case "2":
                    Console.WriteLine("Change Difficulty Level (Easy/Medium/Hard)");
                    break;
                case "3":
                    Console.WriteLine("Enable/disable sound");
                    break;
                case "4":
                    Console.WriteLine("Back to Main Menu");
                    NavigationPage.NavigateToMainPage();
                    break;
                default:
                    Console.WriteLine("Invalid Statement, try again");
                    GameSettings();
                    break;
            };
        }
    }
}
