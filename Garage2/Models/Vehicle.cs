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

        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }

        [Display(Name = "Parkeringstid påbörjad")]
        public DateTime ParkingTimeStart { get; set; }

        [Display(Name = "Parkeringstid avlsutad")]
        public DateTime ParkingTimeEnd { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }
    }
    public enum VehicleType
    {
        Car,
        MC,
        Bus
    }
}