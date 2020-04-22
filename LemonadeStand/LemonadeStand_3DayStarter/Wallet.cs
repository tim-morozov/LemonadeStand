using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Wallet
    {
        private double money;
        public double profit;
        public double loss;
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        public Wallet()
        {
            money = 20.00;
            profit = 0;
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }
    }
}
