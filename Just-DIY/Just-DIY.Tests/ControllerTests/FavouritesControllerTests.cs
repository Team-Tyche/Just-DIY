using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Just_DIY.Controllers;
using Just_DIY.Data.Data;
using Moq;
using Just_DIY.Models;
using MyTested.WebApi.Builders.Controllers;
using MyTested.WebApi;

namespace Just_DIY.Tests.ControllerTests
{
    [TestClass]
    public class FavouritesControllerTests
    {
        private IControllerBuilder<FavouritesController> controller;
        private Mock<IJustDIYData> fakeJustDIYData = new Mock<IJustDIYData>();

        [TestInitialize]
        public void Init()
        {
            this.fakeJustDIYData.Setup(m => m.Favourites.Delete(1)).Returns(new Favourite
            {
                User = new User(),
                Project = new Project(),
                UserId = 1,
                ProjectId = 1,
            });
            this.controller = new ControllerBuilder<FavouritesController>(new FavouritesController(this.fakeJustDIYData.Object));
        }

        [TestMethod]
        public void MethodShouldDeleteFavouriteById()
        {
            this.controller
                .Calling(c => c.Delete(1))
                .ShouldReturn()
                .Ok();
        }
    }
}
