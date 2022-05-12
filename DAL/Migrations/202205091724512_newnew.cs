namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UnitPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UnitPrice");
        }
    }
}
