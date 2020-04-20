using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        public string condition;
        public int temperature;
        private List<string> weatherConditions;

        public Weather()
        {
            weatherConditions = new List<string>() { "Sunny", "Rainy", "Cloudy", "Windy" };
            temperature = RandomGenerator(45, 99);
            condition = ConditionGenerator();
        }

        private string ConditionGenerator()
        {
            int i = RandomGenerator(0, (weatherConditions.Count() - 1));
            return weatherConditions[i];
        }

        public int RandomGenerator(int min, int max)
        {
            Random random = new Random();
            int newRandom = random.Next(min, max);
            return newRandom;
        }
    }
}
