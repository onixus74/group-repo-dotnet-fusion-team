using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class Category
    {
        public Category()
        {
            this.subcategorys = new List<Subcategory>();
        }

        public long categoryId { get; set; }
        public Nullable<int> categoryDisplayPriority { get; set; }
        public string categoryName { get; set; }
        public virtual ICollection<Subcategory> subcategorys { get; set; }
    }
}
