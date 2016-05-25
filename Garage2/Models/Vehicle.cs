using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Garage2.Models
{
    public class Vehicle
    {

        public int Id { get; set; }

        [Required( ErrorMessage = "Registreringsnummer är obligatoriskt!") ]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Ange 3 versala bokstäver och 3 siffror")]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}", ErrorMessage = "Ange 3 versala bokstäver och 3 siffror")]
        [Remote("CheckIfParked", "Index", ErrorMessage = "Registreringsnumret finns redan som parkerad i registret!")]
        [Display(Name = "Registreringsnummer")]
        public string RegNr { get; set; }

        [Display(Name = "Medlemsnummer")]
        public int MemberId { get; set; }

        [Display(Name = "Fordonstyp")]
        public int VehicleTypeId { get; set; }

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

        public virtual Member Member { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }

    //public enum VehicleType
    //{
    //    Bil,
    //    Buss,
    //    Motorcykel
        
    //}
}