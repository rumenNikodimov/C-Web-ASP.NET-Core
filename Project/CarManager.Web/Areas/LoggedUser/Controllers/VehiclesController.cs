//using AutoMapper;
//using CarManager.Data;
//using CarManager.Models;
//using CarManager.Web.Areas.LoggedUser.Models.BindingModels;
//using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
//using CarManager.Web.Common;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CarManager.Web.Areas.LoggedUser.Controllers
//{
//    public class VehiclesController : LoggedUserController
//    {
//        private readonly CarManagerDbContext context;
//        private readonly IMapper mapper;

//        public VehiclesController(CarManagerDbContext context, IMapper mapper)
//        {
//            this.context = context;
//            this.mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        public int CarId { get; set; }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            var userId = Content(this.User.GetUserId()).Content.ToString();

//            var vehicle = this.context.Vehicles.Where(c => c.UserId == userId).ToList();
//            var model = this.mapper.Map<IEnumerable<CarConciseViewModel>>(vehicle);
//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateCarBindingModel model)
//        {
//            var userId = Content(this.User.GetUserId()).Content.ToString();
//            model.UserId = userId;
//            if (!ModelState.IsValid)
//            {
//                return View();
//            }

//            var car = this.mapper.Map<Vehicle>(model);


//            await this.context.Vehicles.AddAsync(car);
//            context.SaveChanges();

//            var carId = car.Id;
//            return RedirectToAction("Details", new { id = carId });
//        }

//        [HttpGet]
//        public async Task<IActionResult> Details(int id)
//        {
//            var vehicle = await this.context.Vehicles
//                .FirstOrDefaultAsync(c => c.Id == id);
//            var model = this.mapper.Map<CarDetailsViewModel>(vehicle);
//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit(int id)
//        {
//            var currentCar = await context.Vehicles.FirstOrDefaultAsync(c => c.Id == id);
//            if (currentCar == null)
//            {
//                return NotFound();
//            }

//            var car = mapper.Map<EditCarBindingModel>(currentCar);

//            return View(car);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(EditCarBindingModel model)
//        {
//            var currentCar = await context.Vehicles.FirstOrDefaultAsync(c => c.Id == model.Id);

//            var userId = Content(this.User.GetUserId()).Content.ToString();
//            model.UserId = userId;
//            if (!ModelState.IsValid)
//            {
//                return View();
//            }

//            currentCar.Make = model.Make;
//            currentCar.Modification = model.Modification;
//            currentCar.ImageUrl = model.ImageUrl;
//            currentCar.FirstRegistrationDate = model.FirstRegistrationDate;
//            currentCar.HorsePower = model.HorsePower;
//            currentCar.Kilometers = model.Kilometers;
//            currentCar.Id = model.Id;
//            currentCar.UserId = model.UserId;

//            await this.context.SaveChangesAsync();

//            return RedirectToAction("Details", new { id = model.Id });
//        }
//    }
//}









using CarManager.Web.Areas.LoggedUser.Models.BindingModels;
using CarManager.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CarManager.Services.LoggedUser.Interfaces;
using CarManager.Data;
using AutoMapper;
using CarManager.Models;
using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CarManager.Web.Areas.LoggedUser.Controllers
{
    public class VehiclesController : LoggedUserController
    {
        private readonly ILoggedUserVehiclesService vehiclesService;

        public VehiclesController(ILoggedUserVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = Content(this.User.GetUserId()).Content.ToString();
            var model = this.vehiclesService.GetUserCars(userId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarBindingModel model)
        {
            var userId = Content(this.User.GetUserId()).Content.ToString();
            model.UserId = userId;
            if (!ModelState.IsValid)
            {
                return View();
            }
            var car = await this.vehiclesService.CreateAndSaveCar(model);

            return RedirectToAction("Details", new { id = car.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.vehiclesService.GetCarDetails(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await this.vehiclesService.GetEditModel(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarBindingModel model)
        {
            var userId = Content(this.User.GetUserId()).Content.ToString();
            model.UserId = userId;
            if (!ModelState.IsValid)
            {
                return View();
            }
            await this.vehiclesService.EditAndSave(model);
            return RedirectToAction("Details", new { id = model.Id });
        }
    }
}

