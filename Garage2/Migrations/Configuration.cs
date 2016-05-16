namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Garage2.DataAccessLayer.GarageContext context)
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

            //context.Vehicles.AddOrUpdate(
            //  v => v.RegNr,
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Volvo", Model = "V70", Color = "Silver", RegNr = "ABC123", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Volvo", Model = "V50", Color = "White", RegNr = "BCE323", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Volvo", Model = "S80", Color = "Red", RegNr = "BCD456", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Saab", Model = "95 Kombi", Color = "Black", RegNr = "CEC198", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Saab", Model = "95 Sedan", Color = "Green", RegNr = "DEW376", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Toyota", Model = "Celica", Color = "White", RegNr = "EEW171", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Car, Brand = "Nissan", Model = "Micra", Color = "Green", RegNr = "FAB173", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.MC, Brand = "Honda", Model = "Sport", Color = "Black", RegNr = "FTY493", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.MC, Brand = "Yamaha", Model = "Fighter", Color = "Blue", RegNr = "GHX843", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.MC, Brand = "Kawasaki", Model = "Hyper", Color = "Black", RegNr = "JYT459", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Bus, Brand = "Volvo", Model = "7900", Color = "Blue", RegNr = "HQW473", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Bus, Brand = "Volvo", Model = "8900", Color = "Red", RegNr = "KTR472", StartTime = DateTime.Now },
            //  new Vehicle { VehicleType = VehicleType.Bus, Brand = "Volvo", Model = "Sport", Color = "Blue", RegNr = "LEW321", StartTime = DateTime.Now }
            //  );
        }
    }
}
