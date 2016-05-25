namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Garage2.DataAccessLayer.GarageContext context)
        {
            var members = new List<Member>
            {
            new Member{MemberNr = 1001,Name="Andreas Carsbring"},
            new Member{MemberNr = 1002,Name="Andreas Thyrhaug"},
            new Member{MemberNr = 1003,Name="Anette Tillbom"},
            new Member{MemberNr = 1004,Name="Ari Kylmänen"},
            new Member{MemberNr = 1005,Name="Aryo Pehlewan"},
            new Member{MemberNr = 1006,Name="Axel Räntilä"},
            new Member{MemberNr = 1007,Name="Bo Edström"},
            new Member{MemberNr = 1008,Name="Fernando Nilsson"},
            new Member{MemberNr = 1009,Name="Fredrik Lindroth"},
            new Member{MemberNr = 1010,Name="George Caspersson"},
            new Member{MemberNr = 1011,Name="Helen Magnusson"},
            new Member{MemberNr = 1012,Name="Johan Haak"},
            new Member{MemberNr = 1013,Name="John Castell"},
            new Member{MemberNr = 1014,Name="Karl Lindström"},
            new Member{MemberNr = 1015,Name="Lennart Skagerling"},
            new Member{MemberNr = 1016,Name="Marie Hansson"},
            new Member{MemberNr = 1017,Name="Mattias Karlsson"},
            new Member{MemberNr = 1018,Name="Michael Novak"},
            new Member{MemberNr = 1019,Name="Thomas J Ekman"},
            new Member{MemberNr = 1020,Name="Thomas Sundblom"},
            new Member{MemberNr = 1021,Name="Tomas Santana"},
            new Member{MemberNr = 1022,Name="Wasim Randhawa"},
            new Member{MemberNr = 1023,Name="Yaser Mosavi"},
            new Member{MemberNr = 1024,Name="Oscar Jakobsson"},
            };

            members.ForEach(m => context.Members.AddOrUpdate(m));
            context.SaveChanges();

            var vehicleTypes = new List<VehicleType>
            {
            new VehicleType{Type = "Bil"},
            new VehicleType{Type = "Buss"},
            new VehicleType{Type = "Motorcykel"},
            };
            vehicleTypes.ForEach(v => context.VehicleTypes.AddOrUpdate(v));
            context.SaveChanges();

            var c = 1;
            for (int i = 0; i < 4; i++)
            {
                //c = c + 1;
                context.Vehicles.AddOrUpdate(
                      v => v.RegNr,
                      
                      new Models.Vehicle { RegNr = "ABC12" + i, MemberId = c++, VehicleTypeId = 1, StartTime = DateTime.Now, EndTime = null, Brand = "Alfa Romeo", Model = "X1", Color = "Grå", TotalTime = null, Parked = true },
                      new Models.Vehicle { RegNr = "ASD12" + i, MemberId = c++, VehicleTypeId = 3, StartTime = DateTime.Now, EndTime = null, Brand = "Scania", Model = "Lathi Scala", Color = "Blå", TotalTime = null, Parked = true },
                      new Models.Vehicle { RegNr = "QWE12" + i, MemberId = c++, VehicleTypeId = 2, StartTime = DateTime.Now, EndTime = null, Brand = "Toyota", Model = "TY12", Color = "svart", TotalTime = null, Parked = true },
                      new Models.Vehicle { RegNr = "ZXC12" + i, MemberId = c++, VehicleTypeId = 1, StartTime = DateTime.Now, EndTime = null, Brand = "Audi", Model = "X7", Color = "Grå", TotalTime = null, Parked = true },
                      new Models.Vehicle { RegNr = "CTA13" + i, MemberId = c++, VehicleTypeId = 2, StartTime = DateTime.Now, EndTime = null, Brand = "Alfa Romeo", Model = "X1", Color = "Grå", TotalTime = null, Parked = true },
                      new Models.Vehicle { RegNr = "BPA40" + i, MemberId = c++, VehicleTypeId = 3, StartTime = DateTime.Now, EndTime = null, Brand = "Scania", Model = "Omnilink", Color = "Blå", TotalTime = null, Parked = true }
                    );
            }
        }
    }
}
