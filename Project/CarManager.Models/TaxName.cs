using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public class TaxName
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
