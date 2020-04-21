using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;
        

        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
        }

        private void CustomerGenerator()
        {
            if (weather.condition == "Sunny" || weather.temperature >= 80)
            {
                for (int i = 0; i <= 30; i++)
                {
                    Customer customer = new Customer();
                    customers.Add(customer);
                }
            }
            else if (weather.condition == "Rainy" || weather.temperature <= 60)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Customer customer = new Customer();
                    customers.Add(customer);
                }
            }
            else
            {
                for(int i = 0; i <= 20; i++)
                {
                    Customer customer = new Customer();
                    customers.Add(customer);
                }
            }    
        }
    }
}
