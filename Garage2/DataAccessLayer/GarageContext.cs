using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Garage2.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("GarageDb")
        {
            
        }

        public DbSet<Models.Vehicle> Vehicles { get; set; }
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }
        //public DbSet<Models.VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

   
}