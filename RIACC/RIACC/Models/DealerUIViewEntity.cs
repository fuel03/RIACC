using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RIACC.Entity;

namespace RIACC.Models
{
    public class DealerUIViewEntity: Dealer
    {
        public IList<DealerLocation> LocationList { get; set; }
    }
}