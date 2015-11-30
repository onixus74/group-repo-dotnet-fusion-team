using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class Subcategory
    {
        public Subcategory()
        {
            this.assistantitemss = new List<AssistantItems>();
            this.products = new List<Product>();
        }

        public long subcategoryId { get; set; }
        public string assistantAvatarImage { get; set; }
        public Nullable<int> categoryDisplayPriority { get; set; }
        public string categoryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string subcategoryAttributesAndTypes { get; set; }
        public Nullable<long> category_categoryId { get; set; }
        public virtual ICollection<AssistantItems> assistantitemss { get; set; }
        public virtual Category categorys { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}
