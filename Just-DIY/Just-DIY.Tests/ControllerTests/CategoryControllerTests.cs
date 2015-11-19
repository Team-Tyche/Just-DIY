using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTested.WebApi;
using Just_DIY.Controllers;
using Just_DIY.Models.Projects;
using System.Web;
using Just_DIY.Data.Data;
using System.Collections.Generic;
using Moq;
using Just_DIY.Models;
using System;

namespace Just_DIY.Tests.ControllerTests
{
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
            this.controller = MyWebApi
                 .Controller<CategoryController>(() => new CategoryController(fakeJustDIYData.Object));
        }

        [TestMethod]
        public void MethodShouldGetCategoryByIdWithZero()
        {
            controller
                .Calling(c => c.Get(0))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<IQueryable<Models.Project>>()
                .Passing(model => model.OrderByDescending(x => x.CreatedOn).ToList());
        }

        [TestMethod]
        public void MethodShouldGetCategoryById()
        {
            controller.
                Calling(c => c.Get(1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<IQueryable<Models.Project>>()
                .Passing(model => model.Where(m => m.Category == Category.Hardware).OrderByDescending(m => m.CreatedOn));
        }

        [TestMethod]
        public void MethodShouldReturnNotFound()
        {
            controller.
                Calling(c => c.Get(5))
                .ShouldReturn()
                .NotFound();
        }
    }
}
