using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        public string Slot { get; }
        public string Name
        { get; }
        public double Cost { get; }

        private int quantity = 5;
        public int Quantity
        {
            get { return quantity; }
            private set
            {
                quantity = value;
            }
        }

        public VendingMachineItem(string slot, string name, double cost)
        {
            Slot = slot.ToLower();
            Name = name;
            Cost = cost <= 0 ? Cost = 1.00D : Cost = cost;
        }
        public string Consume()
        {
            string consumeMessage = "";
            switch (Slot[0])
            {
                case 'a':
                    consumeMessage = "Crunch Crunch, Yum!";
                    break;
                case 'b':
                    consumeMessage = "Munch Munch, Yum!";
                    break;
                case 'c':
                    consumeMessage = "Glug Glug, Yum!";
                    break;
                case 'd':
                    consumeMessage = "Chew Chew, Yum!";
                    break;
                default:
                    consumeMessage = "Yum Yum!";
                    break;
            }
            return consumeMessage;
        }
        public void WasPurchased()
        {
            if (quantity >= 1)
            {
                quantity--;
            }
        } 
    }
}
