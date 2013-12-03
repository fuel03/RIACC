using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Data;
using RIACC.Entity;

namespace RIACC.Business
{
    public class LocationRepository : ILocationRepository
    {
        private DBConnectionContext db = new DBConnectionContext();

        public IQueryable<Location> GetLocationList()
        {
            IQueryable<Location> location = db.Location.Where(x => x.Deleted == false);

            return location;
        }

        public Location GetLocation(int locationId)
        {
            Location location = db.Location.SingleOrDefault(x => x.LocationId == locationId);

            return location;
        }

        public string SaveTransaction(Location location)
        {
            var trans = db.Database.BeginTransaction();

            try
            {
                db.Location.Add(location);
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

        public string UpdateTransaction(Location location)
        {
            try
            {
                Location updateLocation = db.Location.SingleOrDefault(x => x.LocationId == location.LocationId);
                if (updateLocation != null)
                {
                    updateLocation.LocationName = location.LocationName;
                    updateLocation.Deleted = location.Deleted;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Location does not exists.");
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

        public string DeleteTransaction(Location location)
        {
            try
            {
                Location deleteLocation = db.Location.SingleOrDefault(x => x.LocationId == location.LocationId);
                if (deleteLocation != null)
                {
                    deleteLocation.Deleted = false;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Location does not exists.");
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
