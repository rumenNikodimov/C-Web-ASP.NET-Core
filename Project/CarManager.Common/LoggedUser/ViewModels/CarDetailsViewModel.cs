using System;

namespace CarManager.Web.Areas.LoggedUser.Models.ViewModels
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Modification { get; set; }

        public int HorsePower { get; set; }

        public DateTime FirstRegistrationDate { get; set; }

        public int Kilometers { get; set; }
    }
}
