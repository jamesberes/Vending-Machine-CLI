using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class GetChange
    {
        public Dictionary<int, int> ChangeDictionary { get; } = new Dictionary<int, int>
            {
             //Cents, QuantityofCoins
                {25, 0 },
                {10, 0 },
                {5, 0 }
            };
        private double totalBalance = 0;
        public bool ChangeMaker(double balance)
        {
            bool successful = false;
            totalBalance = balance;
            //Check to see if the balance in cents is below what can be calculated
            if (balance < (int.MaxValue / 100))
            {
                int balanceInCents = (int)(balance * 100);
                List<int> coins = new List<int>(ChangeDictionary.Keys);
                //Assumption: User will not enter enough money (~$25,000,000) to need a different data type. (overflow int)
                foreach (int coin in coins)
                {
                    while (balanceInCents >= coin)
                    {
                        ChangeDictionary[coin]++;
                        balanceInCents -= coin;
                    }
                }
                successful = true;
            }
            
            return successful;

        }
        public override string ToString()
        {
            return $"\nYour current balance: {totalBalance.ToString("C2")}\n\n**** You will Receive****\n{ChangeDictionary[25]} Quarters\n{ChangeDictionary[10]} Dimes\n" +
                $"{ChangeDictionary[5]} Nickels";
        }
    }
}
