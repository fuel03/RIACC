using RIACC.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RIACC.Entity;
using System.Collections.Generic;
using System.Linq;

namespace RIACC_Test
{   
    /// <summary>
    ///This is a test class for LocationRepositoryTest and is intended
    ///to contain all LocationRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocationRepositoryTest
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
        ///A test for LocationRepository Constructor
        ///</summary>
        [TestMethod()]
        public void LocationRepositoryConstructorTest()
        {
            LocationRepository target = new LocationRepository();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DeleteTransaction
        ///</summary>
        [TestMethod()]
        public void canDeleteTransactionTest()
        {
            LocationRepository target = new LocationRepository(); // TODO: Initialize to an appropriate value
            Location location = new Location() { LocationId = 1, Deleted = true };
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DeleteTransaction(location);
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for GetLocation
        ///</summary>
        [TestMethod()]
        public void canGetLocationTest()
        {
            LocationRepository target = new LocationRepository(); // TODO: Initialize to an appropriate value
            int locationId = 1; 
            Location actual;
            actual = target.GetLocation(locationId);
            Assert.IsNotNull(actual);            
        }

        /// <summary>
        ///A test for GetLocationList
        ///</summary>
        [TestMethod()]
        public void canGetLocationListTest()
        {
            LocationRepository target = new LocationRepository(); // TODO: Initialize to an appropriate value            
            IQueryable<Location> actual;
            actual = target.GetLocationList();
            Assert.IsNotNull(actual);            
        }

        /// <summary>
        ///A test for SaveTransaction
        ///</summary>
        [TestMethod()]
        public void canSaveTransactionTest()
        {
            LocationRepository target = new LocationRepository();

            Location location = new Location()
            {
                LocationName = "Makati"
            };
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SaveTransaction(location);
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for UpdateTransaction
        ///</summary>
        [TestMethod()]
        public void canUpdateTransactionTest()
        {
            LocationRepository target = new LocationRepository(); // TODO: Initialize to an appropriate value
            Location location = new Location() { LocationId = 1, LocationName = "Bulacan", Deleted = false };
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.UpdateTransaction(location);
            Assert.AreEqual(expected, actual);            
        }
    }
}
