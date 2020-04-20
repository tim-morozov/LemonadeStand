using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Adult : Customer
    {
        public override bool WillBuy(int temp, double price)
        {
            if (temp >= 70 || price <= .5)
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
