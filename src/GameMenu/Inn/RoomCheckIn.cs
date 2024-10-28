using RpgTextGame.Models;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Inn
{
    class RoomCheckIn
    {
        public void Room(ICharacter character)
        {
            Console.Clear();

            Console.WriteLine(" =================================================");
            Console.WriteLine("                   Check - In Room                ");
            Console.WriteLine(" =================================================");

            Console.WriteLine(" Welcome, adventurer! Here you can check in to your room and explore your options.\n");

            Console.WriteLine(" Would you like to sleep in a room to restore your condition? ");
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine("   Room Fee: 50 Bronze ");
            Console.WriteLine("   Restores: ");
            Console.WriteLine("   - Full Health ");
            Console.WriteLine("   - All Buffs Reset ");
            Console.WriteLine("   - Mana Restored ");
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine(" What would you like to do? ");
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine("\t1. Sleep and Restore");
            Console.WriteLine("\t2. Return to Main Menu");
            Console.WriteLine(" -------------------------------------------------");

            Console.Write("Enter your Choice(1-2) : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You have chosen to sleep in the room.");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("You paid 50 Bronze. Your health and status are fully restored!");
                    if(character.Money.TotalMoney() < 50)
                    {
                        Console.WriteLine("Money is not Enough");
                        Console.WriteLine("Press any key to go back to main menu");
                        Console.ReadKey();
                        NavigationPage.NavigateToInnPage(character);
                    } else
                    {
                        character.HeathPoints = character.MaxHeathPoints;
                        character.Mana = character.MaxMana;
                        character.Money.SubtractCurrency(0,0,50);
                        Console.WriteLine($"Remaining Money : {character.Money.PrintCurrency()}");
                    }
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    NavigationPage.NavigateToInnPage(character);
                    break;
                case "2":
                    Console.WriteLine("");
                    NavigationPage.NavigateToInnPage(character);
                    break;
                default:
                    break;
            }
        }
    }
}
