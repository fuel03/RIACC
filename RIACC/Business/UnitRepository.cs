using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;
using RIACC.Data;

namespace RIACC.Business
{
    public class UnitRepository : IUnitRepository
    {
        private DBConnectionContext db = new DBConnectionContext();
        public IQueryable<Unit> GetAll()
        {
            IQueryable<Unit> enu = from tb in db.Unit
                                    select tb;

            return enu;
            
        }

        public IQueryable<Unit> GetAllNonDeleted()
        {
            IQueryable<Unit> enu = from tb in db.Unit
                                    where tb.Deleted == false
                                    select tb;
            return enu;
        }

        public string Insert(Unit item)
        {
            try
            {
                db.Unit.Add(item);
                db.SaveChanges();
                return "";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
               
        }

        public string Update(Unit item)
        {
            try
            {
                Unit tmp = GetAll().Where(q => q.UnitId == item.UnitId).FirstOrDefault();
                if (tmp == null) { return "Cannot find unit to be edited"; }
                tmp.UnitName = item.UnitName;
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(Unit item)
        {
            try
            {
                Unit tmp = GetAll().Where(q => q.UnitId == item.UnitId && q.Deleted == false).FirstOrDefault();
                if (tmp == null) { return "Cannot find unit to be deleted"; }

                tmp.Deleted  = true;
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }
}
