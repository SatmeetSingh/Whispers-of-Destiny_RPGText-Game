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
    internal class PlayerNormalAttack
    {
        public void NormalAttack(DamageAlgo damage, Enemy enemy ,ICharacter player, bool notDefeated)
        {
                int damage2 = damage.NormalPlayerDamage(player, enemy);
                //enemy.CounterMode = false;

                if (RandomNumber.RandomCase() < 4) {
                      Block(enemy, damage2);
                }  else if (RandomNumber.RandomCase() > 3 && RandomNumber.RandomCase() < 9) {
                      Dodge(enemy, damage2);
                }  else {
                      CounterAttack(enemy, damage2);
                }

                if (enemy.Health > 0) {
                    Console.WriteLine($" {enemy.Name}'s HP: [ {enemy.Health}/{enemy.MaxHealth} ]");
                    notDefeated = true;
                } else {
                    Death ed = new Death();
                    ed.EnemyDeath(enemy, player, notDefeated);
                }
        }

        private void Dodge(Enemy enemy ,int damage2) {
            if (RandomNumber.RandomCase() < 8) {
                Console.WriteLine("[Dodge Failed!] You landed the attack.");
                enemy.Health -= damage2;
                Console.WriteLine($"[Success!] You dealt {damage2} damage to the {enemy.Name}.");
            } else {
                Console.WriteLine($"[Dodge Success!] {enemy.Name} dodged the attack and took no damage!");
            }
        }

        private void CounterAttack(Enemy enemy,int damage2) {
            enemy.Health -= damage2;
            Console.WriteLine($"[Success!] You dealt {damage2} damage to the {enemy.Name}.");
            Console.WriteLine($"[Counter Mode!] {enemy.Name} brace himself for the your next move. On {enemy.Name} next turn{enemy.Name} will deal increased damage.");

            enemy.CounterMode = true;
        }

        private void Block(Enemy enemy, int damage2) {
            enemy.Health -= damage2 / 2;
            Console.WriteLine($" [Block Success!] {enemy.Name} blocked the attack, reducing damage by 50%.");
            Console.WriteLine($"  [Success!] You dealt {damage2 / 2} damage to the {enemy.Name}.");
        }
    }
}
