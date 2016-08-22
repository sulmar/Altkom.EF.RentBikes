namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBike : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bikes", "SerialNumber", c => c.String(nullable: false, maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "SerialNumber", c => c.String());
        }
    }
}
