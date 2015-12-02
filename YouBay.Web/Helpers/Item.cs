
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouBay.Domain.Entities;

namespace MVCYoubay2.Helpers
{
    public class Item
    {
        public int Quantity { get; set; }
        private int productId;

        public Product Product = null;
        public Product Prod
        {
            get
            {

                return Product;
            }
            set
            {
                Product = value;
            }
        }

        public string Description
        {
            get { return Product.productDescription; }
        }

        public float? UnitPrice
        {
            get { return Product.sellerPrice; }
        }

        public float? TotalPrice
        {
            get
            {

                return Product.sellerPrice * Quantity;
            }
        }

        public Item(Product p)
        {
            this.Prod = p;
        }

        public bool Equals(Item item)
        {
            return item.Prod.productId == this.Prod.productId;
        }

    }
}