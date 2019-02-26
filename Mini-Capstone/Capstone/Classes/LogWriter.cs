using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    class LogWriter
    {
        private string filePath = @"C:\VendingMachine";
        private string fileName = "Log.txt";
        
        //Assumption: current setup only appends files (after the first one is created). Might want to change this.
        // --> requires user maintenance
        //TODO: Consider refactoring to one method
        public bool FeedMoneyLogFile(int moneyAdded, double balance)
        {
            bool result = false;
            string path = Path.Combine(filePath, fileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    string line = $"{DateTime.Now.ToString()} FEED MONEY: {moneyAdded.ToString("C").PadLeft(7)} {balance.ToString("C").PadLeft(10)}";
                    writer.WriteLine(line);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool TransactionSuccessLogFile(VendingMachineItem item, double balance)
        {
            bool result = false;
            string path = Path.Combine(filePath, fileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    string line = $"{DateTime.Now.ToString()} {item.Name} {item.Slot.ToUpper()}: {balance.ToString("C").PadLeft(7)}     {(balance-item.Cost).ToString("C")}";
                    writer.WriteLine(line);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool GiveChangeLogFile(double balance)
        {
            bool result = false;
            string path = Path.Combine(filePath, fileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    string line = $"{DateTime.Now.ToString()} GIVE CHANGE: {balance.ToString("C").PadLeft(4)}     $0.00";
                    writer.WriteLine(line);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
