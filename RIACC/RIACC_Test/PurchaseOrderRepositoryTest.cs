using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RIACC.Business;
using RIACC.Entity;

namespace RIACC_Test
{
    [TestClass]
    public class PurchaseOrderRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        /// <summary>
        ///A test for DeleteTransaction
        ///</summary>
        //[TestMethod()]
        //public void canDeleteTransactionTest()
        //{
        //    PurchaseOrderRepository target = new PurchaseOrderRepository(); // TODO: Initialize to an appropriate value
        //    PurchaseOrder purhaseOrder = new PurchaseOrder() { POId = 1, Deleted = true };
        //    string expected = "success"; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.DeleteTransaction(PurchaseOrderSummary);
        //    Assert.AreEqual(expected, actual);
        //}

        /// <summary>
        ///A test for GetLocation
        ///</summary>
        [TestMethod()]
        public void canGetPurchaseOrderTest()
        {
            PurchaseOrderRepository target = new PurchaseOrderRepository(); // TODO: Initialize to an appropriate value
            int PurchaseOrderId = 1;
            PurchaseOrder actual;
            actual = target.GetPurchaseOrder(PurchaseOrderId);

            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetLocationList
        ///</summary>
        [TestMethod()]
        public void canGetPurchaseOrderListTest()
        {
            PurchaseOrderRepository target = new PurchaseOrderRepository(); // TODO: Initialize to an appropriate value            
            IQueryable<PurchaseOrder> actual;
            actual = target.GetPurchaseOrderList();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for SaveTransaction
        ///</summary>
        [TestMethod()]
        public void canSaveTransactionTest()
        {
            PurchaseOrderRepository target = new PurchaseOrderRepository();

            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                PONumber = "12345"
            };
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SaveTransaction(purchaseOrder);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UpdateTransaction
        ///</summary>
        [TestMethod()]
        public void canUpdateTransactionTest()
        {
            PurchaseOrderRepository target = new PurchaseOrderRepository(); // TODO: Initialize to an appropriate value
            PurchaseOrder PurchaseOrder = new PurchaseOrder() { POId = 1, PONumber = "12345"};
            string expected = "success"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.UpdateTransaction(PurchaseOrder);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void canGetPurchaseOrderSummaryListTest()
        {
            PurchaseOrderRepository target = new PurchaseOrderRepository(); // TODO: Initialize to an appropriate value
            DateTime selectedDate = new DateTime(2010, 1, 1);
            IQueryable<PurchaseOrder> actual;
            actual = target.GetPurchaseOrderSummaryList(selectedDate);

            Assert.IsNotNull(actual); 
        }
    }
}
