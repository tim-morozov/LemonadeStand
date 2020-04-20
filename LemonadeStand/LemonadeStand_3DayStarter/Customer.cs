using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        public string customerName;
        private List<string> names;

        public Customer()
        {
            names = new List<string>() { "Bill", "Jane", "Todd", "Jack", "Jenny", "Suzy" };
            customerName = CustomerGenerator();
        }
        public int RandomGenerator(int min, int max)
        {
            Random random = new Random();
            int newRandom = random.Next(min, max);
            return newRandom;
        }

        private string CustomerGenerator()
        {
            int i = RandomGenerator(0, (names.Count() - 1));
            string customer = names[i];
            return customer;
        }
    }
}
