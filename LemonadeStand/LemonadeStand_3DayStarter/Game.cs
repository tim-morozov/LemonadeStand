using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        

        public Game()
        {
            player = new Player();
            store = new Store();
            gameLength = 7;
            currentDay = 0;
            days = new List<Day>();
            DayGen();
        }
        private void DisplayScore(double finalMoney)
        {
            double totalProfit = finalMoney - 20;
            Console.WriteLine(totalProfit);
        }
        private void CheckPitcher()
        {
            if (player.pitcher.cupsLeftInPitcher <= 0)
            {
                player.RefillPitcher();
            }
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
                    bool input = player.CheckInventory();
                    if(input == true)
                    {
                        player.Sale();
                    }
                    else
                    {
                        break;
                    }
                    CheckPitcher();
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
                    bool input = player.CheckInventory();
                    if (input == true)
                    {
                        player.Sale();
                    }
                    else
                    {
                        break;
                    }
                    CheckPitcher();
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
                    bool input = player.CheckInventory();
                    if (input == true)
                    {
                        player.Sale();
                    }
                    else
                    {
                        break;
                    }
                    CheckPitcher();
                }
            }

        }
        private void DayGen()
        {
            Day day = new Day();
            days.Add(day);
            player.wallet.profit = 0;
            
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
                bool input = player.CheckInventory();
                if (input == true)
                {
                    AdSell();
                }
                else
                {
                    break;
                }
                KidSell();
                
            }
            player.wallet.Money += player.wallet.profit;
            Console.WriteLine("You made $" + player.wallet.profit + " today!");
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
            DisplayScore(player.wallet.Money);
        }

    }
}
