using RIACC.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RIACC.Entity;
using System.Linq;
using System.Collections.Generic;

namespace RIACC_Test
{
    
    
    /// <summary>
    ///This is a test class for DPComponentRepositoryTest and is intended
    ///to contain all DPComponentRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DPComponentRepositoryTest
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
            DPComponentRepository target = new DPComponentRepository(); 
            int expected = 3; 
            IList<DPComponent> actual;
            actual = target.GetAll().ToList();
            Assert.AreEqual(expected, actual.Count);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            DPComponentRepository target = new DPComponentRepository(); 
            DPComponent item = null; 
            string expected = string.Empty; 
            string actual;
            actual = target.Delete(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllNonDeleted
        ///</summary>
        [TestMethod()]
        public void GetAllNonDeletedTest()
        {
            DPComponentRepository target = new DPComponentRepository();
            int expected = 2;
            IList<DPComponent> actual;
            actual = target.GetAllNonDeleted().ToList();
            Assert.AreEqual(expected, actual.Count);
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            DPComponentRepository target = new DPComponentRepository();
            DPComponent item = new DPComponent { Approved = false, ApprovedBy = 6, Date = DateTime.Now, Deleted = false, DPNumber = "6", PreparedBy = 6, Remarks = "Dummy 6" };
            IList<DPComponentDetail> detailsList = new List<DPComponentDetail>();
            detailsList.Add(new DPComponentDetail { DealerId = 1, DPId = 6, DRDetailId = 1, LocationId = 1 });
            detailsList.Add(new DPComponentDetail { DealerId = 1, DPId = 6, DRDetailId = 2, LocationId = 1 });
            detailsList.Add(new DPComponentDetail { DealerId = 1, DPId = 6, DRDetailId = 3, LocationId = 1 });

            target.Insert(item, detailsList);

            int expected = 5;
            IList<DPComponent> actual;
            actual = target.GetAllNonDeleted().ToList();
            Assert.AreEqual(expected, actual.Count);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            DPComponentRepository target = new DPComponentRepository(); // TODO: Initialize to an appropriate value
            DPComponent item = null; // TODO: Initialize to an appropriate value
            IList<DPComponentDetail> detailsList = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Update(item, detailsList);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
