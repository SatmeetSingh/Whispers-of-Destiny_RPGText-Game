using RpgTextGame.Models;
using RpgTextGame.Utilities;
using RpgTextGame.views.GameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Inn
{
     class RestAtInn
    {
        public void InnPage(ICharacter character)
        {
            Console.Clear();
            Console.WriteLine("\n =================================================");
            Console.WriteLine("                    Enter the Inn                 ");
            Console.WriteLine(" =================================================");
            Console.WriteLine("\n You step into the Inn, greeted by the soothing aroma of freshly baked bread and the warm chatter of fellow adventurers. The Innkeeper, a friendly woman with a welcoming smile, beckons you to the bar.\n");

            Console.WriteLine("\t1. Check-In Room");
            Console.WriteLine("\t2. Order a Meal");
            Console.WriteLine("\t3. Listen to Gossip");
            Console.WriteLine("\t4. Leave the inn\n");

            Console.Write(" Please select your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Check-in room");
                    RoomCheckIn room = new RoomCheckIn();
                    room.Room(character);
                    break;
                case "2":
                    Console.WriteLine("Order the meal");
                    MealPage mealPage = new MealPage();
                    mealPage.OrderMeal(character);
                    break;
                case "3":
                    Console.WriteLine("Listen to gossip");
                    break;
                case "4":
                    Console.WriteLine("Leave the inn");
                    NavigationPage.NavigateFromGameMenuPage(character);
                    break;
                default:
                    Console.WriteLine("Invalid Choice, please Press Any Key to choose again");
                    Console.ReadKey();
                    NavigationPage.NavigateToInnPage(character);
                    break;
            }
        }
    }
}
