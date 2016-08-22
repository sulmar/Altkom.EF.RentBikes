namespace Altkom.RentBikes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        BikeId = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        BikeType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BikeId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Bike_BikeId = c.Int(),
                        FromStation_StationId = c.Int(),
                        Rentee_PersonId = c.Int(),
                        ToStation_StationId = c.Int(),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Bikes", t => t.Bike_BikeId)
                .ForeignKey("dbo.Stations", t => t.FromStation_StationId)
                .ForeignKey("dbo.People", t => t.Rentee_PersonId)
                .ForeignKey("dbo.Stations", t => t.ToStation_StationId)
                .Index(t => t.Bike_BikeId)
                .Index(t => t.FromStation_StationId)
                .Index(t => t.Rentee_PersonId)
                .Index(t => t.ToStation_StationId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Capacity = c.Byte(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "ToStation_StationId", "dbo.Stations");
            DropForeignKey("dbo.Rentals", "Rentee_PersonId", "dbo.People");
            DropForeignKey("dbo.Rentals", "FromStation_StationId", "dbo.Stations");
            DropForeignKey("dbo.Rentals", "Bike_BikeId", "dbo.Bikes");
            DropIndex("dbo.Rentals", new[] { "ToStation_StationId" });
            DropIndex("dbo.Rentals", new[] { "Rentee_PersonId" });
            DropIndex("dbo.Rentals", new[] { "FromStation_StationId" });
            DropIndex("dbo.Rentals", new[] { "Bike_BikeId" });
            DropTable("dbo.Stations");
            DropTable("dbo.Rentals");
            DropTable("dbo.People");
            DropTable("dbo.Bikes");
        }
    }
}
