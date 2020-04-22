using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public string name;
        public Recipe recipe;
        public Pitcher pitcher;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            pitcher = new Pitcher();
            name = AddName();
            
        }

        // member methods (CAN DO)
        //Gives the player a name based off of user input
        private string AddName()
        {
            Console.WriteLine("Please write your name");
            string input = Console.ReadLine();
            return input;
        }

        public void ChooseRecipe()
        {
            Console.WriteLine("Please choose your recipe");
            Console.WriteLine("How many lemons?");
            recipe.amountOfLemons = Convert.ToInt32(Console.ReadLine());
            InventoryRemove(inventory.lemons, recipe.amountOfLemons);
            Console.WriteLine("How much sugar?");
            recipe.amountOfSugarCubes = Convert.ToInt32(Console.ReadLine());
            InventoryRemove(inventory.sugarCubes, recipe.amountOfSugarCubes);
            Console.WriteLine("How much ice?");
            recipe.amountOfIceCubes = Convert.ToInt32(Console.ReadLine());
            InventoryRemove(inventory.iceCubes, recipe.amountOfIceCubes);
            Console.WriteLine("Please set a price");
            recipe.pricePerCup = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayInventory()
        {
            Console.WriteLine("You currently have:");
            Console.WriteLine("Lemons: " + inventory.lemons.Count);
            Console.WriteLine("Sugar: " + inventory.sugarCubes.Count);
            Console.WriteLine("Ice Cubes: " + inventory.iceCubes.Count);
            Console.WriteLine("Cups: " + inventory.cups.Count);
            Console.WriteLine("You have $" + wallet.Money);
        }

        public void RefillPitcher()
        {
            pitcher.cupsLeftInPitcher = 6;
        }

        public void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("Your current recipe is: ");
            Console.WriteLine("Lemons: " + recipe.amountOfLemons);
            Console.WriteLine("Sugar: " + recipe.amountOfSugarCubes);
            Console.WriteLine("Ice Cubes: " + recipe.amountOfIceCubes);
            Console.WriteLine("Selling at: " + recipe.pricePerCup + " per cup");
        }
        private void InventoryRemove(List<Item> item, int quant)
        {
            for(int i = 0; i <= quant; i++)
            {
                item.RemoveAt(0);
            }
        }
        public void Sale()
        {
            InventoryRemove(inventory.lemons, recipe.amountOfLemons);
            InventoryRemove(inventory.sugarCubes, recipe.amountOfSugarCubes);
            InventoryRemove(inventory.iceCubes, recipe.amountOfIceCubes);
            inventory.cups.RemoveAt(0);
        }
    }
}
