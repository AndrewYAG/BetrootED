namespace EntityFrameworkHW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            AddColumn("dbo.Orders", "Product_Id", c => c.Guid());
            CreateIndex("dbo.Orders", "Product_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Products", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_Id", c => c.Guid());
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropColumn("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
