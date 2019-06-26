namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingBirthdatemandatory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
        }
    }
}
