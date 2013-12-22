using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface ISupplierRepository
    {
        IQueryable<Supplier> GetSupplierList;

        Supplier GetSupplier(int supplierId);

        string SaveTransaction(Supplier supplier);

        string UpdateTransaction(Supplier supplier);

        string DeleteTransaction(Supplier supplier);
    }
}
