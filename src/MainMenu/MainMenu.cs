using RpgTextGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.views.MainMenu
{
    internal class MainMenuPage
    {
        public void MainPage()
        {
            Console.Clear();

            // Display Text
            Console.WriteLine("\n =================================================\n");
            Console.WriteLine("           Welcome to Whispers of Destiny            ");
            Console.WriteLine("\n =================================================\n");
            Console.WriteLine("            Text-Based RPG Adventure                 ");
            Console.WriteLine("\n =================================================\n");

            Console.WriteLine(" Chose the option to begin:\n");
            Console.WriteLine("\t1. Create New Character ");
            Console.WriteLine("\t2. Load Game");
            Console.WriteLine("\t3. Game Settings");
            Console.WriteLine("\t4. Exit\n");
            Console.WriteLine("\n =================================================\n");

            Console.Write(" Please Enter your choice(1-4): ");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    CreateCharacterPage();
                    break;
                case "2":
                    Console.WriteLine(" Load Game");
                    break;
                case "3":
                    Console.WriteLine(" Game Settings");
                    GameSettingsPage.GameSettings();
                    break;
                case "4":
                    Console.Write(" Are you sure you want to exit this game(Press key 'y'): ");
                    ConsoleKeyInfo keyPress = Console.ReadKey();
                    if (keyPress.Key == ConsoleKey.Y)
                    {
                        break;
                    }
                    else
                    {
                        MainPage();
                        break;
                    }
                default:
                    Console.WriteLine(" \nInvalid Choice , Press Any Key to Make Choice again");
                    Console.ReadKey();
                    MainPage();
                    break;
            }
        }

        private void CreateCharacterPage()
        {
            CharacterCreation newCharacterCreationPage = new CharacterCreation();
            newCharacterCreationPage.CreateNewCharacter();
        }
    }
}
