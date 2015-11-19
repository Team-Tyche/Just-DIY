using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTested.WebApi;
using Just_DIY.Controllers;
using Just_DIY.Models.Projects;
using System.Web;
using Just_DIY.Data.Data;
using System.Collections.Generic;

namespace Just_DIY.Tests.ControllerTests
{
    /// <summary>
    /// Summary description for CategoryController
    /// </summary>
    [TestClass]
    public class CategoryControllerTests
    {
        private IControllerBuilder<CategoryController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = MyWebApi
                .Controller<CategoryController>();
        }

        [TestMethod]
        public void MethodShouldGetCategoryByIdWithZero()
        {
            controller
                .Calling(c => c.Get(0))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<IList<Models.Project>>()
                .Passing(model => model.OrderByDescending(x => x.CreatedOn).ToList());
        }
    }
}
