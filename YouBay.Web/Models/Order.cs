using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouBay.Web.Models;

namespace YouBay.Web.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}