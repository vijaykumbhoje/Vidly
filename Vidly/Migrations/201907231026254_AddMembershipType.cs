namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[MembershipTypes] ([Id],[NameofSubscription],[SignupFees],[DurationInMonths],[Discount])VALUES (1,'Pay as you Go!', 0, 0, 0)");
            Sql("INSERT INTO [dbo].[MembershipTypes] ([Id],[NameofSubscription],[SignupFees],[DurationInMonths],[Discount])VALUES (2,'Monthly', 30, 1, 10)");
            Sql("INSERT INTO [dbo].[MembershipTypes] ([Id],[NameofSubscription],[SignupFees],[DurationInMonths],[Discount])VALUES (3,'Quarterly', 90, 3, 15)");
            Sql("INSERT INTO [dbo].[MembershipTypes] ([Id],[NameofSubscription],[SignupFees],[DurationInMonths],[Discount])VALUES (4,'Yearly', 300, 12, 20)");
        }
        
        public override void Down() 
        {
        }
    }
}
