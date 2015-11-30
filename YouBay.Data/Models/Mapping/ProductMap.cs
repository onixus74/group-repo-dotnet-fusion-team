using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.productId);

            // Properties
            this.Property(t => t.productDescription)
                .HasMaxLength(1000);

            this.Property(t => t.productImage)
                .HasMaxLength(1000);

            this.Property(t => t.productName)
                .HasMaxLength(100);

            this.Property(t => t.subcategoryAttributesAndValues)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("t_product", "fusiondb");
            this.Property(t => t.productId).HasColumnName("productId");
            this.Property(t => t.isDisabledByAdmin).HasColumnName("isDisabledByAdmin");
            this.Property(t => t.isDisabledBySeller).HasColumnName("isDisabledBySeller");
            this.Property(t => t.productDescription).HasColumnName("productDescription");
            this.Property(t => t.productImage).HasColumnName("productImage");
            this.Property(t => t.productName).HasColumnName("productName");
            this.Property(t => t.quantityAvailable).HasColumnName("quantityAvailable");
            this.Property(t => t.sellerPrice).HasColumnName("sellerPrice");
            this.Property(t => t.subcategoryAttributesAndValues).HasColumnName("subcategoryAttributesAndValues");
            this.Property(t => t.seller_youBayUserId).HasColumnName("seller_youBayUserId");
            this.Property(t => t.subcategory_subcategoryId).HasColumnName("subcategory_subcategoryId");

            // Relationships
            this.HasMany(t => t.buyers)
                .WithMany(t => t.products)
                .Map(m =>
                    {
                        m.ToTable("t_user_t_product", "fusiondb");
                        m.MapLeftKey("products_productId");
                        m.MapRightKey("buyers_youBayUserId");
                    });

            this.HasOptional(t => t.subcategory)
                .WithMany(t => t.products)
                .HasForeignKey(d => d.subcategory_subcategoryId);
            this.HasOptional(t => t.seller)
                .WithMany(t => t.products)
                .HasForeignKey(d => d.seller_youBayUserId);

        }
    }
}
