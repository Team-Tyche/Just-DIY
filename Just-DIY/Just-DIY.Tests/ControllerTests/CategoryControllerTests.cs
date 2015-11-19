using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTested.WebApi;
using Just_DIY.Controllers;
using Just_DIY.Models.Projects;
using System.Web;
using Just_DIY.Data.Data;
using System.Collections.Generic;
using Moq;

namespace Just_DIY.Tests.ControllerTests
{
    using Data.Repositories;
    using Models;
    using MyTested.WebApi.Builders.Controllers;

    /// <summary>
    /// Summary description for CategoryController
    /// </summary>
    [TestClass]
    public class CategoryControllerTests
    {
        private IControllerBuilder<CategoryController> controller;
        private Mock<IJustDIYData> fakeJustDIYData = new Mock<IJustDIYData>();    

        [TestInitialize]
        public void Init()
        {
            //this.fakeJustDIYData.Setup
            this.controller = new ControllerBuilder<CategoryController>(new CategoryController(this.fakeJustDIYData.Object));
        }

        [TestMethod]
        public void MethodShouldGetCategoryByIdWithZero()
        {
            this.controller
                .Calling(c => c.Get(0))
                .ShouldReturn()
                .Ok();
            //.WithResponseModelOfType<Project>()
            //.Passing(model => model.Category == Category.Hardware);
        }
    }
}
