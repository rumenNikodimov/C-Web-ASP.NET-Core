using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarManager.Data;
using CarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManager.Web.Areas.LoggedUser.Pages.Vehicles
{
    public class AddTaxModel : PageModel
    {
        private readonly CarManagerDbContext context;

        public AddTaxModel(CarManagerDbContext context)
        {
            this.context = context;
        }

        public Vehicle Vehicle { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {

            //var tax1 = this.Tax;
            
            //var nameOfTax = context.TaxNames.FirstOrDefault(t => t.Id == this.Tax.Id).Name;

            //var carId = id;

            //var tax = new VehicleTax()
            //{
            //    Name = new TaxName { Id = Tax.Id, Name = nameOfTax },
            //    ExpireDate = this.ExpireDate,
            //    VeihleId = carId
            //};

            //this.context.VehicleTaxes.Add(tax);
            //this.context.SaveChanges();

            return RedirectToPage("Details");
        }

        //CivilLiability
        //Vignette
        //TechnicalTest

      
        public TaxName Tax { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public int IdOfTax { get; set; }
    }
}