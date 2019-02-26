using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class GetChangeTests
    {
        GetChange testChange;
        [TestInitialize]
        public void Initialize()
        {
            testChange = new GetChange();
        }
        [TestMethod]
        public void GetChangeEmpty()
        {
            double balance = 0D;
            testChange.ChangeMaker(balance);
            Dictionary<int, int> actualResult = testChange.ChangeDictionary;
            Dictionary<int, int> expectedResult = new Dictionary<int, int>
            {
                {25, 0 },
                {10, 0 },
                {5, 0 }
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetChangeStandard()
        {
            double balance = 5.35D;
            testChange.ChangeMaker(balance);
            Dictionary<int, int> actualResult = testChange.ChangeDictionary;
            Dictionary<int, int> expectedResult = new Dictionary<int, int>
            {
                {25, 21 },
                {10, 1 },
                {5, 0 }
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetChangeLeftovers()
        {
            //Currently, the method does not handle pennies, per the assignment
            double balance = 5.34D;
            testChange.ChangeMaker(balance);
            Dictionary<int, int> actualResult = testChange.ChangeDictionary;
            Dictionary<int, int> expectedResult = new Dictionary<int, int>
            {
                {25, 21 },
                {10, 0 },
                {5, 1 }
            };
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetChangeMassiveBalance()
        {
            double balance = 200000000000.00D;
            Assert.AreEqual(false, testChange.ChangeMaker(balance));
        }

    }
}
