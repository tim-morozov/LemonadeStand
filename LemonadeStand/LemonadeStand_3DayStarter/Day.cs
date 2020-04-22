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
        //public List<List<Customer>> customers;
        public List<Customer> eldCustomers;
        public List<Customer> adCustomers;
        public List<Customer> chCustomers;
        

        public Day()
        {
            weather = new Weather();
            //customers = new List<List<Customer>>();
            eldCustomers = new List<Customer>();
            adCustomers = new List<Customer>();
            chCustomers = new List<Customer>();
            CustomerGenerator();
        }

        public void DisplayWeather()
        {
            Console.WriteLine("The weather is " + weather.condition + " and the temperature is " + weather.temperature);
        }
        public void CustomerGenerator()
        {
            if (weather.condition == "Sunny" || weather.temperature >= 80)
            {
                for (int i = 0; i <= 30; i++)
                {
                    Customer elderlyCustomer = new Elderly();
                    Customer adultCustomer = new Adult();
                    Customer childCustomer = new Child();
                    eldCustomers.Add(elderlyCustomer);
                    adCustomers.Add(adultCustomer);
                    chCustomers.Add(childCustomer);
                }
            }
            else if (weather.condition == "Rainy" || weather.temperature <= 60)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Customer elderlyCustomer = new Elderly();
                    Customer adultCustomer = new Adult();
                    Customer childCustomer = new Child();
                    eldCustomers.Add(elderlyCustomer);
                    adCustomers.Add(adultCustomer);
                    chCustomers.Add(childCustomer);
                }
            }
            else
            {
                for(int i = 0; i <= 20; i++)
                {
                    Customer elderlyCustomer = new Elderly();
                    Customer adultCustomer = new Adult();
                    Customer childCustomer = new Child();
                    eldCustomers.Add(elderlyCustomer);
                    adCustomers.Add(adultCustomer);
                    chCustomers.Add(childCustomer);
                }
            }
            //customers.Add(eldCustomers);
            //customers.Add(adCustomers);
            //customers.Add(chCustomers);
        }
    }
}
