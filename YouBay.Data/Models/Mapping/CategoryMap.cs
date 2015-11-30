using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.categoryId);

            // Properties
            this.Property(t => t.categoryName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("t_category", "fusiondb");
            this.Property(t => t.categoryId).HasColumnName("categoryId");
            this.Property(t => t.categoryDisplayPriority).HasColumnName("categoryDisplayPriority");
            this.Property(t => t.categoryName).HasColumnName("categoryName");
        }
    }
}
