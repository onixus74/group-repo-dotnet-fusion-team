using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class CustomizedAdsMap : EntityTypeConfiguration<CustomizedAds>
    {
        public CustomizedAdsMap()
        {
            // Primary Key
            this.HasKey(t => t.customizedAdsId);

            // Properties
            this.Property(t => t.customizedMessage)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_customizedads", "fusiondb");
            this.Property(t => t.customizedAdsId).HasColumnName("customizedAdsId");
            this.Property(t => t.customizedMessage).HasColumnName("customizedMessage");
            this.Property(t => t.endDate).HasColumnName("endDate");
            this.Property(t => t.importanceScore).HasColumnName("importanceScore");
            this.Property(t => t.isACustomizedMarketingAd).HasColumnName("isACustomizedMarketingAd");
            this.Property(t => t.isAPurchasedAd).HasColumnName("isAPurchasedAd");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.product_productId).HasColumnName("product_productId");

            // Relationships
            this.HasOptional(t => t.product)
                .WithMany(t => t.customizedadss)
                .HasForeignKey(d => d.product_productId);

        }
    }
}
