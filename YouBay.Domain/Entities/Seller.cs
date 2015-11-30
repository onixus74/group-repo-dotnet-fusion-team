using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YouBay.Domain.Entities
{
    public class Seller : YouBayUser
    {
        public Nullable<float> complaintPercentage { get; set; }
        public Nullable<float> gamificationScore { get; set; }
        public string sellerBadges { get; set; }
        public string sellerDescription { get; set; }
        public Nullable<bool> sellerIsSuspiciousFlag { get; set; }
        public string sellerLogo { get; set; }
        public Nullable<float> totalSales { get; set; }
        public virtual ICollection<Product> products { get; set; }


        Seller() : base()
        {
            this.products = new List<Product>();
        }

    }
}
