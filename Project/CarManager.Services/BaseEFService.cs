using AutoMapper;
using CarManager.Data;
using CarManager.Models;
using Microsoft.AspNetCore.Identity;

namespace CarManager.Services
{
    public class BaseEFService
    {
        public BaseEFService(CarManagerDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }
        //public BaseEFService(CarManagerDbContext dbContext, IMapper mapper,UserManager<User> userManager) : (dbContext, mapper)
        //{
        //    this.UserManager = userManager;
        //}
        public CarManagerDbContext DbContext { get; private set; }

        public IMapper Mapper { get; private set; }

        //public UserManager<User> UserManager { get; private set; }
    }
}
