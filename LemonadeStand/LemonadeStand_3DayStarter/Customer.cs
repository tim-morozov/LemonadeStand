using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
   abstract class Customer
    {
        public Customer()
        {
            
        }
        public abstract bool WillBuy(int temp, double price);
    }
}
