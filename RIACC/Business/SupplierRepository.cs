using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Data;
using RIACC.Entity;

namespace RIACC.Business
{
    public class SupplierRepository
    {
        //by rob Dec 12,2013
        //initial

        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<Supplier> GetSupplierList()
        {
            IQueryable<Supplier> supplier = db.Supplier.Where(x => x.Deleted == false);

            return supplier;
        }

        public Supplier GetSupplier(int supplierId)
        {
            Supplier supplier = db.Supplier.SingleOrDefault(x => x.SupplierId == supplierId);

            return supplier;
        }

        public string SaveTransaction(Supplier supplier)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                db.Supplier.Add(supplier);
                db.SaveChanges();
                trans.Commit();
                return "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.InnerException.InnerException.Message;
            }
        }

        public string UpdateTransaction(Supplier supplier)
        {
            try
            {
                Supplier updateSupplier = db.Supplier.SingleOrDefault(x => x.SupplierId == supplier.SupplierId);
                if (updateSupplier != null)
                {
                    updateSupplier.SupplierCode = supplier.SupplierName;
                    updateSupplier.Deleted = supplier.Deleted;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Supplier does not exists.");
                }

                return "success";
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return ex.Message;
                }
                else
                    return ex.InnerException.InnerException.Message;
            }
        }

        public string DeleteTransaction(Supplier supplier)
        {
            try
            {
                Supplier deleteSupplier = db.Supplier.SingleOrDefault(x => x.SupplierId == supplier.SupplierId);
                if (deleteSupplier != null)
                {
                    deleteSupplier.Deleted = false;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Supplier does not exists.");
                }

                return "success";
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return ex.Message;
                }
                else
                    return ex.InnerException.InnerException.Message;
            }
        }
    }
}
