namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAvailableStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "IsAvailable");
            Sql("Update Movies Set AvailableStock=Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
