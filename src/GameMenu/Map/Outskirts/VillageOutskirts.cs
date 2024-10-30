using RpgTextGame.Models;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Map.Outskirts
{
    internal class VillageOutskirts
    {
        public void Outskirt(ICharacter character)
        {
            Console.Clear();
            Console.Write("-----------------------------------------------------------");
            Console.WriteLine("\t-------------------------------------------------");
            Console.Write("                    Village Outskirts                      ");
            Console.WriteLine($"\t\tPlayerHealth:{character.HealthPoints}/{character.MaxHealthPoints}     Mana: {character.Mana}/{character.MaxMana}");
            Console.Write("                (Recommended Levels: 0-3)                  ");
            Console.WriteLine("\t-------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(" Description: ");
            Console.WriteLine(" You stand on the outskirts of the village. The forest ahead seems quiet,\n but there's a subtle danger lurking.Birds chirp, and a light breeze stirs the trees.\n Farmers sometimes talk of strange creatures that roam the woods.");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(" What would you like to do? ");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("\t1. Explore the Forest");
            Console.WriteLine("\t2. Fight Nearby Creatures");
            Console.WriteLine("\t3. Search for Loot");
            Console.WriteLine("\t4. Rest at the Campsite");
            Console.WriteLine("\t5. Return to the Village");
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("Please select youe choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Explore the forest");
                    break;
                case "2":
                    Console.WriteLine("Fight Nearby Creatures");
                    FightMonsters find = new FightMonsters();
                    find.NearByMonsters(character);
                    break;
                case "3":
                    Console.WriteLine("Search for Loot");
                    break;
                case "4":
                    Console.WriteLine("Rest at the Campsite");
                    break;
                case "5":
                    Console.WriteLine("Return to the Village");
                    NavigationPage.NavigationToMapExplorationPage(character);
                    break;
                default:
                    Console.WriteLine("Invalid choice , Press any key to chose again");
                    Console.ReadKey();
                    Outskirt(character);
                    break;
            }

            Console.ReadKey();
        }
    }
}
