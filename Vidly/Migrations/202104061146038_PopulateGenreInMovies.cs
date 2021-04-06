namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET Genre = 'Adventure' WHERE Id = 1");
            Sql("UPDATE Movies SET Genre = 'Action' WHERE Id = 2");
            Sql("UPDATE Movies SET Genre = 'SciFi' WHERE Id = 3");
            Sql("UPDATE Movies SET Genre = 'Adventure' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
