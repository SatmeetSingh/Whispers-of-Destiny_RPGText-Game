using RpgTextGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    public class Death
    {
        public void PlayerDeath(ICharacter player, bool notDefeated) {
            Console.WriteLine($" Remaining HP: [ 0/{player.MaxHealthPoints} ]");
            Defeat defeat = new Defeat();
            defeat.PlayerDefeated();
            notDefeated = false;
        }
        public void EnemyDeath(Enemy enemy ,ICharacter player ,bool notDefeated ) {
            Console.WriteLine($" {enemy.Name}'s HP: [ 0/{enemy.MaxHealth} ]");
            Defeat win = new Defeat();
            win.EnemyDefeated(player, enemy);
            notDefeated = false;
        }
    }
}
