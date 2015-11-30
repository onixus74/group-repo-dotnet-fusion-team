using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using YouBay.Domain.Entities;

namespace YouBay.Data.Models.Mapping
{
    public class ManagerMap : EntityTypeConfiguration<Manager>
    {
        public ManagerMap():base()
        {
            
            /*child class attributes */
            this.Property(t => t.canAddAdvertisement).HasColumnName("canAddAdvertisement");
            this.Property(t => t.canExportData).HasColumnName("canExportData");
            this.Property(t => t.canManageCategories).HasColumnName("canManageCategories");
            this.Property(t => t.canManageManagers).HasColumnName("canManageManagers");
            this.Property(t => t.canModerateSellersAndBuyers).HasColumnName("canModerateSellersAndBuyers");

        }
    }
}
