using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UserCars = new List<Vehicle>();
        }

        [Required(ErrorMessage = "The field FullName shoud be filled")]
        [MinLength(2)]
        [MaxLength(50)]
        public string FullName { get; set; }

        public ICollection<Vehicle> UserCars { get; set; }
    }
}
