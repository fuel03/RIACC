using RIACC.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RIACC.Entity;
using System.Linq;
using System.Collections.Generic;

namespace RIACC_Test
{
    
    
    /// <summary>
    ///This is a test class for UnitRepositoryTest and is intended
    ///to contain all UnitRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnitRepositoryTest
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
            UnitRepository target = new UnitRepository(); // TODO: Initialize to an appropriate value
            //IQueryable<Item> expected = null; // TODO: Initialize to an appropriate value
            int expectedCount = 4;
            IList<Unit> actual = target.GetAll().ToList();
            Assert.AreEqual(expectedCount, actual.Count());
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            UnitRepository target = new UnitRepository(); // TODO: Initialize to an appropriate value
            Unit item = new Unit { UnitId = 6 };
            target.Delete(item);

            Unit actual;
            actual = target.GetAllNonDeleted().Where(q => q.UnitId == 6).SingleOrDefault();
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        ///A test for GetAllNonDeleted
        ///</summary>
        [TestMethod()]
        public void GetAllNonDeletedTest()
        {
            UnitRepository target = new UnitRepository(); // TODO: Initialize to an appropriate value
            //IQueryable<Item> expected = null; // TODO: Initialize to an appropriate value
            int expectedCount = 3;
            IList<Unit> actual = target.GetAllNonDeleted().ToList();
            Assert.AreEqual(expectedCount, actual.Count());
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            UnitRepository target = new UnitRepository(); // TODO: Initialize to an appropriate value
            Unit unit = new Unit { Deleted = false, UnitName = "Edward" };
            target.Insert(unit);


            int expectedCount = 4; // TODO: Initialize to an appropriate value
            IList<Unit> actual;
            actual = target.GetAllNonDeleted().ToList();
            Assert.AreEqual(expectedCount, actual.Count());
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            UnitRepository target = new UnitRepository(); // TODO: Initialize to an appropriate value
            Unit unit = new Unit { Deleted = false, UnitName = "Edwardooooo", UnitId = 6 };
            target.Update(unit);


           
            Unit actual;
            actual = target.GetAllNonDeleted().Where(q => q.UnitId == 6).SingleOrDefault();
            Assert.AreEqual("Edwardooooo", actual.UnitName);
        }
    }
}
