using RpgTextGame.Models;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgTextGame.views.GameMenu;

namespace RpgTextGame.views.MainMenu
{
    internal class CharacterCreation
    {
        public void CreateNewCharacter()
        {
            Console.Clear();

            Console.WriteLine("\n =================================================\n");
            Console.WriteLine("                   Character Creation                 ");
            Console.WriteLine("\n =================================================\n");

            ICharacter newCharacter = new Character();
            Console.Write(" Please Enter your character's name: ");
            newCharacter.Name = Console.ReadLine();

            Console.WriteLine("\n Please Choose your class");
            Console.WriteLine("\t1. Warrior");
            Console.WriteLine("\t2. Mage");
            Console.WriteLine("\t3. Thief");
            Console.WriteLine("\t4. Archer\n");

            Console.WriteLine("\n =================================================\n");

            Console.Write(" Please enter your choice (Default Warrior class): ");
            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    newCharacter.CharClass = ClassType.Warrior;
                    break;
                case "2":
                    newCharacter.CharClass = ClassType.Mage;
                    break;
                case "3":
                    newCharacter.CharClass = ClassType.Thief;
                    break;
                case "4":
                    newCharacter.CharClass = ClassType.Archer;
                    break;
                default:
                    Console.WriteLine("Invalid Choice, Default Worrior Class");
                    newCharacter.CharClass = ClassType.Warrior;
                    break;
            };

