using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignment.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter Product Name.")]

        public string ProductName { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please enter ProductPrice.")]

        public decimal ProductPrice { get; set;}
        public DateTime? CreadtedDate { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public virtual SubCategory SubCategories { get; set; }
    }
}