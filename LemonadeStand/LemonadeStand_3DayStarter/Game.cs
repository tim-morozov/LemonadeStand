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
        private int gameLength;
        //Day day = new Day();
        

        public Game()
        {
            player = new Player();
            store = new Store();
            gameLength = 7;
            currentDay = 0;
            days = new List<Day>();
            //days.Add(day);
            DayGen();
        }

        private void GoToStore()
        {
            store.SellLemons(player);
            store.SellSugarCubes(player);
            store.SellIceCubes(player);
            store.SellCups(player);
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
            else
            {
                Console.WriteLine("Would you like to go to the store? Y or N");
                string input = Console.ReadLine();
                input.ToLower();
                if(input == "y")
                {
                    GoToStore();
                }
            }
        }
        private void EldSell()
        {
            foreach (Elderly elderlyCustomer in days[currentDay].eldCustomers)
            {
                bool sale = elderlyCustomer.WillBuy(days[currentDay].weather.temperature, player.recipe.pricePerCup);
                if (sale == true)
                {
                    player.Sale();
                    if(player.pitcher.cupsLeftInPitcher <= 0)
                    {
                        player.RefillPitcher();
                    }
                }
                else
                {
                    player.wallet.profit = player.wallet.profit;
                }
            }
        }

        private void AdSell()
        {
            foreach (Adult adultCustomer in days[currentDay].adCustomers)
            {
                bool sale = adultCustomer.WillBuy(days[currentDay].weather.temperature, player.recipe.pricePerCup);
                if (sale == true)
                {
                    player.Sale();
                    if (player.pitcher.cupsLeftInPitcher <= 0)
                    {
                        player.RefillPitcher();
                    }
                }
                else
                {
                    player.wallet.profit = player.wallet.profit;
                }
            }
        }

        private void KidSell()
        {
            foreach (Child childCustomer in days[currentDay].chCustomers)
            {
                bool sale = childCustomer.WillBuy(days[currentDay].weather.temperature, player.recipe.pricePerCup);
                if (sale == true)
                {
                    player.Sale();
                    if (player.pitcher.cupsLeftInPitcher <= 0)
                    {
                        player.RefillPitcher();
                    }
                }
                else
                {
                    player.wallet.profit = player.wallet.profit;
                }
            }

        }
        private void DayGen()
        {
            Day day = new Day();
            days.Add(day);
            //currentDay++;
        }

        private void RunDay()
        {
            days[currentDay].DisplayWeather();
            player.DisplayInventory();
            InventoryValidate();
            player.DisplayInventory();
            player.ChooseRecipe();
            while (player.inventory.lemons.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.iceCubes.Count > 0 && player.inventory.cups.Count > 0)
            {
                EldSell();
                if (player.inventory.lemons.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.iceCubes.Count > 0 && player.inventory.cups.Count > 0)
                {
                    Console.WriteLine("Sold Out!");
                    break;
                }
                else
                {
                    AdSell();
                }
                if(player.inventory.lemons.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.iceCubes.Count > 0 && player.inventory.cups.Count > 0)
                {
                    Console.WriteLine("Sold Out");
                    break;
                }
                KidSell();
            }
           
        }
        public void RunGame()
        {
            Console.WriteLine("Welcome to Lemonade stand!");
            while (currentDay < gameLength)
            {
                RunDay();
                DayGen();
                currentDay++;
            }
        }

    }
}
