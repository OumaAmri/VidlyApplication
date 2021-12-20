namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Action')");
            Sql("INSERT INTO Genres(Name) VALUES('Romantic')");
            Sql("INSERT INTO Genres(Name) VALUES('Horor')");
            Sql("INSERT INTO Genres(Name) VALUES('Kids')");
        }
        
        public override void Down()
        {
        }
    }
}
