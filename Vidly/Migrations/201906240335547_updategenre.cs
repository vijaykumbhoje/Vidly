namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updategenre : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId=6 WHERE Id=4");
            Sql("UPDATE Movies SET GenreID=8 WHERE Id=2");
        
        }
        
        public override void Down()
        {
        }
    }
}
