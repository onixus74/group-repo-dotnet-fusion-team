using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBay.Domain.Entities
{
    public class Manager : YouBayUser
    {

        public Nullable<bool> canAddAdvertisement { get; set; }
        public Nullable<bool> canExportData { get; set; }
        public Nullable<bool> canManageCategories { get; set; }
        public Nullable<bool> canManageManagers { get; set; }
        public Nullable<bool> canModerateSellersAndBuyers { get; set; }

        Manager() : base()
        {

        }

    }
}
