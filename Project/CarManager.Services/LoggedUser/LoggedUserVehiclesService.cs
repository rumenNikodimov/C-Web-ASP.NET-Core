using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarManager.Data;
using CarManager.Models;
using CarManager.Services.LoggedUser.Interfaces;
using CarManager.Web.Areas.LoggedUser.Models.BindingModels;
using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManager.Services.LoggedUser
{
    public class LoggedUserVehiclesService : BaseEFService, ILoggedUserVehiclesService
    {
        public LoggedUserVehiclesService(CarManagerDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<CarConciseViewModel> GetUserCars(string userId)
        {
            var vehicle = this.DbContext.Vehicles.Where(c => c.UserId == userId).ToList();
            var model = this.Mapper.Map<IEnumerable<CarConciseViewModel>>(vehicle);

            return model;
        }

        public async Task<Vehicle> CreateAndSaveCar(CreateCarBindingModel model)
        {
            var car = this.Mapper.Map<Vehicle>(model);
            await this.DbContext.Vehicles.AddAsync(car);
            await this.DbContext.SaveChangesAsync();
            var carId = (await DbContext.Vehicles
                .Where(u => u.UserId == model.UserId)
                .FirstOrDefaultAsync(c => c.Modification == model.Modification)).Id;
            car.Id = carId;

            return car;
        }

        public async Task<CarDetailsViewModel> GetCarDetails(int id)
        {
            var vehicle = await this.DbContext.Vehicles
              .FirstOrDefaultAsync(c => c.Id == id);

            var model = this.Mapper
                .Map<CarDetailsViewModel>(vehicle);

            return model;
        }

        public async Task<EditCarBindingModel> GetEditModel(int id)
        {
            var currentCar = await this.DbContext.Vehicles.FirstOrDefaultAsync(c => c.Id == id);
            var car = this.Mapper.Map<EditCarBindingModel>(currentCar);

            return car;
        }

        public async Task<int> EditAndSave(EditCarBindingModel model)
        {
            var currentCar = await this.DbContext.Vehicles.FirstOrDefaultAsync(c => c.Id == model.Id);

            currentCar.Make = model.Make;
            currentCar.Modification = model.Modification;
            currentCar.ImageUrl = model.ImageUrl;
            currentCar.FirstRegistrationDate = model.FirstRegistrationDate;
            currentCar.HorsePower = model.HorsePower;
            currentCar.Kilometers = model.Kilometers;
            currentCar.Id = model.Id;
            currentCar.UserId = model.UserId;

            await this.DbContext.SaveChangesAsync();
            return currentCar.Id;
        }
    }
}
