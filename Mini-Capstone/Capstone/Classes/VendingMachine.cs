using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private LogWriter logWriter = new LogWriter();
        //TODO: Consider just adding a public read only property for inventory and making ToArray mostly redundant
        private List<VendingMachineItem> inventory = new List<VendingMachineItem>();
        private string filePath = @"C:\VendingMachine";
        private string fileName = "vendingmachine.csv";
        public double CurrentBalance { get; set; }

        public VendingMachine()
        {
            ReadFile();
            CurrentBalance = 0;
        }

        public bool ReadFile()
        {
            bool result = false;
            string path = Path.Combine(filePath, fileName);
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    inventory.Clear();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] itemProperties = line.Split('|');
                        double itemCost = 0D;
                        double.TryParse(itemProperties[2], out itemCost);
                        VendingMachineItem item = new VendingMachineItem(itemProperties[0],
                            itemProperties[1], itemCost);
                        inventory.Add(item);
                        //TODO: Handle incorrect files
                    }
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        // Adds to the current balance based on the Whole Dollar Value fed into the machine
        public void FeedMoney(int moneyAdded)
        {
            if (moneyAdded < 1)
            {
                moneyAdded = 0;
            }
            CurrentBalance += (double)moneyAdded;
            logWriter.FeedMoneyLogFile(moneyAdded, CurrentBalance);
        }

        /// <summary>
        /// Takes a slot in inventory and "Purchases" the item. Checking if it is too expensive
        /// and removing the item cost from balance and updating item quantity
        /// </summary>
        /// <returns>true if transaction suceeds</returns>
        public bool Transaction(string slot, ref string message)
        {
            bool successful = false;
            VendingMachineItem purchasedItem = GetItem(slot);
            // Could not find item
            if (purchasedItem == null)
            {
                successful = false;
                message = $"Sorry. We could not find an item with slot {slot}. Please try again.";
            }
            else if (purchasedItem.Cost > CurrentBalance)
            {
                message = "Not enough money in your Current Balance. Please feed more money " +
                    "to purchase this item.";
                successful = false;
            }
            else if (purchasedItem.Quantity <= 0)
            {
                message = $"Cannot purchase the item in slot {purchasedItem.Slot}: {purchasedItem.Name} is SOLD OUT." +
                    "\nPlease purchase another item.";
                successful = false;
            }
            else
            {
                // Transaction Succeeds (Quantity has 1 or more (more than enough balance)
                logWriter.TransactionSuccessLogFile(purchasedItem, CurrentBalance);
                CurrentBalance -= purchasedItem.Cost;
                purchasedItem.WasPurchased();
                message = purchasedItem.Consume();
                successful = true;
            }
            return successful;
        }
        private VendingMachineItem GetItem(string slot)
        {
            foreach (VendingMachineItem item in inventory)
            {
                if (slot == item.Slot)
                {
                    return item;
                }
            }
            return null;
        }
        public string DisplayChange()
        {
            GetChange change = new GetChange();
            logWriter.GiveChangeLogFile(CurrentBalance);
            if (change.ChangeMaker(CurrentBalance))
            {
                CurrentBalance = 0.00D;
                return change.ToString();
            }
            else
            {
                return "\nWe're are sorry. We currently cannot produce change for you. " +
                    "Please contact your local Vending Machine Admin.\n";
            }
        }
        public VendingMachineItem[] ToArray() { return inventory.ToArray(); }
    }
}
