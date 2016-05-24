namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.Models;
    using DataAccessLayer;
    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GarageContext context)
        {
            Member[] members = SeedMembers(context);
            VehicleType[] vehicleTypes = SeedVehicleTypes(context);
            
            //for (int i = 0; i < 7; i++)
            //{
                context.Vehicles.AddOrUpdate(
                      v => v.RegNr,
                      new Vehicle { RegNr = "ATA131", MemberId = 1, VehicleTypeId = 1, StartTime = DateTime.Now, EndTime = null, Brand = "Alfa Romeo", Model = "X1", Color = "Grå", TotalTime = null, Parked = true },
                      new Vehicle { RegNr = "BPQ242", MemberId = 2, VehicleTypeId = 1, StartTime = DateTime.Now, EndTime = null, Brand = "Alfa Romeo", Model = "X1", Color = "Grå", TotalTime = null, Parked = true },
                      new Vehicle { RegNr = "BPA403", MemberId = 3, VehicleTypeId = 3, StartTime = DateTime.Now, EndTime = null, Brand = "Scania", Model = "SX07", Color = "Blå", TotalTime = null, Parked = true },
                      new Vehicle { RegNr = "XVE324", MemberId = 4, VehicleTypeId = 1, StartTime = DateTime.Now, EndTime = null, Brand = "Toyota", Model = "TY12", Color = "svart", TotalTime = null, Parked = true },
                      new Vehicle { RegNr = "GSI925", MemberId = 5, VehicleTypeId = 1, StartTime = DateTime.Now, EndTime = null, Brand = "Audi", Model = "X2", Color = "Grå", TotalTime = null, Parked = true },
                      new Vehicle { RegNr = "KGK686", MemberId = 6, VehicleTypeId = 2, StartTime = DateTime.Now, EndTime = null, Brand = "Volkswagen", Model = "SX08", Color = "Red", TotalTime = null, Parked = true },
                      new Vehicle { RegNr = "OPE017", MemberId = 7, VehicleTypeId = 2, StartTime = DateTime.Now, EndTime = null, Brand = "BMV", Model = "TX99", Color = "Grön", TotalTime = null, Parked = true }
                    );
            //}

        }

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

        private static Member[] SeedMembers(GarageContext context)
        {
            Member[] members = new[] {
                new Member { MemberNr = 1000, Name="Kalle Anka" },
                new Member { MemberNr = 1001, Name="Kajsa Anka" },
                new Member { MemberNr = 1002, Name="Joakim von Anka" },
                new Member { MemberNr = 1003, Name="Musse Pigg" },
                new Member { MemberNr = 1004, Name="Fantomen" },
                new Member { MemberNr = 1005, Name="Guran" },
                new Member { MemberNr = 1006, Name="Lille Lozano" }
            };
            context.Members.AddOrUpdate(m => m.MemberNr, members);
            context.SaveChanges();
            return members;
        }


        private static VehicleType[] SeedVehicleTypes(GarageContext context)
        {
            VehicleType[] vehicleTypes = new[] {
                new VehicleType {  Type = "Bil" },
                new VehicleType {  Type = "Buss" },
                new VehicleType {  Type = "MC" }
            };
            context.VehicleTypes.AddOrUpdate(v => v.Type, vehicleTypes);
            context.SaveChanges();
            return vehicleTypes;
        }
    }
}

