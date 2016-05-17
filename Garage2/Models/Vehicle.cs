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

        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}", ErrorMessage = "Ange 3 versala bokstäver och 3 siffror")]
        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }

        [Required]
        [Display(Name = "Fordonstyp")]
        public VehicleType VehicleType { get; set; }

        [Required]
        [Display(Name = "Parkering påbörjad")]
        public DateTime StartTime { get; set; }


        [Display(Name = "Parkering avslutad")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Total parkeringstid")]
        public TimeSpan? TotalTime { get; set; }

        [Display(Name = "Parkerad")]
        public bool Parked { get; set; }
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