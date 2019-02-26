using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine test;

        [TestInitialize]
        public void Initialize()
        {
            test = new VendingMachine();
        }

        [TestMethod]
        public void FeedMoneyTest()
        {
            //act
            test.CurrentBalance = 0;
            test.FeedMoney(1);

            //assert
            Assert.AreEqual(1, test.CurrentBalance);
            
        }

        [TestMethod]
        public void FeedMoneyTest_Negative_input()
        {
            //act
            test.CurrentBalance = 0;
            test.FeedMoney(-1);

            //assert
            Assert.AreEqual(0, test.CurrentBalance);
        }

        [TestMethod]
        public void TransactionTestFailure_Cannot_Find_Item()
        {
            //act
            //VendingMachineItem item = null;
            string testString = "";
            string purchasedItemSlot = "p4";
            bool result = test.Transaction(purchasedItemSlot, ref testString);

            //assert
            Assert.AreEqual(false, result);
            //Assert.AreEqual($"Sorry. We could not find an item with slot {purchasedItemSlot}. Please try again.", testString);
        
        }

        [TestMethod]
        public void TransactionTestFailure_Balance_Too_Low()
        {
            //act
            //VendingMachineItem item = null;
            string testString = "";
            string purchasedItemSlot = "a1";
            test.CurrentBalance = 0;
            bool result = test.Transaction(purchasedItemSlot, ref testString);

            //assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("Not enough money in your Current Balance. Please feed more money " +
                    "to purchase this item.", testString);

        }

        [TestMethod]
        public void TransactionTestFailure_Quantity_Too_Low()
        {
            //act
            //VendingMachineItem item = null;
            string testString = "";
            string purchasedItemSlot = "a1";
            string purchasedItemName = "Potato Crisps";
            test.CurrentBalance = 100;
            test.Transaction(purchasedItemSlot, ref testString);
            test.Transaction(purchasedItemSlot, ref testString);
            test.Transaction(purchasedItemSlot, ref testString);
            test.Transaction(purchasedItemSlot, ref testString);
            test.Transaction(purchasedItemSlot, ref testString);
            bool result = test.Transaction(purchasedItemSlot, ref testString); //6th time should return SOLD OUT
            

            //assert
            Assert.AreEqual(false, result);
            Assert.AreEqual($"Cannot purchase the item in slot { purchasedItemSlot}: { purchasedItemName} is SOLD OUT." +
                    "\nPlease purchase another item.", testString);

        }

        [TestMethod]
        public void TransactionTestSuccess()
        {
            string testString = "";
            string purchasedItemSlot = "a1";
            test.CurrentBalance = 10;          
            bool result = test.Transaction(purchasedItemSlot, ref testString);
            Assert.AreEqual(true, result);
            Assert.AreEqual("Crunch Crunch, Yum!", testString);
            //TODO: Check for every type of Vendable item in inventory
            // Munch Munch
            purchasedItemSlot = "b1";
            result = test.Transaction(purchasedItemSlot, ref testString);
            Assert.AreEqual(true, result);
            Assert.AreEqual("Munch Munch, Yum!", testString);

            purchasedItemSlot = "c1";
            result = test.Transaction(purchasedItemSlot, ref testString);
            Assert.AreEqual(true, result);
            Assert.AreEqual("Glug Glug, Yum!", testString);

            purchasedItemSlot = "d1";
            result = test.Transaction(purchasedItemSlot, ref testString);
            Assert.AreEqual(true, result);
            Assert.AreEqual("Chew Chew, Yum!", testString);

        }
        [TestMethod]
        public void DisplayChangeTestFailure()
        {
            test.CurrentBalance = 20000000000000000000000000000000000D;
            string expectedResult = "\nWe're are sorry. We currently cannot produce change for you. " +
                    "Please contact your local Vending Machine Admin.\n";
            Assert.AreEqual(expectedResult, test.DisplayChange());
        }
        [TestMethod]
        public void DisplayChangeSuccess()
        {
            test.CurrentBalance = 5D;
            string expectedResult = "\nYour current balance: $5.00\n\n**** You will Receive****\n20 Quarters\n0 Dimes\n" +
                $"0 Nickels";
            Assert.AreEqual(expectedResult, test.DisplayChange());

        }
    }
}
