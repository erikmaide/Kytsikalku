using System;
using System.ComponentModel.DataAnnotations;

namespace KytsiKalku.Models
{
    public class FuelData
    {
        public int Id { get; set; }
        public string TripName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DriveDate { get; set; }
        public int TripStart { get; set; }
        public int TripEnd { get; set; }
    }
}