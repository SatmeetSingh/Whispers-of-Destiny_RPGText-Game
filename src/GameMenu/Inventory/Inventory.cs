using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.src.GameMenu.Inventory
{
    internal class InventoryPage
    {
        public void ManageInventory()
        {
            Console.Clear();
            Console.WriteLine("\n =================================================");
            Console.WriteLine("                 Manage Inventory                 ");
            Console.WriteLine(" =================================================");
            Console.WriteLine("Your inventory contains all the items you've gathered on your journey\n");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\t1. view Items");
            Console.WriteLine("\t2. Equip Gear");
            Console.WriteLine("\t3. Use Consumables");
            Console.WriteLine("\t4. Discard Items");
            Console.WriteLine("\t5. Return to Main Menu");
            Console.WriteLine("--------------------------------------------------\n");
            Console.Write("Enter your options(1-5): ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid option, please click any key to try again.");
                    Console.ReadKey();

                    break;

            }
        }
    }
}
