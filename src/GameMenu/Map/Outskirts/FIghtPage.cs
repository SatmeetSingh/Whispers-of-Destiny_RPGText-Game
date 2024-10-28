using RpgTextGame.Models;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RpgTextGame.src.GameMenu.Map.Outskirts
{
    internal class FIghtPage
    {
        public void Fight(ICharacter player , Enemy enemy) {

            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("            BATTLE START!");
            Console.WriteLine("---------------------------------------");
            Console.Write($"Your Character: [{player.Name}]");
            Console.WriteLine($"Class: [{player.CharClass}]");
            Console.WriteLine($"Level: [{player.CurrentLevel}]");
            Console.Write($"HP: [{player.HeathPoints}] / [{player.MaxHeathPoints}]\t");
            Console.WriteLine($"Mana: [{player.Mana}] / [{player.MaxMana}]");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.Write($"Enemy: [{enemy.Name}]");
            Console.WriteLine($"(Level: {enemy.Level})");
            Console.WriteLine($"HP: [{enemy.Health}] / [{enemy.MaxHealth}]");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Choose Your Action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Defend");
            Console.WriteLine("4. Flee");
            Console.WriteLine("---------------------------------------\n");

            Console.Write("Select your choice(1-5): ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Attack(player, enemy);
                    break;
                case "2":
                    Console.WriteLine("Use Item");
                    break; 
                case "3":
                    Console.WriteLine("Defend");
                    break;
                case "4":
                    Console.WriteLine("Flee");
                    Flee(player, enemy);
                    break;
                default:
                    Console.WriteLine("Invalid Option, press any key to chose again");
                    Console.ReadKey();
                    Fight(player, enemy);
                    break;
            }
        }

        private void Attack(ICharacter player,Enemy enemy)
        {
            Console.WriteLine("You chose to attack");
            Console.WriteLine("\t1.Normal Attack");
            Console.WriteLine("\t2.Power Attack(mana:5)\n");
            Console.WriteLine("Chose the attack option:");
            string option = Console.ReadLine();

            if (int.TryParse(option,out int result)) {
                if(result == 1)
                {
                    Console.WriteLine($"You swing your punch at {enemy.Name}!");
                    if(RandomNumber.RandomCase() <= 8)
                    {
                        DamageAlgo damage = new DamageAlgo();
                        enemy.Health -= damage.NormalPlayerDamage(player);
                        Console.WriteLine($"[Success!] You dealt {damage.NormalPlayerDamage(player)} damage to the {enemy.Name}.");
                        if(enemy.Health > 0)
                        {
                            Console.WriteLine($"{enemy.Name}'s HP: [ {enemy.Health}/{enemy.MaxHealth} ]");
                        } else
                        {
                            Console.WriteLine($"{enemy.Name}'s HP: [ 0/{enemy.MaxHealth} ]");
                            Defeat win = new Defeat();
                            win.EnemyDefeated(player, enemy);
                        }
                    } else
                    {
                        Console.WriteLine($"[Miss!] Your attack missed the {enemy.Name}");
                    }
                    Console.WriteLine("-----------------------------------------\n");

                    Console.WriteLine($"{enemy.Name} slashes at you with a rusty dagger!");
                    if (RandomNumber.RandomCase() > 2)
                    {
                        int damage = (enemy.Damage - Convert.ToInt32(player.Constitution/4));
                        player.HeathPoints -= damage;
                        Console.WriteLine($"[Hit!] You received {damage} damage.");
                        if(player.HeathPoints > 0)
                        {
                        Console.WriteLine($"your HP: [ {player.HeathPoints}/{player.MaxHeathPoints} ]");
                        } else
                        {
                            Console.WriteLine($"your HP: [ 0/{player.MaxHeathPoints} ]");
                            Defeat defeat = new Defeat();
                            defeat.PlayerDefeated();
                        }
                    }
                    else {
                        Console.WriteLine($"[Miss!] {enemy.Name} missed the attack");
                    }
                    Console.WriteLine("-----------------------------------------\n");

                    Fight(player, enemy);
                } else if( result == 2)
                {
                    Console.WriteLine($"You swing your attack charged with mana at {enemy.Name}!");

                    DamageAlgo damage = new DamageAlgo();
                    enemy.Health -= (damage.NormalPlayerDamage(player) + 2) ;
                    Console.WriteLine($"[Success!] You dealt {damage.NormalPlayerDamage(player) + 2} damage to the {enemy.Name}.");
                    if (enemy.Health > 0)
                    {
                        Console.WriteLine($"{enemy.Name}'s HP: [ {enemy.Health}/{enemy.MaxHealth} ]");
                    }
                    else
                    {
                        Console.WriteLine($"{enemy.Name}'s HP: [ 0/{enemy.MaxHealth} ]");
                        Defeat win = new Defeat();
                        win.EnemyDefeated(player, enemy);
                    }

                    Console.WriteLine("-----------------------------------------\n");
                    Console.WriteLine($"{enemy.Name} slashes at you with a rusty dagger!");

                    int damages = (enemy.Damage - Convert.ToInt32(player.Constitution / 4));
                    player.HeathPoints -= damages;
                    Console.WriteLine($"[Hit!] You received {damage} damage.");
                    if (player.HeathPoints > 0)
                    {
                        Console.WriteLine($"your HP: [ {player.HeathPoints}/{player.MaxHeathPoints} ]");
                    }
                    else
                    {
                        Console.WriteLine($"your HP: [ 0/{player.MaxHeathPoints} ]");
                        Defeat defeat = new Defeat();
                        defeat.PlayerDefeated();
                    }


                    // Add the code
                } else
                {
                    Console.WriteLine("Invalid Choice , Press any key to make choice");
                    Console.ReadKey();
                    Fight(player, enemy);
                }
            }
            else {
                Console.WriteLine("Invalid Choice - Please enter Number, Press any key to make choice");
                Console.ReadKey();
                Fight(player, enemy);
            }

        }

        private void Flee(ICharacter player, Enemy enemy)
        {
            int RandonNum = RandomNumber.RandomCase();
            Console.WriteLine("You attempt to flee from the battle!\r\n");
            Console.WriteLine("Rolling for escape...\n");
            if (RandonNum <= 5) {
                Console.WriteLine("[Roll Outcome: Failure]\n");

                Console.WriteLine($"You try to escape, but [{enemy.Name}] blocks your path!\r\nYou are unable to flee and must continue the fight!");
                Console.WriteLine("\n---------------------------------------");
                Thread.Sleep(300);
                Fight(player, enemy);
            } else
            {
                Console.WriteLine("[Roll Outcome: Success]\n");
                Console.WriteLine($"You dash away, evading the creature's grasp. The battle is over.");
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine("Press any key to Fight");
                Console.ReadKey();
                NavigationPage.NavigateToVillageOutskirt(player);
            }
        }
    }
}
