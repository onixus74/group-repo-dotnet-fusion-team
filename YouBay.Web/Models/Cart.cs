using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouBay.Web.Models;

namespace YouBay.Web.Models
{
    public class Cart
    {
        public Cart()
        {

        }
        public int CartId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //public virtual ICollection<ListCart> ListCarts { get; set; }

    }
}