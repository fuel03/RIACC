using RIACC.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RIACC.Entity;
using System.Linq;
using System.Collections.Generic;

namespace RIACC_Test
{
    
    
    /// <summary>
    ///This is a test class for DealerRepositoryTest and is intended
    ///to contain all DealerRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DealerRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DealerRepository Constructor
        ///</summary>
        [TestMethod()]
        public void DealerRepositoryConstructorTest()
        {
            DealerRepository target = new DealerRepository();          
        }

        /// <summary>
        ///A test for DeleteTransaction
        ///</summary>
        [TestMethod()]
        public void canDeleteTransactionTest()
        {
            DealerRepository target = new DealerRepository(); // TODO: Initialize to an appropriate value
            Dealer dealer = new Dealer() { Deleted = true, DealerId = 1 }; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DeleteTransaction(dealer);
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for GetDealer
        ///</summary>
        [TestMethod()]
        public void canGetDealerTest()
        {
            DealerRepository target = new DealerRepository(); // TODO: Initialize to an appropriate value
            int dealerId = 1; // TODO: Initialize to an appropriate value            
            Dealer actual;
            actual = target.GetDealer(dealerId);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetDealerList
        ///</summary>
        [TestMethod()]
        public void canGetDealerListTest()
        {
            DealerRepository target = new DealerRepository(); // TODO: Initialize to an appropriate value
            
            IQueryable<Dealer> actual;
            actual = target.GetDealerList();
            Assert.IsNotNull(actual);            
        }

        /// <summary>
        ///A test for GetDealerLocationList
        ///</summary>
        [TestMethod()]
        public void canGetDealerLocationListTest()
        {
            DealerRepository target = new DealerRepository(); // TODO: Initialize to an appropriate value
            int dealerId = 1; // TODO: Initialize to an appropriate value
            
            IQueryable<DealerLocation> actual;
            actual = target.GetDealerLocationList(dealerId);
            Assert.IsNotNull(actual);
            
        }

        /// <summary>
        ///A test for SaveTransaction
        ///</summary>
        [TestMethod()]
        public void canSaveTransactionTest()
        {
            DealerRepository target = new DealerRepository(); // TODO: Initialize to an appropriate value
            Dealer dealer = new Dealer()
            {
                Address = "Address1",
                ContactNumber = "0917231",
                ContactPerson = "JJ",
                DealerCode = "Dealer001",
                DealerName = "James James",
                TIN = "TINTINTIN"
            };
            IList<Location> locationList = new List<Location>();
            locationList.Add(new Location() { LocationId = 1 });
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SaveTransaction(dealer, locationList);
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for UpdateTransaction
        ///</summary>
        [TestMethod()]
        public void canUpdateTransactionTest()
        {
            DealerRepository target = new DealerRepository(); // TODO: Initialize to an appropriate value
            Dealer dealer = new Dealer()
            {
                DealerId = 1,
                Address = "Address11",
                ContactNumber = "0917231JJ",
                ContactPerson = "JJ-MM",
                DealerCode = "Dealer001",
                DealerName = "James James@#$%^&*()_:",
                TIN = "TINTINTINERTYUIOPIUY"
            };
            IList<Location> locationList = new List<Location>();
            locationList.Add(new Location() { LocationId = 3 });
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.UpdateTransaction(dealer, locationList);
            Assert.AreEqual(expected, actual);            
        }
    }
}
