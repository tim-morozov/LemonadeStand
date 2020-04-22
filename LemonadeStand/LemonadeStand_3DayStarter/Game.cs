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
            foreach (Elderly elderlyCustomer in days[currentDay].customers[0])
            {
                bool sale = elderlyCustomer.WillBuy(days[currentDay].weather.temperature, player.recipe.pricePerCup);
                if (sale == true)
                {
                    player.wallet.Money += player.recipe.pricePerCup;
                }
                else
                {
                    player.wallet.Money = player.wallet.Money;
                }
            }
        }

        private void AdSell()
        {
            foreach (Adult adultCustomer in days[currentDay].customers[1])
            {
                bool sale = adultCustomer.WillBuy(days[currentDay].weather.temperature, player.recipe.pricePerCup);
                if (sale == true)
                {
                    player.wallet.Money += player.recipe.pricePerCup;
                }
                else
                {
                    player.wallet.Money = player.wallet.Money;
                }
            }
        }

        private void KidSell()
        {
            foreach (Child childCustomer in days[currentDay].customers[2])
            {
                bool sale = childCustomer.WillBuy(days[currentDay].weather.temperature, player.recipe.pricePerCup);
                if (sale == true)
                {
                    player.wallet.Money += player.recipe.pricePerCup;
                }
                else
                {
                    player.wallet.Money = player.wallet.Money;
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
            EldSell();
            AdSell();
            KidSell();
            
           
        }
        public void RunGame()
        {
            Console.WriteLine("Welcome to Lemonade stand!");
            RunDay();    
        }

    }
}
