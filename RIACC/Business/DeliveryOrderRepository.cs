using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Data;
using RIACC.Entity;

namespace RIACC.Business
{
    public class DeliveryOrderRepository
    {
        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<DeliveryOrder> GetDeliveryOrderList()
        {
            IQueryable<DeliveryOrder> details = db.DeliveryOrder.Where(x => x.Deleted == false);

            return details;
        }

        public DeliveryOrder GetDeliveryOrder(int drId)
        {
            var details = db.DeliveryOrderDetail.Find(drId);
            var order = db.DeliveryOrder.Find(drId);

            db.Entry(details).Reference(p => p.DeliveryOrder).Load();

            return order;            
        }


    }
}
