using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RIACC.Entity;

namespace RIACC.Models
{
    public class PurchaseOrderUIViewEntity : PurchaseOrder
    {        
        public IList<PurchaseOrderDetail> PODetailsList { get; set; }
    }
}