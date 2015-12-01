using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class OrderAndReview
    {
        public long buyerId { get; set; }
        public long productId { get; set; }
        public System.DateTime theDate { get; set; }
        public Nullable<bool> buyerHasLeftAReview { get; set; }
        public Nullable<bool> hasFiledComplaint { get; set; }
        public string initialMessageToSeller { get; set; }
        public Nullable<bool> oderFulfilledBySeller { get; set; }
        public Nullable<bool> orderDeliveredToBuyer { get; set; }
        public Nullable<float> pricePaidByBuyer { get; set; }
        public Nullable<int> productRating { get; set; }
        public string reviewText { get; set; }
        public string reviewTitle { get; set; }
        public virtual Product product { get; set; }
        public virtual Buyer buyer { get; set; }
    }
}