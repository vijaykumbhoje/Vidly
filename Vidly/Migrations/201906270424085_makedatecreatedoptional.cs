namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makedatecreatedoptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
