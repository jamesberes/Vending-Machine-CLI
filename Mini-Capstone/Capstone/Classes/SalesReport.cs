using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    class SalesReport
    {
        private string filePath = @"C:\VendingMachine";
        private string fileName = $"{DateTime.Now:yyyy-MM-dd_hh-mm-ss-fff}-SALES-REPORT.txt";

        public bool SalesReportWriter(VendingMachineItem[] inventory)
        {
            bool result = false;
            double totalSales = 0;
            string path = Path.Combine(filePath, fileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    foreach (var item in inventory)
                    {
                        int soldQuantity = (5 - item.Quantity);
                        if (soldQuantity > 0)
                        {
                            totalSales += (soldQuantity * item.Cost);
                        }
                        string line = $"{item.Name}|{soldQuantity}";
                        writer.WriteLine(line);
                        result = true;
                    }

                    writer.WriteLine($"\nTOTAL SALES: {totalSales.ToString("C")}");
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
