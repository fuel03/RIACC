using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IDPComponentRepository
    {
        IQueryable<DPComponent> GetAll();
        IQueryable<DPComponent> GetAllNonDeleted();
        string Insert(DPComponent item, IList<DPComponentDetail> detailsList);
        string Update(DPComponent item, IList<DPComponentDetail> detailsList);
        string Delete(DPComponent item);
    }
}
