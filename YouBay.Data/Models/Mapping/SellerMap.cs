using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class SellerMap : EntityTypeConfiguration<Seller>
    {
        public SellerMap():base()
        {
          
            this.Property(t => t.sellerBadges)
                .HasMaxLength(1000);

            this.Property(t => t.sellerDescription)
                .HasMaxLength(1000);

            this.Property(t => t.sellerLogo)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("t_user", "fusiondb");
           
            /*child class attributes */
            this.Property(t => t.complaintPercentage).HasColumnName("complaintPercentage");
            this.Property(t => t.gamificationScore).HasColumnName("gamificationScore");
            this.Property(t => t.sellerBadges).HasColumnName("sellerBadges");
            this.Property(t => t.sellerDescription).HasColumnName("sellerDescription");
            this.Property(t => t.sellerIsSuspiciousFlag).HasColumnName("sellerIsSuspiciousFlag");
            this.Property(t => t.sellerLogo).HasColumnName("sellerLogo");
            this.Property(t => t.totalSales).HasColumnName("totalSales");
           
        }
    }
}
