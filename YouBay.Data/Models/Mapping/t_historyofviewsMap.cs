using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YouBay.Data.Models.Mapping
{
    public class t_historyofviewsMap : EntityTypeConfiguration<t_historyofviews>
    {
        public t_historyofviewsMap()
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
            this.HasRequired(t => t.t_product)
                .WithMany(t => t.t_historyofviews)
                .HasForeignKey(d => d.productId);
            this.HasRequired(t => t.t_user)
                .WithMany(t => t.t_historyofviews)
                .HasForeignKey(d => d.buyerId);

        }
    }
}
