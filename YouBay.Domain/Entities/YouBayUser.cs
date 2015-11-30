using System;
using System.Collections.Generic;

namespace YouBay.Domain.Entities
{
    public  class YouBayUser
    {
        public YouBayUser()
        {
        }

        public string USER_TYPE;//discriminator

        public long youBayUserId { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string countryOfResidence { get; set; }
        public string email { get; set; }
        public string emailActivationToken { get; set; }
        public string firstName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isBanned { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
    }
}
