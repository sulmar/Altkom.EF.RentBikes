namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorToBike : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "Color", c => c.String());

            Sql("UPDATE dbo.Bikes SET Color = 'Red';");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bikes", "Color");
        }
    }
}
