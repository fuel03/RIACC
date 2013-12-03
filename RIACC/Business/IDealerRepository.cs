using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IDealerRepository
    {
        IQueryable<Dealer> GetDealerList();

        IQueryable<DealerLocation> GetDealerLocationList(int dealerId);

        Dealer GetDealer(int dealerId);
        
        string SaveTransaction(Dealer dealer, IList<Location> locationList);

        string UpdateTransaction(Dealer dealer, IList<Location> locationList);

        string DeleteTransaction(Dealer dealer);
    }
}
