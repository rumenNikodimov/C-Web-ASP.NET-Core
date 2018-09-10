using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarManager.Models
{
    public class ServiceData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRepair { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        public double CurrentKilometers { get; set; }

        [Required]
        public double ExpireKilometers { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public int CarId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
