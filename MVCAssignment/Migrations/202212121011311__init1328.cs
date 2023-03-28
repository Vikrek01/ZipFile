namespace MVCAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init1328 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "SubCategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "SubCategoryName", c => c.String());
            AlterColumn("dbo.Products", "CategoryName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
