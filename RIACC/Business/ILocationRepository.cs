using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface ILocationRepository
    {
        IQueryable<Location> GetLocationList();

        Location GetLocation(int locationId);

        string SaveTransaction(Location location);

        string UpdateTransaction(Location location);

        string DeleteTransaction(Location location);
    }
}
