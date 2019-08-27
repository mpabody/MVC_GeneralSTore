using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_GeneralStore.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set;}

        [Required]
        [Display (Name="Product Name")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display (Name="# in stock")]
        public int InventoryCount { get; set; }

        [Required]
        [Display (Name="It Is Food")]
        public bool IsFood { get; set; }
    }
}