using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YouBay.Domain.Entities;

namespace YouBay.Web.Models
{
    public class CartContainer
    {
        public int CartContainerId { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [Display(Name = "Unit")]
        public int Quantity { get; set; }

    }
}