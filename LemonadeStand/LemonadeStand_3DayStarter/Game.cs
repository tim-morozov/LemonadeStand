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
        

        public Game()
        {
            player = new Player();   

        }

        public void RunGame()
        {
            Console.WriteLine("Welcome to Lemonade stand!");
            player.DisplayInventory();
            player.ChooseRecipe();
        }

    }
}
