using System;
using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public class VehicleTax
    {
        public int Id { get; set; }

        [Required]
        public TaxName Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        public int VeihleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}