namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFieldsInMovies2 : DbMigration
    {
        public override void Up()
        {

            Sql("UPDATE Movies SET NrInStock = 7 WHERE Name = 'The Negotiator'");
            Sql("UPDATE Movies SET NrInStock = 10 WHERE Name = 'Jumanji'");
            Sql("UPDATE Movies SET NrInStock = 17 WHERE Name = 'Sanctum'");
        }

        public override void Down()
        {
        }
    }
}
