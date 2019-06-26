namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmoviews : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, DateAdded, Stock, GenreId, DateReleased)VALUES('Hangover', GETDATE(), 10, 5, Cast('11-07-2013' AS DATE))");
            Sql("INSERT INTO Movies(Name, DateAdded, Stock, GenreId, DateReleased)VALUES('Mine Camf', GETDATE(), 10, 5, Cast('01-07-2012' AS DATE))");
            Sql("INSERT INTO Movies(Name, DateAdded, Stock, GenreId, DateReleased)VALUES('Dark Knight', GETDATE(), 10, 5, Cast('11-07-2013' AS DATE))");
            Sql("INSERT INTO Movies(Name, DateAdded, Stock, GenreId, DateReleased)VALUES('Mission Impossible', GETDATE(), 10, 5, Cast('11-07-2013' AS DATE))");
        }
        
        public override void Down()
        {
        }
    }
}
