using RpgTextGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    internal class Defeat
    {
        public void PlayerDefeated() {
            Console.WriteLine("\nYou have been defeated...");
            Console.WriteLine("Game Over.\n");
            Console.WriteLine("Press any key to Exit Game");
            Console.ReadLine();
        }
        public void EnemyDefeated(ICharacter player,Enemy enemy) {
            Console.WriteLine($"\nYou have defeated the {enemy.Name}");
            player.ExperiencePoints += (enemy.ExpAwarded - (player.CurrentLevel - enemy.Level)/5 );  
            Console.WriteLine($"You have gained {enemy.ExpAwarded} experience Points");

            if(player.ExperiencePoints >= player.ExperienceToNextlevel)
            {
                
                player.CurrentLevel++;
                Console.WriteLine($"Congratulations! You have reached Level {player.CurrentLevel}! You gain 5 stat points to distribute.");
                player.ExperiencePoints -= player.ExperienceToNextlevel;
                player.ExperienceToNextlevel += Convert.ToInt32(player.ExperienceToNextlevel / 4);
            }
            Console.WriteLine("\n Press any key to navigate to village outskirts");
            Console.ReadKey();
            NavigationPage.NavigateToVillageOutskirt(player);
        }
    }
}
