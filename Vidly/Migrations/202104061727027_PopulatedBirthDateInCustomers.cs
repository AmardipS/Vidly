namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedBirthDateInCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '07/10/1989' WHERE Name = 'Rezma Stha'");
        }
        
        public override void Down()
        {
        }
    }
}
