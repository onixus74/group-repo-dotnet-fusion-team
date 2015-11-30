using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class BuyerMap : EntityTypeConfiguration<Buyer>
    {
        public BuyerMap()
        {

            this.Property(t => t.addressCity)
                .HasMaxLength(200);

            this.Property(t => t.addressLine1)
                .HasMaxLength(200);

            this.Property(t => t.addressLine2)
                .HasMaxLength(200);

            this.Property(t => t.buyerBadges)
                .HasMaxLength(1000);

            /*child class attributes */
       
            this.Property(t => t.accountBalance).HasColumnName("accountBalance");
            this.Property(t => t.addressCity).HasColumnName("addressCity");
            this.Property(t => t.addressLine1).HasColumnName("addressLine1");
            this.Property(t => t.addressLine2).HasColumnName("addressLine2");
            this.Property(t => t.buyerBadges).HasColumnName("buyerBadges");
            this.Property(t => t.iSMale).HasColumnName("iSMale");
            this.Property(t => t.totalSpending).HasColumnName("totalSpending");
            this.Property(t => t.customizedAds_customizedAdsId).HasColumnName("customizedAds_customizedAdsId");

            // Relationships
            this.HasOptional(t => t.customizedadss)
                .WithMany(t => t.buyers)
                .HasForeignKey(d => d.customizedAds_customizedAdsId);
        }
    }
}
