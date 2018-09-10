using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManager.Models
{
    public class Refueling
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field quantity should be filled")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "The field price should be filled")]
        [PosNumberNoZero(ErrorMessage = "need a positive number, bigger than 0")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field current km should be felled")]
        public double CurrnetKilometers { get; set; }

        public int CarId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
