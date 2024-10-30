using RpgTextGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RpgTextGame.Utilities.Attack
{
    internal class EnemyNormalAttack
    {
        public void EnemyAttack(ICharacter player, Enemy enemy, DamageAlgo damage, bool notDefeated)
        {
            {
                int damage1 = damage.NormalEnemyDamage(player, enemy);
                //player.CounterMode = false;

                if (RandomNumber.RandomCase() < 4) {
                    Block(damage1,player);
                } else if (RandomNumber.RandomCase() > 3 && RandomNumber.RandomCase() < 9) {
                    Dodge(player, damage1);
                } else {
                    Counter(player, damage1);
                }


                if (player.HealthPoints > 0) {
                    Console.WriteLine($" Remaining HP: [ {player.HealthPoints}/{player.MaxHealthPoints} ]");
                    notDefeated = true;
                } else {
                    Death pd = new Death();
                    pd.PlayerDeath(player, notDefeated);
                }
            }
        }

        private void Block(int damage1,ICharacter player)
        {
            player.HealthPoints -= damage1 / 2;
            Console.WriteLine(" [Block Success!] You blocked the attack, reducing damage by 50%.");
            Console.WriteLine($" [Hit!] You received {damage1 / 2} damage.");
        }

        private void Dodge(ICharacter player, int damage1)
        {
            if (RandomNumber.RandomCase() < 8) {
                Console.WriteLine("[Dodge Failed!] The enemy landed the attack.");
                player.HealthPoints -= damage1;
                Console.WriteLine($" [Hit!] You received {damage1} damage.");
            } else {
                Console.WriteLine("[Dodge Success!] You dodged the attack and took no damage!");
            }
        }
        private void Counter(ICharacter player,int damage1)
        {
            player.HealthPoints -= damage1;
            Console.WriteLine($" [Hit!] You received {damage1} damage.");
            Console.WriteLine("[Counter Mode!] You brace yourself for the enemy's next move. On your next turn, you will deal increased damage if you attack.");

            player.CounterMode = true;
        }
    }
}
