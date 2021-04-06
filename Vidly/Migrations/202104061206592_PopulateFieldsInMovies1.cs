namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFieldsInMovies1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET DateAdded = '12/12/2020'");
            Sql("UPDATE Movies SET NrInStock = 5 WHERE Name = 'Avatar'");
           
        }
        
        public override void Down()
        {
        }
    }
}
