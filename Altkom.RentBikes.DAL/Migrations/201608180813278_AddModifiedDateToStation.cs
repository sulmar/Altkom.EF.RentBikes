namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifiedDateToStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "ModifiedDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stations", "ModifiedDate");
        }
    }
}
