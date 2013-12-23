using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IAuditRepository
    {
        IQueryable<AuditTrail> GetAuditTrail();

        AuditTrail GetAuditTrail(long auditId);

        string Insert(AuditTrail auditTrail);
    }
}
