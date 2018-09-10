using System;
using System.ComponentModel.DataAnnotations;

namespace CarManager.Web.Areas.LoggedUser.Models.BindingModels
{
    public class EditCarBindingModel
    {
        [Required]
        [Display(Name = "Make")]
        [StringLength(30, MinimumLength = 2)]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(30, MinimumLength = 1)]
        public string Modification { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of registration")]
        public DateTime FirstRegistrationDate { get; set; }

        [Required]
        [Display(Name = "Horse Power")]
        public int HorsePower { get; set; }

        [Required]
        [Display(Name = "Current Kilometers")]
        public double Kilometers { get; set; }

        public int Id { get; set; }

        public string UserId { get; set; }
    }
}
