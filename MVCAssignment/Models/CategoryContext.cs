using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SH_MVCAssignment.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("MyConnection")
        {
           
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}