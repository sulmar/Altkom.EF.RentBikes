namespace Altkom.RentBikes.DAL.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Altkom.RentBikes.DAL.RentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Altkom.RentBikes.DAL.RentContext";
        }

        protected override void Seed(Altkom.RentBikes.DAL.RentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Bikes.AddOrUpdate(
                p => p.SerialNumber,
                    new Bike
                    {
                        SerialNumber = "R001",
                        BikeType = BikeTypes.City,
                        Status = Status.Ready,
                    },

                     new Bike
                     {
                         SerialNumber = "R002",
                         BikeType = BikeTypes.City,
                         Status = Status.Ready,
                     },


                      new Bike
                      {
                          SerialNumber = "R003",
                          BikeType = BikeTypes.City,
                          Status = Status.Ready,
                      },

                    new Bike
                    {
                        SerialNumber = "R004",
                        BikeType = BikeTypes.City,
                        Status = Status.Ready,
                    },

                    new Bike
                    {
                        SerialNumber = "R005",
                        BikeType = BikeTypes.City,
                        Status = Status.Ready,
                    }

                );
        }
    }
}
