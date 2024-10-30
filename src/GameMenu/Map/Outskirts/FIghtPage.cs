using RpgTextGame.Models;
using RpgTextGame.Utilities;
using RpgTextGame.Utilities.Attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Map.Outskirts
{
    internal class FIghtPage
    {
        public void Fight(ICharacter player , Enemy enemy) {

            Console.Clear();
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine("             BATTLE START!");
            Console.WriteLine(" ---------------------------------------");
            Console.Write($" Your Character: [{player.Name}]");
            Console.WriteLine($" Class: [{player.CharClass}]");
            Console.WriteLine($" Level: [{player.CurrentLevel}]");
            Console.Write($" HP: [{player.HealthPoints}] / [{player.MaxHealthPoints}]\t");
            Console.WriteLine($" Mana: [{player.Mana}] / [{player.MaxMana}]");
            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------");
            Console.Write($" Enemy: [{enemy.Name}]");
            Console.WriteLine($" (Level: {enemy.Level})");
            Console.WriteLine($" HP: [{enemy.Health}] / [{enemy.MaxHealth}]");
            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------");
            bool NotDefeated;
            do
            {

                Console.WriteLine(" Choose Your Action:");
                Console.WriteLine("\t1. Attack");
                Console.WriteLine("\t2. Use Item");
                Console.WriteLine("\t3. Flee");
                Console.WriteLine("---------------------------------------\n");

                Console.Write(" Select your choice(1-4): ");
                string option = Console.ReadLine();
                NotDefeated = true;
                switch (option)
                {
                    case "1":
                        Attack(player, enemy, NotDefeated );
                        break;
                    case "2":
                        Console.WriteLine(" Use Item");
                        break;
                    case "3":
                        Console.WriteLine(" Flee");
                        Flee(player, enemy);
                        break;
                    default:
                        Console.WriteLine(" Invalid Option, press any key to chose again");
                        Console.ReadKey();
                        Fight(player, enemy);
                        break;
                }
            } while (NotDefeated);
        }

        private void Attack(ICharacter player,Enemy enemy ,bool notDefeated)
        {
            Console.WriteLine(" You chose to attack");
            Console.WriteLine("\t1.Normal Attack");
            Console.WriteLine("\t2.Power Attack(mana:5)\n");
            Console.Write(" Chose the attack option: ");
            string option = Console.ReadLine();

            if (int.TryParse(option,out int result)) {
                
                if(result == 1) {
                    DamageAlgo damage = new DamageAlgo();
                    if (player.CounterMode) {
                        player.CounterAttack(damage, enemy, player);
                    } else {
                        Console.WriteLine($" You swing your punch at {enemy.Name}!");
                        if (RandomNumber.RandomCase() <= 8) {
                            PlayerNormalAttack attack = new PlayerNormalAttack();
                            attack.NormalAttack(damage, enemy, player, notDefeated);
                        } else {
                            Console.WriteLine($" [Miss!] Your attack missed the {enemy.Name}");
                            notDefeated = true;
                        }
                    }

                    Console.WriteLine("-----------------------------------------\n");

                    Console.WriteLine($" {enemy.Name} slashes at you with a rusty dagger!");

                    if (enemy.CounterMode) {
                        enemy.CounterAttack(damage, enemy, player);
                    } else {
                       if (RandomNumber.RandomCase() > 2) {
                            EnemyNormalAttack attack = new EnemyNormalAttack();
                            attack.EnemyAttack(player,enemy,damage,notDefeated);
                       }
                       else {
                          Console.WriteLine($" [Miss!] {enemy.Name} missed the attack");
                          notDefeated = true;
                       }
                     }

                    Console.WriteLine(" -----------------------------------------\n");

                } else if( result == 2) {
                    DamageAlgo damage = new DamageAlgo();
                    
                    if(player.Mana < 5) {
                        Console.WriteLine($" You tried to swing your attack charged with mana at {enemy.Name}!");
                        Console.WriteLine($" You found mana not enough");

                        Console.WriteLine($" [Miss!] Your attack missed the {enemy.Name}");
                        notDefeated = true;

                        Console.WriteLine(" -----------------------------------------\n");

                        int damages = damage.NormalEnemyDamage(player,enemy);
                        player.HealthPoints -= damages;
                        Console.WriteLine($" [Hit!] You received {damages} damage.");

                        if (player.HealthPoints > 0) {
                            Console.Write($" Remaining HP: [ {player.HealthPoints}/{player.MaxHealthPoints} ]\t");
                            Console.WriteLine($" Remaining Mana: [ {player.Mana}/{player.MaxMana} ]");
                            notDefeated = true;
                        } else {
                            Death pd = new Death();
                            pd.PlayerDeath(player, notDefeated);
                        }
                    } else {
                        Console.WriteLine($" You swing your attack charged with mana at {enemy.Name}!");
                        PlayerPowerAttack attack = new PlayerPowerAttack();
                        attack.PowerAttack(damage, enemy, player, notDefeated);
                 
                    if (enemy.Health > 0) {
                        Console.WriteLine($" {enemy.Name}'s HP: [ {enemy.Health}/{enemy.MaxHealth} ]");
                        notDefeated = true;
                    } else {
                          Death ed = new Death();
                        ed.EnemyDeath(enemy, player, notDefeated);
                    }

                    Console.WriteLine(" -----------------------------------------\n");
                    Console.WriteLine($" {enemy.Name} slashes at you with a rusty dagger!");
                        if (RandomNumber.RandomCase() <= 8) {
                            EnemyNormalAttack attack1 = new EnemyNormalAttack();
                            attack1.EnemyAttack(player, enemy, damage, notDefeated);
                        } else {
                            Console.WriteLine($" [Miss!] {enemy.Name} missed the attack");
                            notDefeated = true;
                        }
                    }
                } else {
                    Console.WriteLine(" Invalid Choice , Press any key to make choice");
                    Console.ReadKey();
                    notDefeated = false;
                    Fight(player, enemy);
                }
            } else {
                Console.WriteLine(" Invalid Choice - Please enter Number, Press any key to make choice");
                Console.ReadKey();
                Fight(player, enemy);
            }
        }

        private void Flee(ICharacter player, Enemy enemy)
        {
            int RandonNum = RandomNumber.RandomCase();
            Console.WriteLine(" You attempt to flee from the battle!\r\n");
            Console.WriteLine(" Rolling for escape...\n");
            if (RandonNum <= 5) {
                Console.WriteLine(" [Roll Outcome: Failure]\n");
                Console.WriteLine($" You try to escape, but [{enemy.Name}] blocks your path!\r\nYou are unable to flee and must continue the fight!");
                Console.WriteLine("\n ---------------------------------------");
                Thread.Sleep(300);
                Fight(player, enemy);
            } else {
                Console.WriteLine(" [Roll Outcome: Success]\n");
                Console.WriteLine($" You dash away, evading the creature's grasp. The battle is over.");
                Console.WriteLine("\n ---------------------------------------");
                Console.WriteLine(" Press any key to Fight");
                Console.ReadKey();
                NavigationPage.NavigateToVillageOutskirt(player);
            }
        }
    }
}