            Console.WriteLine($"\n You have 10 points to distribute among your attributes");
            int initialPoints = 10;
            int allocatedPoints = 0;
            while (allocatedPoints < initialPoints)
            {
                int remainingPoints = initialPoints - allocatedPoints;
                if(allocatedPoints > 0 && allocatedPoints < 10)
                {
                    Console.WriteLine($"\n Remaining Points {initialPoints - allocatedPoints} left");
                    Console.WriteLine("Add the remaining points to your character");
                }
                if (remainingPoints < 4)
                {
                    Console.WriteLine("You have limited points left. Allocate them freely.");
                    while (remainingPoints > 0)
                {
                    Console.Write($"\t1. Strength (must be <= {remainingPoints}): ");
                    int strengthInp = Convert.ToInt32(Console.ReadLine());
                    if (strengthInp > remainingPoints)
                    {
                        Console.WriteLine("Invalid. Not enough points remaining.");
                        continue; // Retry input
                    }
                    newCharacter.Strength += strengthInp;
                    remainingPoints -= strengthInp;
                    allocatedPoints += strengthInp;

                    if (remainingPoints == 0) break;

                    Console.Write($"\t2. Intelligence (must be <= {remainingPoints}): ");
                    int intelligenceInp = Convert.ToInt32(Console.ReadLine());
                    if (intelligenceInp > remainingPoints)
                    {
                        Console.WriteLine("Invalid. Not enough points remaining.");
                        continue;
                    }
                    newCharacter.Intelligence += intelligenceInp;
                    remainingPoints -= intelligenceInp;
                    allocatedPoints += intelligenceInp;
                    if (remainingPoints == 0) break;

                   Console.Write($"\t3. Dexterity (must be <= {remainingPoints}): ");
                   int dexterityInp = Convert.ToInt32(Console.ReadLine());
                   if (dexterityInp > remainingPoints)
                   {
                      Console.WriteLine("Invalid. Not enough points remaining.");
                      continue;
                    }
                   newCharacter.Dexterity += dexterityInp;
                   remainingPoints -= dexterityInp;
                   allocatedPoints += dexterityInp;

                   if (remainingPoints == 0) break;

                   Console.Write($"\t4. Constitution (must be <= {remainingPoints}): ");
                   int constitutionInp = Convert.ToInt32(Console.ReadLine());
                   if (constitutionInp > remainingPoints)
                   {
                      Console.WriteLine("Invalid. Not enough points remaining.");
                      continue;
                   }
                   newCharacter.Constitution += constitutionInp;
                   remainingPoints -= constitutionInp;
                   allocatedPoints += constitutionInp;
                }
                if(newCharacter.Dexterity > 0 && newCharacter.Strength > 0 && newCharacter.Constitution > 0 && newCharacter.Intelligence > 0) {
                        break;
                    } else {
                        Console.WriteLine("All values must have minimun 1 point");
                        Console.WriteLine("Press amy key to do it again");
                        Console.ReadKey();
                        CreateNewCharacter();
                    }
             }

                Console.Write("\t1. Strength : ");
                int strength = 0;
                while (strength <= 0)
                {
                    //Console.Write("\t1. Strength (must be > 0): ");
                    strength = Convert.ToInt32(Console.ReadLine());
                    if (strength <= 0)
                    {
                        Console.WriteLine("Strength cannot be zero or negative. Please enter a valid value.");
                    }
                }
                if (allocatedPoints + strength > initialPoints) {
                    Console.WriteLine("You don't have enough points. Please try again.");
                    continue;
                } else {
                   newCharacter.Strength = strength;
                   allocatedPoints += strength;
                }


                Console.Write("\t2. Intelligence: ");
                int intelligence = 0;
                while (intelligence <= 0)
                {
                    //Console.Write("\t2. Intelligence (must be > 0): ");
                    intelligence = Convert.ToInt32(Console.ReadLine());
                    if (intelligence <= 0)
                    {
                        Console.WriteLine("Intelligence cannot be zero or negative. Please enter a valid value.");
                    }
                }
                if (allocatedPoints + intelligence > initialPoints) {
                    Console.WriteLine("You don't have enough points. Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Intelligence = intelligence;
                    allocatedPoints += intelligence;
                }

                Console.Write("\t3. Dexterity: ");
                int dexterity = 0;
                while (dexterity <= 0)
                {
                    //Console.Write("\t3. dexterity (must be > 0): ");
                    dexterity = Convert.ToInt32(Console.ReadLine());
                    if (dexterity <= 0)
                    {
                        Console.WriteLine("dexterity cannot be zero or negative. Please enter a valid value.");
                    }
                }
                if (allocatedPoints + dexterity > initialPoints)
                {
                    Console.WriteLine("You don't have enough points for dexterity . Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Dexterity = dexterity;
                    allocatedPoints += dexterity;
                }

                Console.Write("\t4. Constitution: ");
                int constitution = 0;
                while (constitution <= 0)
                {
                    //Console.Write("\t4. constitution (must be > 0): ");
                    constitution = Convert.ToInt32(Console.ReadLine());
                    if (constitution <= 0)
                    {
                        Console.WriteLine("constitution cannot be zero or negative. Please enter a valid value.");
                    }
                }
                if (allocatedPoints + constitution > initialPoints) {
                    Console.WriteLine("You don't have enough points for constitution.  Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Constitution = constitution;
                    allocatedPoints += constitution;
                }

                if (allocatedPoints == initialPoints)
                {
                    Console.WriteLine("\n Character creation complete!");
                }
            }

            newCharacter.Mana += 10 * newCharacter.Intelligence;
            newCharacter.MaxMana += 10 * newCharacter.Intelligence;
            newCharacter.HeathPoints += 10 * newCharacter.Constitution;
            newCharacter.MaxHeathPoints += 10 * newCharacter.Constitution;

            Console.WriteLine(" Confirm your creation ? ");
            Console.WriteLine("\t1. Yes");
            Console.WriteLine("\t2. No (Go back to the beginning)\n");
            Console.WriteLine("\n =================================================\n");

            Console.Write(" Select your  Choice: ");
            int confirmChoice = int.Parse(Console.ReadLine());
            if (confirmChoice == 1)
            {
                Thread.Sleep(300);
                Console.WriteLine(" Your character has been successfully created");
                Console.WriteLine(" Press Any Key to start your adventure....");
                Console.ReadKey();

                GameMenus gameMenu = new GameMenus();
                gameMenu.GameMenuPage(newCharacter);
            }
            else
            {
                Console.WriteLine(" Restarting character creation...");
                Thread.Sleep(100);
                NavigationPage.NavigateToMainPage();
            }
        }

        public void AddPoints(ICharacter newCharacter, int initialPoints, int allocatedPoints = 0)
        {
            while (allocatedPoints < initialPoints)
            {
                if(allocatedPoints == initialPoints) { break; }
                Console.Write("\t1. Strength : ");
                int strength = 0;
                strength = Convert.ToInt32(Console.ReadLine());

                if (allocatedPoints + strength > initialPoints)
                {
                    Console.WriteLine("You don't have enough points. Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Strength += strength;
                    allocatedPoints += strength;
                }

                if (allocatedPoints == initialPoints) { break; }
                Console.Write("\t2. Intelligence: ");
                int intelligence = 0;
                intelligence = Convert.ToInt32(Console.ReadLine());

                if (allocatedPoints + intelligence > initialPoints)
                {
                    Console.WriteLine("You don't have enough points. Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Intelligence += intelligence;
                    allocatedPoints += intelligence;
                }

                if (allocatedPoints == initialPoints) { break; }
                Console.Write("\t3. Dexterity: ");
                int dexterity = 0;
                dexterity = Convert.ToInt32(Console.ReadLine());

                if (allocatedPoints + dexterity > initialPoints)
                {
                    Console.WriteLine("You don't have enough points for dexterity . Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Dexterity += dexterity;
                    allocatedPoints += dexterity;
                }

                if (allocatedPoints == initialPoints) { break; }
                Console.Write("\t4. Constitution: ");
                int constitution = 0;
                constitution = Convert.ToInt32(Console.ReadLine());

                if (allocatedPoints + constitution > initialPoints)
                {
                    Console.WriteLine("You don't have enough points for constitution.  Please try again.");
                    continue;
                }
                else
                {
                    newCharacter.Constitution += constitution;
                    allocatedPoints += constitution;
                }

                newCharacter.Mana += 10 * newCharacter.Intelligence;
                newCharacter.MaxMana += 10 * newCharacter.Intelligence;
                newCharacter.HeathPoints += 10 * newCharacter.Constitution;
                newCharacter.MaxHeathPoints += 10 * newCharacter.Constitution;
            }

            initialPoints = initialPoints - allocatedPoints;
        }
    }
}
