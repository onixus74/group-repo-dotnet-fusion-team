using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class ProductHistoryMap : EntityTypeConfiguration<ProductHistory>
    {
        public ProductHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.productHistoryId);

            // Properties
            this.Property(t => t.productImageHistory)
                .HasMaxLength(1000);

            this.Property(t => t.productMainDescriptionHistory)
                .HasMaxLength(1000);

            this.Property(t => t.productNameHistory)
                .HasMaxLength(25);

            this.Property(t => t.productShortDescriptionHistory)
                .HasMaxLength(255);

            this.Property(t => t.subcategoryAdditionalValuesHistory)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("t_producthistory", "fusiondb");
            this.Property(t => t.productHistoryId).HasColumnName("productHistoryId");
            this.Property(t => t.historyDate).HasColumnName("historyDate");
            this.Property(t => t.productImageHistory).HasColumnName("productImageHistory");
            this.Property(t => t.productMainDescriptionHistory).HasColumnName("productMainDescriptionHistory");
            this.Property(t => t.productNameHistory).HasColumnName("productNameHistory");
            this.Property(t => t.productShortDescriptionHistory).HasColumnName("productShortDescriptionHistory");
            this.Property(t => t.quantityAvailableHistory).HasColumnName("quantityAvailableHistory");
            this.Property(t => t.sellerPriceHistory).HasColumnName("sellerPriceHistory");
            this.Property(t => t.subcategoryAdditionalValuesHistory).HasColumnName("subcategoryAdditionalValuesHistory");
            this.Property(t => t.product_productId).HasColumnName("product_productId");

            // Relationships
            this.HasOptional(t => t.products)
                .WithMany(t => t.producthistorys)
                .HasForeignKey(d => d.product_productId);

        }
    }
}
