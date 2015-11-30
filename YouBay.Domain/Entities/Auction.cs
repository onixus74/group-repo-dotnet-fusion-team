using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class Auction
    {
        public long auctionId { get; set; }
        public Nullable<float> currentPrice { get; set; }
        public Nullable<System.DateTime> endTime { get; set; }
        public Nullable<System.DateTime> startTime { get; set; }
        public Nullable<long> buyer_youBayUserId { get; set; }
        public Nullable<long> product_productId { get; set; }
        public virtual Product product { get; set; }
        public virtual Buyer buyer { get; set; }
    }
}
