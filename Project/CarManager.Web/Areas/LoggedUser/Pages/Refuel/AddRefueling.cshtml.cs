using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using CarManager.Data;
using CarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManager.Web.Areas.LoggedUser.Pages.Vehicles
{
    public class AddRefuelingModel : PageModel
    {
        private readonly CarManagerDbContext context;
        private readonly IMapper mapper;

        public AddRefuelingModel(CarManagerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Vehicle Vehicle { get; set; }

        public IActionResult OnPost(int id)
        {
            var carId = id;
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var refueling = new Refueling()
            {
                Quantity = this.Quantity,
                Price = this.Price,
                CurrnetKilometers = this.CurrnetKilometers,
                CarId = carId
            };

            this.context.Refuelings.Add(refueling);
            this.context.SaveChanges();
            
            return RedirectToPage("Details");
        }

        [BindProperty]
        [Required]
        public double Quantity { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "The field price should be filled")]
        [PosNumberNoZero]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
    
        [Required]
        [BindProperty]
        public double CurrnetKilometers { get; set; }

        public int CarId { get; set; }
    }
}