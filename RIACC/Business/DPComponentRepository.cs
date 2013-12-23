using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;
using RIACC.Data;
//using System.Transactions;

namespace RIACC.Business
{
    public class DPComponentRepository : IDPComponentRepository
    {
        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<DPComponent> GetAll()
        {
            IQueryable<DPComponent> enu = from tb in db.DPComponent
                                                    select tb;
            return enu;
        }

        public IQueryable<DPComponent> GetAllNonDeleted()
        {
            IQueryable<DPComponent> enu = from tb in db.DPComponent
                                          where tb.Deleted == false
                                            select tb;
            return enu;
        }

        public string Insert(DPComponent item, IList<DPComponentDetail> detailsList)
        {
            var trans = db.Database.BeginTransaction();

            try
            {                
                //using (TransactionScope tran = new TransactionScope())
                //{
                    
                    db.DPComponent.Add(item);
                    db.SaveChanges();
                    
                    //insert details
                    foreach (var details in detailsList)
                    {
                        details.DPId = item.DPId;
                        db.DPComponentDetail.Add(details);
                        db.SaveChanges();
                    }

                    
                  //  tran.Complete();
                    trans.Commit();
                    return ""; 
                //}
                   
            }
            catch(Exception ex)
            {
                trans.Rollback();
                return ex.InnerException.InnerException.Message;
            }
        }

        public string Update(DPComponent item, IList<DPComponentDetail> detailsList)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                //using (TransactionScope tran = new TransactionScope())
                //{

                    DPComponent tmp = GetAllNonDeleted().Where(q => q.DPId == item.DPId && q.Deleted == false).FirstOrDefault();
                    if (tmp == null) { return "Cannot find DP component to delete."; }

                    tmp.Approved = item.Approved;
                    tmp.ApprovedBy = item.ApprovedBy;
                    tmp.Date = item.Date;
                    tmp.PreparedBy = item.PreparedBy;
                    tmp.Remarks = item.Remarks;
                    db.SaveChanges();

                    //delete all details
                    var tmpDetailList = (from tb in db.DPComponentDetail
                                         where tb.DPId == item.DPId
                                         select tb);
                    foreach (var details in tmpDetailList)
                    {
                        db.DPComponentDetail.Remove(details);
                        db.SaveChanges();
                    }


                    //insert details
                    foreach (var details in detailsList)
                    {
                        db.DPComponentDetail.Add(details);
                        db.SaveChanges();
                    }

                    //tran.Complete();
                    trans.Commit();
                    return "";
                //}
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.InnerException.InnerException.Message;
            }
        }

        public string Delete(DPComponent item)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                //using (TransactionScope tran = new TransactionScope())
                //{

                    DPComponent tmp = GetAllNonDeleted().Where(q => q.DPId == item.DPId && q.Deleted == false).FirstOrDefault();
                    if (tmp == null) { return "Cannot find DP component to delete."; }

                    tmp.Deleted = true;
                    db.SaveChanges();

                    //delete details
                    var detaillist = (from tb in db.DPComponentDetail
                                      where tb.DPId == item.DPId
                                      select tb);

                    foreach (var detail in detaillist)
                    {
                        db.DPComponentDetail.Remove(detail);
                        db.SaveChanges();
                    }

                  //  tran.Complete();
                    trans.Commit();
                    return "";                    
                //}
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.InnerException.InnerException.Message;
            }
        }
        
    }
}
