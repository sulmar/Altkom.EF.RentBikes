namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRental : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "BeginDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Rentals", "EndDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Rentals", "BeginDate", c => c.DateTime(nullable: false));
        }
    }
}
