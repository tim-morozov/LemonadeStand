using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        private Player player;
        private List<Day> days;
        private int currentDay;
        private Store store;
        

        public Game()
        {
            player = new Player();
            store = new Store();

        }

        private void GoToStore()
        {
            UserInterface.GetNumberOfItems("lemons");
            store.SellLemons(player);
            UserInterface.GetNumberOfItems("sugar");
            store.SellSugarCubes(player);
            UserInterface.GetNumberOfItems("ice cubes");
            store.SellIceCubes(player);
            UserInterface.GetNumberOfItems("Cups");
            store.SellIceCubes(player);
        }

        private void InventoryValidate()
        {
            if(player.inventory.lemons.Count <= 0)
            {
                GoToStore();
            }
            else if(player.inventory.sugarCubes.Count <= 0)
            {
                GoToStore();
            }
            else if(player.inventory.iceCubes.Count <= 0)
            {
                GoToStore();
            }
            else if(player.inventory.cups.Count <= 0)
            {
                GoToStore();
            }
        }

        public void RunGame()
        {
            Console.WriteLine("Welcome to Lemonade stand!");
            player.DisplayInventory();
            InventoryValidate();
            player.ChooseRecipe();
        }

    }
}
