using RpgTextGame.Utilities;
using RpgTextGame.views.GameMenu;
using RpgTextGame.views.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Models
{
    public interface ICharacter
    {
        Guid Id { get; set; }
        string Name { get; set; }
        ClassType CharClass { get ; set;}
        int CurrentLevel { get; set; } 
        int HeathPoints { get; set; }
        int MaxHeathPoints { get; set; }
        int Mana { get; set; }  
        int MaxMana { get; set; }
        int Strength { get; set; }
        int Intelligence { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        List<string> PlayerInventory { get; set; }
        int ExperiencePoints { get; set; }
        int ExperienceToNextlevel { get; set; }  
        Currency Money { get; }

        int RemainingPoints { get; set; }
        void Display();
        void ReturnMethod(ICharacter character);
    }
    internal class Character : ICharacter
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ClassType CharClass { get ; set;}
        public int CurrentLevel { get; set; }
        public int HeathPoints { get; set; }
        public int MaxHeathPoints { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public List<string> PlayerInventory { get; set; } = new List<string>();
        public int ExperiencePoints {  get; set; }
        public int ExperienceToNextlevel {  get; set; }

        public int RemainingPoints { get; set; }
        public Currency Money { get; private set; }

        public Character() {
            Name = string.Empty;
            CharClass = ClassType.Warrior;
            CurrentLevel = 0;
            HeathPoints = 50;
            MaxHeathPoints = 50;
            Mana =  10;
            MaxMana =  10;
            Strength = 0;
            Intelligence = 0;
            Dexterity = 0;
            Constitution = 0;
            ExperiencePoints = 0;
            RemainingPoints = 0;
            ExperienceToNextlevel = 100;
            Money = new Currency(0,5,50);   
        }

        public void Display()
        {
            Console.Clear();

            Console.WriteLine("\n =================================================");
            Console.WriteLine("                  Character Stats                   ");
            Console.WriteLine(" =================================================\n");

            Console.WriteLine();
            Console.WriteLine($"\tName: [ {Name} ]");
            Console.WriteLine($"\tClass: [ {CharClass} ]");
            Console.WriteLine($"\tLevel: [ {CurrentLevel} ]");
            Console.WriteLine($"\tExp: [ {ExperiencePoints} ]/[ {ExperienceToNextlevel} ]");
            Console.WriteLine($"\tHP: [ {HeathPoints} ]/[ {MaxHeathPoints} ]");
            Console.WriteLine($"\tMana: [ {Mana} ]/[ {MaxMana} ]\n");
            Console.WriteLine($"\tStrength: [ {Strength} ]");
            Console.WriteLine($"\tDexterity: [ {Dexterity} ]");
            Console.WriteLine($"\tIntelligence: [ {Intelligence} ]");
            Console.WriteLine($"\tConstitution: [ {Constitution} ]\n");

            Console.WriteLine($"\tRemaining Points : [ {RemainingPoints} ]\n");

            Console.WriteLine($"\tWealth:\tGold: [ {Money.Gold} ]\tSilver: [ {Money.Silver} ]\tBronze: [ {Money.Bronze} ]\n\n");


        }

        public void ReturnMethod(ICharacter character)
        {
            Console.WriteLine("1. Add points to character: ");
            Console.Writeline("2. Return to Game MenuPage: ");
            int returnChoice = int.Parse(Console.ReadLine());

            if (returnChoice == 1)
            {
                if(character.RemainingPoints > 0)
                {
                    CharacterCreation add = new CharacterCreation();
                    add.AddPoints(character, character.RemainingPoints);
                } else
                {
                    Console.WriteLine("\n You don't have enough points to add.\nPress any key to go back");
                    Console.ReadKey();
                }

                NavigationPage.NavigateFromGameMenuPage(character);
            }
            else if (returnChoice == 2)
            {
                NavigationPage.NavigateFromGameMenuPage(character);
            } else
            {
                Console.WriteLine("Invalid Choice, press any key to make choice again");
                Console.ReadKey();
                Display();
            }
        }  
    }

    public enum ClassType
    {
        Warrior,
        Mage,
        Thief,
        Archer
    }
}
