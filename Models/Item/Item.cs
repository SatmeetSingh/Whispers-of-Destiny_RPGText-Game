using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Models.Item
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion,
        Accessory,
        Food
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Rarity RarityLevel { get; set; }
        decimal ItemPrice { get; set; }
        decimal SellPrice { get; set; }
        ItemType Type { get; set; }
    }


    public abstract class BaseItem : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal SellPrice { get; set; }
        public Rarity RarityLevel { get; set; }

        public void display()
        {            
            Console.Clear();

            Console.WriteLine(" **********************************************");
            Console.WriteLine($" *                 Item Stats                 *");
            Console.WriteLine(" **********************************************");

            Console.WriteLine();
            Console.WriteLine($" Name: [ {Name} ]");
            Console.WriteLine($" Type:[ {Type} ]      RarityLevel:[ {RarityLevel} ]");
            Console.WriteLine($" Description:[ {Description} ]");

        }
    }

    public class EquipmentItem : BaseItem
    {
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
        public int LevelRequirement { get; set; }
        public bool IsStackable { get; set; }
        public bool IsEquipable { get; set; }
        public List<BonusEffect> BonusEffects { get; set; } 
        public EquipmentItem()
        {
            BonusEffects = new List<BonusEffect>();
        }
        public void EquipmentDisplay()
        {

            Console.WriteLine($"\n Durability: [ {Durability} ]/[ {MaxDurability} ]");
            Console.WriteLine($" LevelRequirement : [ {LevelRequirement} ]");
        }
    }

    public abstract class ConsumableItem : BaseItem
    {
        public int Quantity { get; set; }
        public bool IsUsable { get; set; }
        public int Cooldown { get; set; }

        public void ConsumableDisplay()
        {
            Console.WriteLine($"\n  Quantity: {Quantity}");
            Console.WriteLine($" Cooldown: {Cooldown}");
        }
    }

    public class Weapon : EquipmentItem
    {
        public string WeaponType { get; set; } // e.g., Sword, Bow, Axe

        public void WeaponDisplay() {
            Console.WriteLine($"Weapon : {WeaponType} ");
        }    
    }

    public class Armor : EquipmentItem
    {
        
        public string ArmorType { get; set; }

        public void ArmorDisplay()
        {
            Console.WriteLine($"Armor : {ArmorType}");
        }
    }

    public class Potion : ConsumableItem
    {
        public int HealAmount { get; set; }

        public void PotionDisplay()
        {
            Console.WriteLine($" Health:+{HealAmount}");
        }
    }

    public class Accessory : EquipmentItem
    {

        public int EffectMagnitude { get; set; } // Magnitude of the bonus 
       
        public void AssessoryDisplay()
        {
            Console.WriteLine($" Bonus:+{EffectMagnitude}");
        }
    }

    public class Food : ConsumableItem
    {
        public int HealthRestoration { get; set; } // Amount of health restored

        public void FoodDisplay()
        {
            Console.WriteLine($" Health:+{HealthRestoration}");
        }
    }

    public enum BonusEffect
    {
        None,                // No effect
        HealthIncrease,      // Increases maximum health
        ManaIncrease,        // Increases maximum mana
        StaminaIncrease,     // Increases maximum stamina

        AttackBoost,         // Increases attack power
        MagicBoost,          // Increases magic power
        CriticalHitChance,   // Increases critical hit chance

        DefenseBoost,        // Increases defense
        MagicResistance,     // Increases resistance to magic attacks
        EvasionBoost,        // Increases chance to evade attacks

        ExperienceBoost,     // Increases experience gained from battles

        ReflectDamage,       // Reflects a portion of damage back to the attacker
        Regeneration         // Grants health regeneration over time
    }


}

