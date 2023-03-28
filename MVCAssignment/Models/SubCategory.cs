using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignment.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Please enter SubCategory Name.")]

        public string SubCategoryName { get; set;}
        public DateTime? createdOn { get; set; }
        public string CategoryName { get; set; }
        public virtual Category categories { get; set; }

    }
}