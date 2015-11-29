using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YouBay.Data.Models.Mapping
{
    public class t_orderandreviewMap : EntityTypeConfiguration<t_orderandreview>
    {
        public t_orderandreviewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.buyerId, t.productId, t.theDate });

            // Properties
            this.Property(t => t.buyerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.productId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.initialMessageToSeller)
                .HasMaxLength(1000);

            this.Property(t => t.reviewText)
                .HasMaxLength(1000);

            this.Property(t => t.reviewTitle)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("t_orderandreview", "fusiondb");
            this.Property(t => t.buyerId).HasColumnName("buyerId");
            this.Property(t => t.productId).HasColumnName("productId");
            this.Property(t => t.theDate).HasColumnName("theDate");
            this.Property(t => t.buyerHasLeftAReview).HasColumnName("buyerHasLeftAReview");
            this.Property(t => t.hasFiledComplaint).HasColumnName("hasFiledComplaint");
            this.Property(t => t.initialMessageToSeller).HasColumnName("initialMessageToSeller");
            this.Property(t => t.oderFulfilledBySeller).HasColumnName("oderFulfilledBySeller");
            this.Property(t => t.orderDeliveredToBuyer).HasColumnName("orderDeliveredToBuyer");
            this.Property(t => t.pricePaidByBuyer).HasColumnName("pricePaidByBuyer");
            this.Property(t => t.productRating).HasColumnName("productRating");
            this.Property(t => t.reviewText).HasColumnName("reviewText");
            this.Property(t => t.reviewTitle).HasColumnName("reviewTitle");

            // Relationships
            this.HasRequired(t => t.t_product)
                .WithMany(t => t.t_orderandreview)
                .HasForeignKey(d => d.productId);
            this.HasRequired(t => t.t_user)
                .WithMany(t => t.t_orderandreview)
                .HasForeignKey(d => d.buyerId);

        }
    }
}
