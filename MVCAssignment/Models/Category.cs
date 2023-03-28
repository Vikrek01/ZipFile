using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignment.Models
{

    public class Category
    {
      
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter CategoryName Name.")]
        public string CategoryName { get; set; }

        //[DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set;}

        public ICollection<SubCategory> SubCategories { get; set;}

    }
}