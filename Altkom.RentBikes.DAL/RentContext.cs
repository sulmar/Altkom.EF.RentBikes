using Altkom.RentBikes.DAL.Configurations;
using Altkom.RentBikes.DAL.Conventions;
using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.DAL
{
    public class RentContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public RentContext()
            : base("RentDbConnection")
        {
            this.Database.Log = message => Console.WriteLine(message);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BikeConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new RentalConfiguration());

            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Conventions.Add(new KeyConvention());

            //modelBuilder.Entity<Bike>()
            //    .Property(p => p.SerialNumber)
            //    .HasMaxLength(10)
            //    .IsUnicode(false)
            //    .IsRequired();

            //modelBuilder.Entity<Person>()
            //    .ToTable("Persons");


            //modelBuilder.Entity<Person>()
            //    .Property(p => p.FirstName)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Person>()
            //    .Property(p => p.LastName)
            //    .HasMaxLength(50);


        }



    }
}
