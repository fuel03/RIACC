using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IUnitRepository
    {
        IQueryable<Unit> GetAll();
        IQueryable<Unit> GetAllNonDeleted();
        string Insert(Unit item);
        string Update(Unit item);
        string Delete(Unit item);
    }
}
