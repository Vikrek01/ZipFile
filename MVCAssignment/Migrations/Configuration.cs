namespace MVCAssignment.Migrations
{
    using MVCAssignment.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SH_MVCAssignment.Models.CategoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SH_MVCAssignment.Models.CategoryContext context)
        {
            if (!context.Categories.Any())
            {
                IList<Category> CategoryDetails = new List<Category>();

                CategoryDetails.Add(new Category() { CategoryName = "Music", CreatedOn = DateTime.Now });
                CategoryDetails.Add(new Category() { CategoryName = "Movies", CreatedOn = DateTime.Now });
                CategoryDetails.Add(new Category() { CategoryName = "Destination", CreatedOn = DateTime.Now });
                CategoryDetails.Add(new Category() { CategoryName = "Hill-Station", CreatedOn = DateTime.Now });
                CategoryDetails.Add(new Category() { CategoryName = "Clothes", CreatedOn = DateTime.Now });

                context.Categories.AddRange(CategoryDetails);
                base.Seed(context);
                context.SaveChanges();
            }
        }
    }
}
