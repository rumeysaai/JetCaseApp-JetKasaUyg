namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductName_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductName_Id" });
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ProductName", c => c.String());
            DropColumn("dbo.Orders", "ProductName_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductName_Id", c => c.Int());
            DropColumn("dbo.Orders", "ProductName");
            DropColumn("dbo.Orders", "ProductId");
            CreateIndex("dbo.Orders", "ProductName_Id");
            AddForeignKey("dbo.Orders", "ProductName_Id", "dbo.Products", "Id");
        }
    }
}
