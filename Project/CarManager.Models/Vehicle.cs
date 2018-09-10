using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Refuelings = new List<Refueling>();
            this.ServiceHistory = new List<ServiceData>();
            this.Taxes = new List<VehicleTax>();
        }

        public int Id { get; set; }

        //[Required]
        //public VehicleType Type { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Make { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Modification { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FirstRegistrationDate { get; set; }

        public int HorsePower { get; set; }

        [Required]
        public double Kilometers { get; set; }

        public ICollection<ServiceData> ServiceHistory { get; set; }

        public ICollection<Refueling> Refuelings { get; set; }

        public ICollection<VehicleTax> Taxes { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        //public double AverageConsumpion(double km, ICollection<Refueling> refuelings)
        //{
        //    double totalFuel = refuelings.Sum();
        //    return 
        //}
    }
}
