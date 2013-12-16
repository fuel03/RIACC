using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIACC.Entity;

namespace RIACC.Business
{
    public interface IItemRepository
    {
        IQueryable<Item> GetAll();
        IQueryable<Item> GetAllNonDeleted();
        string Insert(Item item);
        string Update(Item item);
        string Delete(Item item);
    }
}
