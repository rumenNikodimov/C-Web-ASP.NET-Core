using AutoMapper;
using CarManager.Models;
using CarManager.Web.Areas.Admin.Models.ViewModels;
using CarManager.Web.Areas.LoggedUser.Models.BindingModels;
using CarManager.Web.Areas.LoggedUser.Models.ViewModels;
using CarManager.Web.Areas.LoggedUser.Pages.Vehicles;

namespace CarManager.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
            this.CreateMap<CreateCarBindingModel, Vehicle>();
            this.CreateMap<Vehicle, CarDetailsViewModel>();
            this.CreateMap<Vehicle, CarConciseViewModel>();
            this.CreateMap<AddRefuelingModel, Refueling>();
            this.CreateMap<Vehicle, EditCarBindingModel>();
            this.CreateMap<Vehicle, DeleteModel>();
            this.CreateMap<EditCarBindingModel, Vehicle>();
        }
    }
}
