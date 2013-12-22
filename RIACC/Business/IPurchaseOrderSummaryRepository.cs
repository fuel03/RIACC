using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IPurchaseOrderSummaryRepository
    {
        IQueryable<PurchaseOrder> GetPurchaseOrderSummaryList(DateTime selectedDate);

    }
}
