using RIACC.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RIACC.Entity;
using System.Linq;
using System.Collections.Generic;

namespace RIACC_Test
{
    
    
    /// <summary>
    ///This is a test class for ItemRepositoryTest and is intended
    ///to contain all ItemRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ItemRepositoryTest
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
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            ItemRepository target = new ItemRepository(); // TODO: Initialize to an appropriate value
            //IQueryable<Item> expected = null; // TODO: Initialize to an appropriate value
            int expectedCount = 2;
            IList<Item> actual;
            actual = target.GetAll().ToList();
            Assert.AreEqual(expectedCount, actual.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            ItemRepository target = new ItemRepository(); // TODO: Initialize to an appropriate value
            Item item = new Item { ItemId =  6 };
            target.Delete(item);


            Item tmp = target.GetAll().Where(q => q.ItemId == 6).SingleOrDefault();
            Assert.AreEqual(true, tmp.Deleted);
        }

        /// <summary>
        ///A test for GetAllNonDeleted
        ///</summary>
        [TestMethod()]
        public void GetAllNonDeletedTest()
        {
            ItemRepository target = new ItemRepository(); // TODO: Initialize to an appropriate value
            //IQueryable<Item> expected = null; // TODO: Initialize to an appropriate value
            int expectedCount = 1;
            IList<Item> actual;
            actual = target.GetAllNonDeleted().ToList();
            Assert.AreEqual(expectedCount, actual.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            ItemRepository target = new ItemRepository(); // TODO: Initialize to an appropriate value
            Item item = new Item{ Deleted = false, ItemCode = "Code3", ItemDescription = "Testing for Code3", Price =10, UnitId = 2};
            target.Insert(item);
            

            int expectedCount = 2; // TODO: Initialize to an appropriate value
            IList<Item> actual;
            actual = target.GetAllNonDeleted().ToList();
            Assert.AreEqual(expectedCount, actual.Count());
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            ItemRepository target = new ItemRepository(); // TODO: Initialize to an appropriate value
            Item item = new Item { Deleted = false, ItemCode = "Code4", ItemDescription = "Test for update", Price = 11, UnitId = 1 ,ItemId = 7};
            target.Update(item);


            Item tmp = target.GetAllNonDeleted().Where(q => q.ItemId == 7).SingleOrDefault();
            Assert.AreEqual("Test for update", tmp.ItemDescription);
        }
    }
}
