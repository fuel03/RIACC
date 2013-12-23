using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;
using RIACC.Data;

namespace RIACC.Business
{
    public class AuditRepository : IAuditRepository
    {
        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<AuditTrail> GetAuditTrail()
        {
            IQueryable<AuditTrail> auditTrail = db.AuditTrail;

            return auditTrail;
        }

        public AuditTrail GetAuditTrail(long auditId)
        {
            AuditTrail auditTrail = db.AuditTrail.Where(x => x.AuditId == auditId).SingleOrDefault();

            return auditTrail;
        }


        public string Insert(AuditTrail auditTrail)
        {
            try
            {
                db.AuditTrail.Add(auditTrail);
                db.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return ex.InnerException.InnerException.Message;
            }
        }
    }
}
