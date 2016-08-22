using Altkom.RentBikes.DAL;
using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Altkom.RentBikes.ConsoleClient
{
    class Program
    {

        // C# 6.0
        static decimal Calculate2(Person person) => person.Balance * 1.2m;

        static decimal Calculate(Person person)
        {
            return person.Balance * 1.2m;

            
        }

        // C# 6.0
        static IQueryable<Station> MyQuery(RentContext context, string stationName) =>
            context.Stations
                .Where(s => s.Capacity > 5)
                .OrderBy(s=>s.Name);


        static IQueryable<Station> MyQuery2(RentContext context, string stationName)
        {
            return context.Stations
                .Where(s => s.Capacity > 5)
                .OrderBy(s => s.Name);
        }

            

        //static void Test<TContext>()
        //    where TContext : RentContext, new()
        //{
        //    using (var context = new TContext())
        //    {
        //        context.
        //    }

        //}




        static void Main(string[] args)
        {
            FindClosestStationTest();

            UpdateStationsLocation();

            SqlQueryProcedureTest();

            SqlProcedureTest();

            SqlQueryWithParameterTest();

            SqlQueryTest();

            SqlWithParametersTest2();

            SqlWithParametersTest();

            SqlTest();

            JoinTest();

            GetRentalsByColor();

            GetRentalsByStation();

            //var result =  Abs(10) * Sin(4);

            //AddRentalTest();

            //GroupByTest();

            //ProjectionTest();

            //SumTest();

            //CountTest();

            //  LinqTest();

            //   BatchUpdateTest();

            // DeleteStation();

            //   AttachTest();


            //  UpdateStation();

            // AddStations();

            //  AddPerson();

            // AddBike();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();


        }

        private static void FindClosestStationTest()
        {
            var currentLocation = DbGeography.FromText("POINT(53.34 18.43)");

            using (var context = new RentContext())
            {
                var station = context.Stations
                            .OrderBy(s => s.Location.Distance(currentLocation))
                            .Select(s => new { Name = s.Name, Distance = s.Location.Distance(currentLocation)})
                            .FirstOrDefault();

                //Console.WriteLine($"Najblizsza stacja rowera {station.Name} {station.Address}");
            }


        }

        private static void UpdateStationsLocation()
        {
            var currentLocation = DbGeography.FromText("POINT(53.32 18.43)");


            using (var context = new RentContext())
            {
                var stations = context.Stations.ToList();

                foreach (var station in stations)
                {
                    station.Location = currentLocation;
                }

                context.SaveChanges();
            }

        }

        private static void SqlQueryProcedureTest()
        {
            string color = "red";

            using (var context = new RentContext())
            {
                var colorParameter = new SqlParameter("@Color", color);

                var bikes = context.Database.SqlQuery<Bike>("uspGetBikesByColor @Color", colorParameter);

                foreach (var bike in bikes)
                {
                    Console.WriteLine(bike.SerialNumber);
                }

            }
        }

        private static void SqlProcedureTest()
        {
            var bikeId = 3;

            using (var context = new RentContext())
            {
                var bikeIdParameter = new SqlParameter("@BikeId", bikeId);

                context.Database.ExecuteSqlCommand("uspDeleteBike @BikeId", bikeIdParameter);

            }
        }

        private static void SqlQueryWithParameterTest()
        {
            var color = "red";

            var colorParameter = new SqlParameter("@Color", color);

            var sql = "SELECT * FROM Bikes WHERE Color = @Color";

            using (var context = new RentContext())
            {
                var bikes = context.Database.SqlQuery<Bike>(sql, colorParameter);

                foreach (var bike in bikes)
                {
                    Console.WriteLine(bike.SerialNumber);
                }

            }
        }



        private static void SqlQueryTest()
        {
            var sql = "SELECT * FROM Bikes WHERE Color = 'red'";

            using (var context = new RentContext())
            {
                var bikes = context.Database.SqlQuery<Bike>(sql);

                foreach (var bike in bikes)
                {
                    Console.WriteLine(bike.SerialNumber);
                }
               
            }
        }

        private static void SqlWithParametersTest2()
        {
            Console.Write("Podaj nazwę roweru ");

            var serialNumber = Console.ReadLine();

            var sql = $"UPDATE Bikes SET Color = 'Red' WHERE SerialNumber = @SerialNumber";

            using (var context = new RentContext())
            {
                var serialNumberParameter = new SqlParameter("@SerialNumber", serialNumber);

                var result = context.Database.ExecuteSqlCommand(sql, serialNumberParameter);

                Console.WriteLine($"{result} records affected.");
            }
        }

        // SQL Injection 
        private static void SqlWithParametersTest()
        {
            Console.Write("Podaj nazwę roweru ");

            var serialNumber = Console.ReadLine();

            var sql = $"UPDATE Bikes SET Color = 'Red' WHERE SerialNumber = '{serialNumber}'";

            using (var context = new RentContext())
            {
                var result = context.Database.ExecuteSqlCommand(sql);

                Console.WriteLine($"{result} records affected.");
            }
        }

        private static void SqlTest()
        {
            var sql = "UPDATE Bikes SET Color = 'Red' WHERE Color is null";

            using (var context = new RentContext())
            {
                var result = context.Database.ExecuteSqlCommand(sql);

                Console.WriteLine($"{result} records affected.");
            }
        }

        private static void Display(string message)
        {
            Console.WriteLine(message);
        }

        private static void JoinTest()
        {
            var stationName = "ST002";

            using (var context = new RentContext())
            {
                // context.Database.Log += Display;

//                context.Database.Log = message => Console.WriteLine(message);

                var result = from rental in context.Rentals
                             join bike in context.Bikes 
                                on rental.Bike.BikeId equals bike.BikeId
                             select new { rental, bike };

            }
        }

        private static void GetRentalsByColor()
        {
            var color = "red";


            // Wyswietl osoby (imie i nazwisko),
            // ktore wypozyczaly rowery w kolorze czerwonym


        }

        private static void GetRentalsByStation()
        {
            var stationName = "ST002";


            using (var context = new RentContext())
            {
                var rentals = context.Rentals
                    // .Include("Bike.Owner")
                    // .Include(p => p.Bike).Select(b => b.Rentee).Include(b => b.Address);
                    // .Include("Bike.Components")
                    .Include(p=>p.Bike)
                    .Include(p=>p.Rentee)
                    .Include(p=>p.FromStation)
                    .Where(r => r.FromStation.Name == stationName)
                    .ToList();
            }
        }

        private static void AddRentalTest()
        {
            Console.Write("Podaj numer telefonu: ");

            var phoneNumber = Console.ReadLine();
            var stationName = "ST002";

            using (var context = new RentContext())
            {
                var person = context.Persons
                    .SingleOrDefault(p => p.PhoneNumber == phoneNumber);

                var bike = context.Bikes
                    .Where(b => b.Status == Status.Ready)
                    .FirstOrDefault();

                //var bike = new Bike { BikeType = BikeTypes.Kids, SerialNumber = "R 099" };

                var station = context.Stations
                    .Single(s => s.Name == stationName);

                // var stations = MyQuery(context, "Spodek");

                if (person != null)
                {
                    Console.WriteLine($"Witaj {person.FullName3}!");
                }
                else
                {
                    Console.WriteLine("Brak numeru telefonu");
                }

                var rental = new Rental
                {
                    BeginDate = DateTime.Now,
                    FromStation = station,
                    Rentee = person,
                    Bike = bike,
                };

                context.Rentals.Add(rental);

                context.SaveChanges();
                
            }
        }

        private static void GroupByTest()
        {

            using (var context = new RentContext())
            {
                var query = context.Bikes
                    .GroupBy(b => b.Color)
                    .Select(g => new { Color = g.Key, Qty = g.Count() })
                    .ToList();

                var query2 = context.Bikes
                    .GroupBy(b => new { b.Color, b.Status })
                    .Select(g => new { g.Key, Qty = g.Count() })
                    .ToList();

            }


        }

        private static void ProjectionTest()
        {
            var context = new RentContext();

            var bikes = context.Bikes
                .Select(b=> b.SerialNumber)
                .ToList();

            var bikes2 = context.Bikes
              .Select(b => new { b.SerialNumber, b.Color })
              .ToList();

        }

        private static void SumTest()
        {
            var context = new RentContext();

            var summary = context.Persons.Sum(p => p.Balance);

            Console.WriteLine("saldo: {0}", summary);
        }

        private static void CountTest()
        {
            var context = new RentContext();

            var quantity = context.Bikes
                .Where(b => b.Color == "red")
                .Count();


            Console.WriteLine("ilosc rowerów: {0}", quantity);
                
        }

        private static void LinqTest()
        {
            var context = new RentContext();

            var blueBikes = context.Bikes
               .Where(bike => bike.Color == "Blue");

            var damagedBikes = context.Bikes
                .Where(bike => bike.Status == Status.Damaged);

            var servicedBikes = context.Bikes
              .Where(bike => bike.Status == Status.Serviced);

            var results = blueBikes.Except(damagedBikes);
            
            var results2 = damagedBikes.Union(servicedBikes);

            //var results = bikes
            //    .OrderBy(b => b.SerialNumber)
            //    .ToList();

            //Display(bikes.ToList());

        }

        private static void Display(List<Bike> bikes)
        {
            foreach (var bike in bikes)
            {
                Console.WriteLine(bike.SerialNumber);
            }
        }

        private static void BatchUpdateTest()
        {
            var context = new RentContext();

            var bikes = context.Bikes
                .Where(b=>string.IsNullOrEmpty(b.Color))
                .ToList();

            foreach (var bike in bikes)
            {
                bike.Color = "Blue";
            }

            context.SaveChanges();
        }

        private static void DeleteStation()
        {
            var context = new RentContext();

            var station = context.Stations.First();

            context.Stations.Remove(station);

            context.SaveChanges();
        }

        private static void AttachTest()
        {
            var context = new RentContext();

            var station = new Station
            {
                StationId = 400,
                Name = "Nowa",
                Address = "PKP Katowice"
            };

            context.Stations.Attach(station);

            Console.WriteLine(context.Entry(station).State);

            context.Entry(station).State = System.Data.Entity.EntityState.Modified;

            Console.WriteLine(context.Entry(station).Property(p => p.Address).IsModified);

            context.Entry(station).Property(p => p.Name).IsModified = false;
            context.Entry(station).Property(p => p.IsActive).IsModified = false;
            context.Entry(station).Property(p => p.Capacity).IsModified = false;
            context.Entry(station).Property(p => p.ModifiedDate).IsModified = false;

            context.SaveChanges();
        }

        private static void UpdateStation()
        {
            Console.Write("Podaj nazwę stacji: ");

            var stationName = Console.ReadLine();

            var context = new RentContext();

            var station = context.Stations
                .Where(s => s.Name == stationName)
                .FirstOrDefault();

            Console.WriteLine(context.Entry(station).State);

            if (station != null)
            {
                Console.WriteLine(station.Address);

                station.Address = "Andrzeja";

                Console.WriteLine(context.Entry(station).State);

                
                Console.WriteLine(context.Entry(station).Property(p => p.Address).IsModified);
                Console.WriteLine(context.Entry(station).Property(p => p.Name).IsModified);
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("Brak stacji");
            }

        }

        private static void AddStations()
        {

            var stations = new List<Station>
            {
                new Station
                {
                    Name = "ST001",
                    Address = "PKP",
                    Capacity = 10,
                    IsActive = true,
                },

                new Station
                {
                    Name = "ST002",
                    Address = "Spodek",
                    Capacity = 20,
                    IsActive = true,
                },

                new Station
                {
                    Name = "ST003",
                    Address = "Plac Andrzeja",
                    Capacity = 5,
                    IsActive = true,
                },
            };

            var context = new RentContext();
            context.Stations.AddRange(stations);

            context.SaveChanges();
        }

        private static void AddPerson()
        {
            var person = new Person
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                PhoneNumber = "555000111",
                Balance = 10,
            };

            var context = new RentContext();
            context.Persons.Add(person);

            context.SaveChanges();
        }

        private static void AddBike()
        {
            var bike = new Bike
            {
                SerialNumber = "R003",
                BikeType = BikeTypes.City,
                Status = Status.Ready,
            };

            var context = new RentContext();
            context.Bikes.Add(bike);

            context.SaveChanges();

            Console.WriteLine(bike.BikeId);



        }
    }
}
