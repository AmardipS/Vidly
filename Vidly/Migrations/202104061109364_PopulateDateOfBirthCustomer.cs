namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDateOfBirthCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = '1/1/1990' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
