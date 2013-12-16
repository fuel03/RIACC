using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;
using RIACC.Data;



namespace RIACC.Business
{
    public class ItemRepository : IItemRepository
    {

        private DBConnectionContext db = new DBConnectionContext();

        

        public IQueryable<Item> GetAll()
        {
            IQueryable<Item> enu = from tblItem in db.Item
                                    select tblItem;
                
            return enu;
        }

        public IQueryable<Item> GetAllNonDeleted()
        {
         
            IQueryable<Item> enu = from tblItem in db.Item
                                    where tblItem.Deleted == false
                                    select tblItem;
            return enu;
        }

        public string Insert(Item item)
        {
            try
            {
                db.Item.Add(item);
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.InnerException.InnerException.Message;
            }
        }

        public string Update(Item item)
        {
            try
            {
                Item tmp = GetAll().Where(q => q.ItemId == item.ItemId && q.Deleted == false).FirstOrDefault();
                if (tmp == null) { return "Cannot find item to be edited"; }

                tmp.ItemCode = item.ItemCode;
                tmp.ItemDescription = item.ItemDescription;
                tmp.Price = item.Price;
                tmp.UnitId = item.UnitId;
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.InnerException.InnerException.Message;
            }
        }

        public string Delete(Item item)
        {
            try
            {
                Item tmp = GetAll().Where(q => q.ItemId == item.ItemId).FirstOrDefault();
                if (tmp == null) { return "Cannot find item to be deleted"; }

                tmp.Deleted = true;
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.InnerException.InnerException.Message;
            }
        }
    }
}
