using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YouBay.Data.Models.Mapping
{
    public class t_specialpromotionMap : EntityTypeConfiguration<t_specialpromotion>
    {
        public t_specialpromotionMap()
        {
            // Primary Key
            this.HasKey(t => t.specialPromotionId);

            // Properties
            this.Property(t => t.dealDescription)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("t_specialpromotion", "fusiondb");
            this.Property(t => t.specialPromotionId).HasColumnName("specialPromotionId");
            this.Property(t => t.dealDescription).HasColumnName("dealDescription");
            this.Property(t => t.dealDisabledByAdmin).HasColumnName("dealDisabledByAdmin");
            this.Property(t => t.endDate).HasColumnName("endDate");
            this.Property(t => t.reductionPercentage).HasColumnName("reductionPercentage");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.product_productId).HasColumnName("product_productId");

            // Relationships
            this.HasOptional(t => t.t_product)
                .WithMany(t => t.t_specialpromotion)
                .HasForeignKey(d => d.product_productId);

        }
    }
}
