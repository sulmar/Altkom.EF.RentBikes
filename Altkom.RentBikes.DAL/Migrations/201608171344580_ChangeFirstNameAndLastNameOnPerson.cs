namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFirstNameAndLastNameOnPerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persons", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persons", "LastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persons", "LastName", c => c.String());
            AlterColumn("dbo.Persons", "FirstName", c => c.String());
        }
    }
}
