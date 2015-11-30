using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class Product
    {
        public Product()
        {
            auctions = new List<Auction>();
            customizedadss = new List<CustomizedAds>();
            historyofviewss = new List<HistoryOfViews>();
            orderandreviews = new List<OrderAndReview>();
            producthistorys = new List<ProductHistory>();
            specialpromotions = new List<SpecialPromotion>();
            buyers = new List<Buyer>();
        }

        public long productId { get; set; }
        public Nullable<bool> isDisabledByAdmin { get; set; }
        public Nullable<bool> isDisabledBySeller { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        public string productName { get; set; }
        public Nullable<int> quantityAvailable { get; set; }
        public Nullable<float> sellerPrice { get; set; }
        public string subcategoryAttributesAndValues { get; set; }
        public Nullable<long> seller_youBayUserId { get; set; }
        public Nullable<long> subcategory_subcategoryId { get; set; }
        public virtual ICollection<Auction> auctions { get; set; }
        public virtual ICollection<CustomizedAds> customizedadss { get; set; }
        public virtual ICollection<HistoryOfViews> historyofviewss { get; set; }
        public virtual ICollection<OrderAndReview> orderandreviews { get; set; }
        public virtual ICollection<ProductHistory> producthistorys { get; set; }
        public virtual Subcategory subcategory { get; set; }
        public virtual Seller seller { get; set; }
        public virtual ICollection<SpecialPromotion> specialpromotions { get; set; }
        public virtual ICollection<Buyer> buyers { get; set; }
    }
}
