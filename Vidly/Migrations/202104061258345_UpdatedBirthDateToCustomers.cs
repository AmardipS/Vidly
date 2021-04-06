namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBirthDateToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Customers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
