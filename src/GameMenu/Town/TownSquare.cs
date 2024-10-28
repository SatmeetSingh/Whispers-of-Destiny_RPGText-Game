using RpgTextGame.Models;
using RpgTextGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Town
{
    internal class TownSquarePage
    {
        public void TownSquare(ICharacter character)
        {
            Console.Clear();
            Console.WriteLine(" The Town Square is bustling with activity!");
            Console.WriteLine(" ------------------------------------------------");
            Console.WriteLine("You see a street performer,a notice board and a group of children playing.");
            Console.WriteLine(" ------------------------------------------------");

            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("\t1.Watch the performer");
            Console.WriteLine("\t2.Check the notice board");
            Console.WriteLine("\t3.Join the children to play ");
            Console.WriteLine("\t4.Return to Town ");
            Console.WriteLine(" ------------------------------------------------\n");

            Console.Write("Chose the option(1-4): ");
            string option =Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("");
                    break;
                case "2":
                    Console.WriteLine("");
                    break;
                case "3":
                    Console.WriteLine("");
                    break;
                case "4":
                    Console.WriteLine("Return to Town");
                    NavigationPage.navigateToTownPage(character);
                    break;
                default:
                    Console.WriteLine("Invalid Option,Press ny key to chose option again");
                    Console.ReadKey();
                    TownSquare(character);
                    break;
            }

        }
    }
}
