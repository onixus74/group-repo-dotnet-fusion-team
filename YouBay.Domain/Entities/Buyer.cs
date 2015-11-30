using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBay.Domain.Entities
{
    public class Buyer : YouBayUser
    {

        public Nullable<float> accountBalance { get; set; }
        public string addressCity { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string buyerBadges { get; set; }
        public Nullable<bool> iSMale { get; set; }
        public Nullable<float> totalSpending { get; set; }
        public Nullable<long> customizedAds_customizedAdsId { get; set; }
        public virtual ICollection<Auction> auctions { get; set; }
        public virtual CustomizedAds customizedadss { get; set; }
        public virtual ICollection<HistoryOfViews> historyofviewss { get; set; }
        public virtual ICollection<OrderAndReview> orderandreviews { get; set; }
        public virtual ICollection<Product> products { get; set; }

        Buyer() : base()
        {
            this.auctions = new List<Auction>();
            this.historyofviewss = new List<HistoryOfViews>();
            this.orderandreviews = new List<OrderAndReview>();
            this.products = new List<Product>();
        }


    }
}
