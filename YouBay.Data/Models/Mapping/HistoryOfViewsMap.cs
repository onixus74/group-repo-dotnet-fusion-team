using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class HistoryOfViewsMap : EntityTypeConfiguration<HistoryOfViews>
    {
        public HistoryOfViewsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.buyerId, t.productId, t.theDate });

            // Properties
            this.Property(t => t.buyerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.productId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.comment)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("t_historyofviews", "fusiondb");
            this.Property(t => t.buyerId).HasColumnName("buyerId");
            this.Property(t => t.productId).HasColumnName("productId");
            this.Property(t => t.theDate).HasColumnName("theDate");
            this.Property(t => t.client).HasColumnName("client");
            this.Property(t => t.comment).HasColumnName("comment");

            // Relationships
            this.HasRequired(t => t.product)
                .WithMany(t => t.historyofviewss)
                .HasForeignKey(d => d.productId);
            this.HasRequired(t => t.buyer)
                .WithMany(t => t.historyofviewss)
                .HasForeignKey(d => d.buyerId);

        }
    }
}
