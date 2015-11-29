using System;
using System.Collections.Generic;

namespace YouBay.Data.Models
{
    public partial class t_category
    {
        public t_category()
        {
            this.t_subcategory = new List<t_subcategory>();
        }

        public long categoryId { get; set; }
        public Nullable<int> categoryDisplayPriority { get; set; }
        public string categoryName { get; set; }
        public virtual ICollection<t_subcategory> t_subcategory { get; set; }
    }
}
