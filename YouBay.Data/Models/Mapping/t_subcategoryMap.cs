using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YouBay.Data.Models.Mapping
{
    public class t_subcategoryMap : EntityTypeConfiguration<t_subcategory>
    {
        public t_subcategoryMap()
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
            this.HasOptional(t => t.t_category)
                .WithMany(t => t.t_subcategory)
                .HasForeignKey(d => d.category_categoryId);

        }
    }
}
