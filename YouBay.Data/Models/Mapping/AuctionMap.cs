using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class AuctionMap : EntityTypeConfiguration<Auction>
    {
        public AuctionMap()
        {
            // Primary Key
            this.HasKey(t => t.auctionId);

            // Properties
            // Table & Column Mappings
            this.ToTable("t_auction", "fusiondb");
            this.Property(t => t.auctionId).HasColumnName("auctionId");
            this.Property(t => t.currentPrice).HasColumnName("currentPrice");
            this.Property(t => t.endTime).HasColumnName("endTime");
            this.Property(t => t.startTime).HasColumnName("startTime");
            this.Property(t => t.buyer_youBayUserId).HasColumnName("buyer_youBayUserId");
            this.Property(t => t.product_productId).HasColumnName("product_productId");

            // Relationships
            this.HasOptional(t => t.product)
                .WithMany(t => t.auctions)
                .HasForeignKey(d => d.product_productId);
            this.HasOptional(t => t.buyer)
                .WithMany(t => t.auctions)
                .HasForeignKey(d => d.buyer_youBayUserId);

        }
    }
}
