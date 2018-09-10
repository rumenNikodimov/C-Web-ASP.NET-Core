//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CarManager.Tests
//{
//    class VehiclesControllerTest
//    {
//    }
//}
using AutoMapper;
using CarManager.Data;
using CarManager.Models;
using CarManager.Web.Areas.LoggedUser.Controllers;
using CarManager.Web.Areas.LoggedUser.Models.BindingModels;
using CarManager.Web.Mapping;
using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Globalization;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CarManager.Tests
//{
//    [TestClass]
//    public class VehiclesControllersTests
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//            //Arrange
//            var options = new DbContextOptionsBuilder<CarManagerDbContext>()
//                .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                .Options;

//            var dbContext = new CarManagerDbContext(options);

//            AutoMapper.Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
//            var controller = new VehiclesController(dbContext, AutoMapper.Mapper.Instance);
//            var model = new CreateCarBindingModel();

            //dbContext.Vehicles.Add(new Vehicle()
            //{
            //    Make = "Honda",
            //    Modification = "Accord",
            //    FirstRegistrationDate = DateTime.ParseExact("15.05.2011", "dd.MM.yyyy", CultureInfo.InvariantCulture),
            //    Kilometers = 89000,
            //    HorsePower = 154
            //});
            //dbContext.Vehicles.Add(new Vehicle()
            //{
            //    Make = "Bugatti",
            //    Modification = "Divo",
            //    FirstRegistrationDate = DateTime.ParseExact("15.05.2018", "dd.MM.yyyy", CultureInfo.InvariantCulture),
            //    Kilometers = 89000,
            //    HorsePower = 1500
            //});
            //dbContext.Vehicles.Add(new Vehicle()
            //{
            //    Make = "Hyundai",
            //    Modification = "i30",
            //    FirstRegistrationDate = DateTime.ParseExact("15.05.2010", "dd.MM.yyyy", CultureInfo.InvariantCulture),
            //    Kilometers = 89000,
            //    HorsePower = 136
            //});

            //dbContext.SaveChanges();

            ////Act
            //var cars = controller.Create(model);

            //Assert
            //Assert.IsNotNull(cars);
            //Assert.AreEqual(3, cars.Count());
            //CollectionAssert.AreEqual(new[] { 1, 2, 3 }, cars.Select(c => c.Id).ToArray());
//        }
//    }
//}
