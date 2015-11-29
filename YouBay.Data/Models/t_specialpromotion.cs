using System;
using System.Collections.Generic;

namespace YouBay.Data.Models
{
    public partial class t_specialpromotion
    {
        public long specialPromotionId { get; set; }
        public string dealDescription { get; set; }
        public Nullable<bool> dealDisabledByAdmin { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<float> reductionPercentage { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<long> product_productId { get; set; }
        public virtual t_product t_product { get; set; }
    }
}
