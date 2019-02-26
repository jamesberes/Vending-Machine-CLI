using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineItemTests
    {

        [TestMethod]
        public void ConstructorTests()
        {
            // Test for incorrect Slot (case sensitive)
            VendingMachineItem testItem = new VendingMachineItem("A1", "TestItemName", 1.85D);
            Assert.AreEqual("a1", testItem.Slot);
            Assert.AreEqual("TestItemName", testItem.Name);
            Assert.AreEqual(1.85D, testItem.Cost);

            // Proper lower case slot but long name.
            VendingMachineItem testItem2 = new VendingMachineItem("c10", "THIS IS A REALLY LONG NAME FOR A VENDING MACHINE ITEM", 10.50D);
            Assert.AreEqual("c10", testItem2.Slot);
            Assert.AreEqual("THIS IS A REALLY LONG NAME FOR A VENDING MACHINE ITEM", testItem2.Name);
            Assert.AreEqual(10.50D, testItem2.Cost);

            // Item cannot be negatively costed, default to costing 1D
            VendingMachineItem testItem3 = new VendingMachineItem("b12", "This is a Test Item", -1.00D);
            Assert.AreEqual(1.00D, testItem3.Cost);
        }
        [TestMethod]
        public void ConsumeTest()
        {
            //Regular test 1
            VendingMachineItem testItem = new VendingMachineItem("a1", "TestItemName", 1.85D);
            string message = testItem.Consume();
            Assert.AreEqual("Crunch Crunch, Yum!", message);
            VendingMachineItem testItem2 = new VendingMachineItem("d10", "TestItem2", 2.00D);

            //Regular test 2
            message = testItem2.Consume();
            Assert.AreEqual("Chew Chew, Yum!", message);

            // Test outside of known slots. Though this should only be calld if it is a valid product in a 
            // Vending machine
            VendingMachineItem testItem3 = new VendingMachineItem("z12", "No slot", 1000.00D);
            message = testItem3.Consume();
            Assert.AreEqual("Yum Yum!", message);
        }
        [TestMethod]
        public void WasPurchasedAllClearTest()
        {
            VendingMachineItem testItem = new VendingMachineItem("a1", "TestItemName", 1.85D);
            testItem.WasPurchased();
            Assert.AreEqual(4, testItem.Quantity);
        }
        [TestMethod]
        public void WasPurchasedBelowOneTest()
        {
            VendingMachineItem testItem = new VendingMachineItem("a1", "TestItemName", 1.85D);
            // Empty the stock of item
            while (testItem.Quantity >1)
            {
                testItem.WasPurchased();
            }
            // Attempt to purchase with no inventory
            testItem.WasPurchased();
            Assert.AreEqual(0, testItem.Quantity);
        }
    }
}
