using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarManager.Data;
using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManager.Web.Areas.LoggedUser.Pages.Vehicles
{
    public class DeleteModel : PageModel
    {
        private readonly CarManagerDbContext context;
        private readonly IMapper mapper;

        public DeleteModel(CarManagerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void OnGet(int id)
        {
            var vehicle = this.context.Vehicles.FirstOrDefault(c => c.Id == id);

            var model = this.mapper.Map<CarConciseViewModel>(vehicle);

            //var model = new DeleteModel()
            //{
            //    Make = vehicle.Make,
            //    Modification = vehicle.Modification,
            //    Id = vehicle.Id
            //};

            RedirectToPage(model);
        }

        public IActionResult OnPost(int id)
        {
            var vehicle = this.context.Vehicles
                            .FirstOrDefault(c => c.Id == id);

            this.context.Vehicles.Remove(vehicle);
            this.context.SaveChanges();

            return RedirectToPage("DeleteDetails");
        }

        public int Id { get; set; }


        public string Make { get; set; }


        public string Modification { get; set; }
    }
}
