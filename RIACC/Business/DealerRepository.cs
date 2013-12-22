using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Data;
using RIACC.Entity;

namespace RIACC.Business
{
    public class DealerRepository : IDealerRepository
    {
        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<Dealer> GetDealerList()
        {
            IQueryable<Dealer> dealer = db.Dealer.Where(x => x.Deleted == false);
            return dealer;
        }

        public IQueryable<DealerLocation> GetDealerLocationList(int dealerId)
        {
            IQueryable<DealerLocation> dealerLocation = db.DealerLocation.Where(x => x.DealerId == dealerId);
            return dealerLocation;
        }

        public Dealer GetDealer(int dealerId)
        {
            Dealer dealer = db.Dealer.SingleOrDefault(x => x.DealerId == dealerId);
            return dealer;
        }

        public string SaveTransaction(Dealer dealer, IList<Location> locationList)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                db.Dealer.Add(dealer);
                db.SaveChanges();

                foreach (Location detail in locationList)
                {
                    db.DealerLocation.Add(new DealerLocation()
                    {
                        DealerId = dealer.DealerId,
                        LocationId = detail.LocationId
                    });
                }
                db.SaveChanges();
                trans.Commit();
                return "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                if (ex.InnerException == null)
                {
                    return ex.Message;
                }
                else
                    return ex.InnerException.InnerException.Message;
            }
        }

        public string UpdateTransaction(Dealer dealer, IList<Location> locationList)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                Dealer updateDealer = db.Dealer.SingleOrDefault(x => x.DealerId == dealer.DealerId);

                if (updateDealer != null)
                {
                    updateDealer.DealerCode = dealer.DealerCode;
                    updateDealer.DealerName = dealer.DealerName;
                    updateDealer.Address = dealer.Address;
                    updateDealer.ContactPerson = dealer.ContactPerson;
                    updateDealer.ContactNumber = dealer.ContactNumber;
                    updateDealer.TIN = dealer.TIN;
                    updateDealer.Deleted = dealer.Deleted;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Dealer does not exists.");
                }

                IEnumerable<DealerLocation> dealerLocation = db.DealerLocation.Where(x => x.DealerId == dealer.DealerId);
                db.DealerLocation.RemoveRange(dealerLocation);

                foreach (Location detail in locationList)
                {
                    db.DealerLocation.Add(new DealerLocation()
                    {
                        DealerId = dealer.DealerId,
                        LocationId = detail.LocationId
                    });
                }

                db.SaveChanges();
                trans.Commit();
                return "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                if (ex.InnerException == null)
                {
                    return ex.Message;
                }
                else
                    return ex.InnerException.InnerException.Message;
            }
        }

        public string DeleteTransaction(Dealer dealer)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                Dealer updateDealer = db.Dealer.SingleOrDefault(x => x.DealerId == dealer.DealerId);

                if (updateDealer != null)
                {
                    updateDealer.Deleted = true;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Dealer does not exists.");
                }

                IEnumerable<DealerLocation> dealerLocation = db.DealerLocation.Where(x => x.DealerId == dealer.DealerId);
                db.DealerLocation.RemoveRange(dealerLocation);

                db.SaveChanges();
                trans.Commit();
                return "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
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
