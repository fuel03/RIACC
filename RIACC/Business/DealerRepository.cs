using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIACC.Business
{
    public class DealerRepository : IDealerRepository
    {

        public IEnumerable<Entity.Dealer> GetDealerList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.DealerLocation> GetDealerLocationList()
        {
            throw new NotImplementedException();
        }

        public Entity.Dealer GetDealer(int dealerId)
        {
            throw new NotImplementedException();
        }

        public string SaveTransaction(Entity.Dealer dealer)
        {
            throw new NotImplementedException();
        }

        public string DeleteTransaction(Entity.Dealer dealer)
        {
            throw new NotImplementedException();
        }
    }
}
