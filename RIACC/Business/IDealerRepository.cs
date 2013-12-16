using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IDealerRepository
    {
        IEnumerable<Dealer> GetDealerList();

        IEnumerable<DealerLocation> GetDealerLocationList();

        Dealer GetDealer(int dealerId);

        string SaveTransaction(Dealer dealer);

        string DeleteTransaction(Dealer dealer);
    }
}
