using CarManager.Data;
using CarManager.Web.Areas.LoggedUser.Controllers;
using CarManager.Web.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarManager.Tests.LoggedUser
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_View()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CarManagerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new CarManagerDbContext(options);

            AutoMapper.Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
            var controller = new HomeController(dbContext, AutoMapper.Mapper.Instance);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
