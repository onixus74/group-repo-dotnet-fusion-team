using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YouBay.Data.Models.Mapping
{
    public class t_userMap : EntityTypeConfiguration<t_user>
    {
        public t_userMap()
        {
            // Primary Key
            this.HasKey(t => t.youBayUserId);

            // Properties
            this.Property(t => t.USER_TYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.countryOfResidence)
                .HasMaxLength(100);

            this.Property(t => t.email)
                .HasMaxLength(100);

            this.Property(t => t.emailActivationToken)
                .HasMaxLength(1000);

            this.Property(t => t.firstName)
                .HasMaxLength(100);

            this.Property(t => t.lastName)
                .HasMaxLength(100);

            this.Property(t => t.phoneNumber)
                .HasMaxLength(100);

            this.Property(t => t.sellerBadges)
                .HasMaxLength(1000);

            this.Property(t => t.sellerDescription)
                .HasMaxLength(1000);

            this.Property(t => t.sellerLogo)
                .HasMaxLength(1000);

            this.Property(t => t.addressCity)
                .HasMaxLength(200);

            this.Property(t => t.addressLine1)
                .HasMaxLength(200);

            this.Property(t => t.addressLine2)
                .HasMaxLength(200);

            this.Property(t => t.buyerBadges)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("t_user", "fusiondb");
            this.Property(t => t.USER_TYPE).HasColumnName("USER_TYPE");
            this.Property(t => t.youBayUserId).HasColumnName("youBayUserId");
            this.Property(t => t.birthday).HasColumnName("birthday");
            this.Property(t => t.countryOfResidence).HasColumnName("countryOfResidence");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.emailActivationToken).HasColumnName("emailActivationToken");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.isActive).HasColumnName("isActive");
            this.Property(t => t.isBanned).HasColumnName("isBanned");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
            this.Property(t => t.complaintPercentage).HasColumnName("complaintPercentage");
            this.Property(t => t.gamificationScore).HasColumnName("gamificationScore");
            this.Property(t => t.sellerBadges).HasColumnName("sellerBadges");
            this.Property(t => t.sellerDescription).HasColumnName("sellerDescription");
            this.Property(t => t.sellerIsSuspiciousFlag).HasColumnName("sellerIsSuspiciousFlag");
            this.Property(t => t.sellerLogo).HasColumnName("sellerLogo");
            this.Property(t => t.totalSales).HasColumnName("totalSales");
            this.Property(t => t.canAddAdvertisement).HasColumnName("canAddAdvertisement");
            this.Property(t => t.canExportData).HasColumnName("canExportData");
            this.Property(t => t.canManageCategories).HasColumnName("canManageCategories");
            this.Property(t => t.canManageManagers).HasColumnName("canManageManagers");
            this.Property(t => t.canModerateSellersAndBuyers).HasColumnName("canModerateSellersAndBuyers");
            this.Property(t => t.accountBalance).HasColumnName("accountBalance");
            this.Property(t => t.addressCity).HasColumnName("addressCity");
            this.Property(t => t.addressLine1).HasColumnName("addressLine1");
            this.Property(t => t.addressLine2).HasColumnName("addressLine2");
            this.Property(t => t.buyerBadges).HasColumnName("buyerBadges");
            this.Property(t => t.iSMale).HasColumnName("iSMale");
            this.Property(t => t.totalSpending).HasColumnName("totalSpending");
            this.Property(t => t.customizedAds_customizedAdsId).HasColumnName("customizedAds_customizedAdsId");

            // Relationships
            this.HasOptional(t => t.t_customizedads)
                .WithMany(t => t.t_user)
                .HasForeignKey(d => d.customizedAds_customizedAdsId);

        }
    }
}
