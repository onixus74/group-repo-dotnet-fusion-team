using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class SubcategoryMap : EntityTypeConfiguration<Subcategory>
    {
        public SubcategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.subcategoryId);

            // Properties
            this.Property(t => t.assistantAvatarImage)
                .HasMaxLength(1000);

            this.Property(t => t.categoryName)
                .HasMaxLength(100);

            this.Property(t => t.subcategoryAttributesAndTypes)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("t_subcategory", "fusiondb");
            this.Property(t => t.subcategoryId).HasColumnName("subcategoryId");
            this.Property(t => t.assistantAvatarImage).HasColumnName("assistantAvatarImage");
            this.Property(t => t.categoryDisplayPriority).HasColumnName("categoryDisplayPriority");
            this.Property(t => t.categoryName).HasColumnName("categoryName");
            this.Property(t => t.isActive).HasColumnName("isActive");
            this.Property(t => t.subcategoryAttributesAndTypes).HasColumnName("subcategoryAttributesAndTypes");
            this.Property(t => t.category_categoryId).HasColumnName("category_categoryId");

            // Relationships
            this.HasOptional(t => t.categorys)
                .WithMany(t => t.subcategorys)
                .HasForeignKey(d => d.category_categoryId);

        }
    }
}
