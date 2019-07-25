namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Genres]([Id],[NameOfGenre])VALUES(1, 'Comedy')");
            Sql("INSERT INTO [dbo].[Genres]([Id],[NameOfGenre])VALUES(2, 'Thriller')");
            Sql("INSERT INTO [dbo].[Genres]([Id],[NameOfGenre])VALUES(3, 'Action')");
            Sql("INSERT INTO [dbo].[Genres]([Id],[NameOfGenre])VALUES(4, 'Sci-Fi')");
            Sql("INSERT INTO [dbo].[Genres]([Id],[NameOfGenre])VALUES(5, 'Horror')");
            Sql("INSERT INTO [dbo].[Genres]([Id],[NameOfGenre])VALUES(6, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
