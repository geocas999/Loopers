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

        [Display(Name = "Fordonstyp")]
        public VehicleType VehicleTypes { get; set; }

        //[Required]
        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }

        [Display(Name = "Parkering påbörjad")]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }
    }
    public enum VehicleType
    {
        [Display(Name = "Bil")]
        Car,
        [Display(Name = "Motorcykel")]
        MC,
        [Display(Name = "Buss")]
        Bus
    }
}