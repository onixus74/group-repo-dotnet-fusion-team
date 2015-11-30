using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class HistoryOfViews
    {
        public long buyerId { get; set; }
        public long productId { get; set; }
        public System.DateTime theDate { get; set; }
        public Nullable<int> client { get; set; }
        public string comment { get; set; }
        public virtual Product product { get; set; }
        public virtual Buyer buyer { get; set; }
    }
}
