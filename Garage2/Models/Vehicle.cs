using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleType VehicleTypes { get; set; }
        public string RegNr { get; set; }
        public string ParkingTime { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
    public enum VehicleType
    {

    }
}