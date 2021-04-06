namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFieldsInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate = '12/12/2009' WHERE Name = 'Avatar'");
            Sql("UPDATE Movies SET ReleaseDate = '2/10/1998' WHERE Name = 'The Negotiator'");
            Sql("UPDATE Movies SET ReleaseDate = '1/12/2019' WHERE Name = 'Jumanji'");
            Sql("UPDATE Movies SET ReleaseDate = '1/02/2003' WHERE Name = 'Sanctum'");

        }

        public override void Down()
        {
        }
    }
}
