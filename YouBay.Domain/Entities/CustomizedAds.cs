using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class CustomizedAds
    {
        public CustomizedAds()
        {
            buyers = new List<Buyer>();
        }

        public long customizedAdsId { get; set; }
        public string customizedMessage { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<float> importanceScore { get; set; }
        public Nullable<bool> isACustomizedMarketingAd { get; set; }
        public Nullable<bool> isAPurchasedAd { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<long> product_productId { get; set; }
        public virtual Product product { get; set; }
        public virtual ICollection<Buyer> buyers { get; set; }
    }
}
