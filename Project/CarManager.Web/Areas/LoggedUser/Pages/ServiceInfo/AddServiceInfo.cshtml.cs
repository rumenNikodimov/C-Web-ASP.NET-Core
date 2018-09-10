using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarManager.Data;
using CarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarManager.Web.Areas.LoggedUser.Pages.Vehicles
{
    public class AddServiceInfoModel : PageModel
    {
        private readonly CarManagerDbContext context;
        private readonly IMapper mapper;

        public AddServiceInfoModel(CarManagerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var carId = id;
            var model = new ServiceData()
            {
                Name = this.Name,
                Price = this.Price,
                DateOfRepair = this.DateOfRepair,
                ExpireDate = this.ExpireDate,
                CurrentKilometers = this.CurrentKilometers,
                ExpireKilometers = this.ExpireKilometers,
                Description = this.Description,
                CarId = id
            };

            //var unit = await mapper.Map<ServiceData>(model);

            await context.ServiceDatas.AddAsync(model);
            return RedirectToPage("Details");
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime DateOfRepair { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [BindProperty]
        public double CurrentKilometers { get; set; }

        [BindProperty]
        [Required]
        public double ExpireKilometers { get; set; }

        [BindProperty]
        [MaxLength(250)]
        public string Description { get; set; }

        public int CarId { get; set; }


    }
}