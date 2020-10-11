using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KytsiKalku.Models
{
    public class FuelData
    {
        public int Id { get; set; }



        [Display(Name = "Driving destination from start to end")]
        [Required]
        public string TripName { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DriveDate { get; set; }

        [Display(Name = "Initial mileage")]
        [Required]
        public int TripStart { get; set; }
        [Display(Name = "Final mileage")]
        [Required]
        public int TripEnd { get; set; }
    }
}