namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class AddLocationToStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "Location", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stations", "Location");
        }
    }
}
