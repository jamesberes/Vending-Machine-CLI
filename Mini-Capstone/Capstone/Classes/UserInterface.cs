using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();
        private SalesReport salesReport = new SalesReport();

        //private GetChange change = new GetChange();
        public void RunInterface()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("-------- Main Menu --------");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) End");
                Console.WriteLine();
                Console.Write("Your choice: ");

                int choice = 0;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        DisplayVendingMachineItems();
                        break;

                    case 2:
                        PurchaseMenu();
                        break;

                    case 3:
                        done = true;
                        break;

                    case 9:
                        WriteSalesReport();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayVendingMachineItems()
        {
            Console.WriteLine();
            Console.Write("Slot".PadRight(7));
            Console.Write("Description".PadRight(25));
            Console.Write("Cost".PadRight(7));
            Console.WriteLine("Quantity Remaining".PadRight(20));
            Console.WriteLine("=======================================================");

            foreach (VendingMachineItem item in vendingMachine.ToArray())
            {
               //shows A1 (spaces) candy bar (spaces) $1.00
                Console.Write(item.Slot.ToUpper().PadRight(7));
                Console.Write(item.Name.PadRight(25));
                Console.Write(item.Cost.ToString("C").PadRight(15));
                if (item.Quantity < 1)
                {
                    Console.WriteLine("SOLD OUT".PadRight(17));
                }
                else
                {
                    Console.WriteLine(item.Quantity.ToString().PadRight(20));
                }
            }
        }

        private void PurchaseMenu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("------ Purchase Menu ------");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"Your Current Balance: {vendingMachine.CurrentBalance.ToString("C")}");
                Console.WriteLine();
                Console.Write("Your choice: ");

                int choice = 0;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        //Feeding Money
                        //Assumption: Can I enter ANY Whole dollar amount? It's coming from a bank, but may want to represent actual currency denominations. 
                        Console.WriteLine("How much would you like to add? $1, $2, $5, $10.");
                        Console.Write("Please enter whole dollar amounts - (1), (2), (5), (10): ");
                        int moneyToAdd = 0;
                        try
                        {
                            moneyToAdd = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Error: Could not handle user input. Please enter a whole dollar value. ");
                        }
                        vendingMachine.FeedMoney(moneyToAdd);
                        break;

                    case 2:
                        //Selecting Product
                        DisplayVendingMachineItems();
                        string message = "";
                        string slotSpace = "";
                        Console.Write("\nEnter the slot location of the item you wish to purchase: ");
                        slotSpace = Console.ReadLine();
                        slotSpace = slotSpace.ToLower();
                        vendingMachine.Transaction(slotSpace, ref message);
                        Console.WriteLine("\n" + message);
                        break;

                    case 3:
                        //Finish Transaction
                        Console.WriteLine("Transaction(s) Finished");
                        Console.WriteLine($"Change back: {vendingMachine.CurrentBalance}");
                        Console.WriteLine(vendingMachine.DisplayChange()); //give change & reset balance
                        done = true;
                        break;

                    default:
                        Console.Write("Invalid choice. Please try again! \n");
                        break;
                }
            }
        }
        public void WriteSalesReport()
        {
            salesReport.SalesReportWriter(vendingMachine.ToArray());
            Console.WriteLine("Sales Report Created");
        }


    }
}
