using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IPurchaseOrderRepository
    {
         IQueryable<PurchaseOrder> GetPurchaseOrderList();

         IQueryable<PurchaseOrder> GetPurchaseOrderDetails(int poId);

         PurchaseOrder GetPurchaseOrder(int poID);

         string SaveTransaction(PurchaseOrder purchaseOrder);

         string UpdateTransaction(PurchaseOrder purchaseOrder);

        IQueryable<PurchaseOrder> GetPurchaseOrderSummaryList(DateTime selectedDate);

    }
}
