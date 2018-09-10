using CarManager.Models;
using CarManager.Web.Areas.LoggedUser.Models.BindingModels;
using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarManager.Services.LoggedUser.Interfaces
{
    public interface ILoggedUserVehiclesService
    {
        IEnumerable<CarConciseViewModel> GetUserCars(string id);

        Task<Vehicle> CreateAndSaveCar(CreateCarBindingModel model);

        Task<CarDetailsViewModel> GetCarDetails(int id);

        Task<EditCarBindingModel> GetEditModel(int id);

        Task<int> EditAndSave(EditCarBindingModel model);
    }
}
