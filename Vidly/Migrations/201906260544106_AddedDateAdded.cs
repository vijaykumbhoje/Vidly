namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateCreated");
        }
    }
}
