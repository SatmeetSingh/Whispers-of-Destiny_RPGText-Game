﻿using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RpgTextGame.Models
{
    interface IEnemy
    {
        int Id { get; set; }
        string Name { get; set; } 
        int Level { get; set; }
        int ExpAwarded { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Damage { get; set; }
        int Defance { get; set; }
        EnemyRarity Rarity { get; set; }
        void Display();

    }
    public enum EnemyRarity{
        Common,
        Elite,
        Boss
    }
    public class Enemy : IEnemy
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Level { get; set; }
        public int ExpAwarded { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int Defance { get; set; }
        public bool CounterMode { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnemyRarity Rarity { get; set; }

        public Enemy()
        {
            CounterMode = false;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"| Enemy Name: {Name}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"| Level:        {Level}");
            Console.WriteLine($"| Health:       {Health}/{MaxHealth}");
            Console.WriteLine($"| Damage:       {Damage}");
            Console.WriteLine($"| Damage:       {Defance}");
            Console.WriteLine($"| Rarity:       {Rarity}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Prepare for battle or take action...");
            Console.WriteLine();
        }

        public void CounterAttack(DamageAlgo damage, Enemy enemy, ICharacter player)
        {
            Console.WriteLine($" [Counter Attack] {enemy.Name} unleash a powerful counterattack!");
            int counterDamage = damage.NormalEnemyDamage(player, enemy) * 2; 
            player.HealthPoints -= counterDamage;
            Console.WriteLine($"c[Success!] {enemy.Name} dealt {counterDamage} counter damage to you.");
            enemy.CounterMode = false;
            Console.WriteLine($" {player.Name}'s HP: [ {player.HealthPoints}/{ player.MaxHealthPoints} ]");
        }
    }
}
