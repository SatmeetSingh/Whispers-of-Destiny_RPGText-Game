using RpgTextGame.Models;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Map.Outskirts
{
    internal class FightMonsters
    {
        public void NearByMonsters(ICharacter character)
        {
            Console.Clear();
            Console.Write("-----------------------------------------------------------");
            Console.WriteLine("\t-------------------------------------------------");
            Console.Write("                Fight Nearby Creatures                     ");
            Console.WriteLine($"\t\tPlayerHealth:{character.HealthPoints}/{character.MaxHealthPoints}     Mana: {character.Mana}/{character.MaxMana}");
            Console.WriteLine("\t-------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(" Select creatures to fight: \n");
            MonsterList monster = new MonsterList();
            List<Enemy> monsters  =  monster.GetMonster();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("[Press the number to select a creature] ");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("[Press 9 to select to Go Back]");
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("Enter your option: ");
            string option = Console.ReadLine();

            if (int.TryParse(option ,out int number)) {
               foreach (Enemy enemy in monsters) { 
                   if(enemy.Id == number)
                   {
                       FIghtPage fight = new FIghtPage();
                       fight.Fight(character,enemy);
                   }
               }
               if(number == 9)
               {
                   NavigationPage.NavigateToVillageOutskirt(character);
               }
            }
            else {
                Console.WriteLine("Invalid Choice , Press any key to make choice");
                Console.ReadKey();
                NearByMonsters(character);

            }
        }
    }
}
