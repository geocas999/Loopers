using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        [Required]
        public string RegNr { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
    public enum VehicleType
    {
        Car,
        MC,
        Bus
    }
}