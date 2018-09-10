using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarManager.Data;
using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
using CarManager.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Web.Areas.LoggedUser.Controllers
{
    public class HomeController : LoggedUserController
    {
        private readonly CarManagerDbContext context;
        private readonly IMapper mapper;

        public HomeController(CarManagerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = Content(this.User.GetUserId()).Content.ToString();

            var vehicle = this.context.Vehicles.Where(c => c.UserId == userId).ToList();
            var model = this.mapper.Map<IEnumerable<CarConciseViewModel>>(vehicle);

            //var model = GetUserCars(userId);
            return View(model);
        }
    }
}