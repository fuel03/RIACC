using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Data;
using RIACC.Entity;

namespace RIACC.Business
{
    public class PurchaseOrderRepository
    {
        //by rob Dec 12,2013
        //initial

        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<PurchaseOrder> GetPurchaseOrderList()
        {
            IQueryable<PurchaseOrder> purchaseOrder = db.PurchaseOrder.Where(x => x.Deleted == false);
            return purchaseOrder;
        }

        public IQueryable<PurchaseOrder> GetPurchaseOrderSummaryList(DateTime selectedDate)
        {
            IQueryable<PurchaseOrder> purchaseOrderSummaryList = db.PurchaseOrder.Where(x => x.Deleted == false && x.Date==selectedDate);

            if (purchaseOrderSummaryList == null)
            {
                throw new Exception("No Transactions On This Date.");
            }

            return purchaseOrderSummaryList;
        }

        public IQueryable<PurchaseOrder> GetPurchaseOrderDetails(int poId)
        {
            IQueryable<PurchaseOrder> purchaseOrderDetails = db.PurchaseOrder.Where(x=>x.POId==poId);

            if (purchaseOrderDetails == null)
            {
                throw new Exception("Details Not Found"); //??
            }

            return purchaseOrderDetails;
        }

        public PurchaseOrder GetPurchaseOrder(int poID)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrder.SingleOrDefault(x => x.POId == poID);

            if (purchaseOrder == null)
            {
                throw new Exception("Purchase Order Does Not Exist");
            }

            return purchaseOrder;
        }

        public string SaveTransaction(PurchaseOrder purchaseOrder)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                db.PurchaseOrder.Add(purchaseOrder);
                db.SaveChanges();
                trans.Commit();
                return "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.InnerException.InnerException.Message;
            }
        }

        public string UpdateTransaction(PurchaseOrder purchaseOrder)
        {
            try
            {
                PurchaseOrder updatePurhaseOrder = db.PurchaseOrder.SingleOrDefault(x => x.POId == purchaseOrder.POId);
                if (updatePurhaseOrder != null)
                {
                    updatePurhaseOrder.PONumber = purchaseOrder.PONumber;
                    
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Purchase Order does not exists.");
                }

                return "success";
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return ex.Message;
                }
                else
                    return ex.InnerException.InnerException.Message;
            }
        }
         
       
        
    }
}
