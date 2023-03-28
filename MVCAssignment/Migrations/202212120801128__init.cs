namespace MVCAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(nullable: false),
                        createdOn = c.DateTime(),
                        CategoryName = c.String(),
                        categories_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.categories_CategoryId)
                .Index(t => t.categories_CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        CategoryName = c.String(),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreadtedDate = c.DateTime(),
                        SubCategoryName = c.String(),
                        SubCategories_SubCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategories_SubCategoryId)
                .Index(t => t.SubCategories_SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategories_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "categories_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "SubCategories_SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "categories_CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
        }
    }
}
