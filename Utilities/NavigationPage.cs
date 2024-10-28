using RpgTextGame.Models;
using RpgTextGame.src.GameMenu.Inn;
using RpgTextGame.src.GameMenu.Map.Outskirts;
using RpgTextGame.src.GameMenu.Town;
using RpgTextGame.views.GameMenu;
using RpgTextGame.views.GameMenu.Map;
using RpgTextGame.views.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    internal class NavigationPage
    {
        public static void NavigateToMainPage()
        {
            MainMenuPage menupage = new MainMenuPage();
            menupage.MainPage();
        }

        public static void NavigateFromGameMenuPage(ICharacter character) {
            GameMenus gameMenu = new GameMenus();
            gameMenu.GameMenuPage(character);
        }

        public static void NavigationToMapExplorationPage(ICharacter character) {
            MapExploration explore  = new MapExploration();
            explore.ExploreWorld(character);
        }

        public static void NavigateToInnPage(ICharacter character)
        {
            RestAtInn inn = new RestAtInn();
            inn.InnPage(character);
        }

        public static void navigateToTownPage(ICharacter character) {
            TownPage town = new TownPage();
            town.ExploreTown(character);
        }

        public static void NavigateToVillageOutskirt(ICharacter character)
        {
            VillageOutskirts outskirts = new VillageOutskirts();
            outskirts.Outskirt(character);
        }


        public static void InsuffecientMoneyForFood(ICharacter character ,Currency cost) {
            if (character.Money.TotalMoney() < (cost.Gold * 10000 + cost.Silver * 100 + cost.Bronze))
            {
                Console.WriteLine(" Money is not Enough");
                Thread.Sleep(100);
                Console.WriteLine(" Press any key to go back to main menu");
                Console.ReadKey();
                NavigateToInnPage(character);
            }
        }
    }
}
