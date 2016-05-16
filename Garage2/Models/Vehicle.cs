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
        public VehicleType VehicleType { get; set; }

        [Required]
        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }

        [Display(Name = "Parkering påbörjad")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Parkering avslutad")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Total parkeringstid")]
        public DateTime? TotalTime { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }
    }
    public enum VehicleType
    {
        //[Display(Name = "Bil")]
        Bil,
        //[Display(Name = "Motorcykel")]
        Motorcykel,
        //[Display(Name = "Buss")]
        Buss
    }
}