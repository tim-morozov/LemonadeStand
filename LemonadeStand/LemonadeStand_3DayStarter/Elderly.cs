using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Elderly : Customer
    {
        public override bool WillBuy(int temp, double price)
        {
            if (temp >= 60 || price <= 1.25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
