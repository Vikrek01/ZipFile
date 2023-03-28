using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAssignment.Models
{
    public class InsertRequest
    {
        [Required(ErrorMessage = "Please enter CategoryName Name.")]

        public string CategoryName { get; set; }
    }
}
