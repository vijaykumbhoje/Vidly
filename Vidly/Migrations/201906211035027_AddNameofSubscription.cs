namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameofSubscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "NameofSubscription", c => c.String());
            Sql("UPDATE MembershipTypes SET NameofSubscription='Pay as you GO!' WHERE ID=1");
            Sql("UPDATE MembershipTypes SET NameofSubscription='Monthly' WHERE ID=2");
            Sql("UPDATE MembershipTypes SET NameofSubscription='Quarterly' WHERE ID=3");
            Sql("UPDATE MembershipTypes SET NameofSubscription='Anually' WHERE ID=4");

        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "NameofSubscription");
        }
    }
}
