namespace Just_DIY.Tests.ControllerTests
{
<<<<<<< HEAD
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
=======
>>>>>>> 4a7ba70071aa3776b155f331e83d0510b3dbfdb6
    using Controllers;
    using Data.Data;
    using Moq;
    using MyTested.WebApi;
    using MyTested.WebApi.Builders.Controllers;
    using Just_DIY.Models;

<<<<<<< HEAD
=======
    /// <summary>
    /// Summary description for ProjectControllerTests
    /// </summary>
>>>>>>> 4a7ba70071aa3776b155f331e83d0510b3dbfdb6
    [TestClass]
    public class ProjectControllerTests
    {
        private IControllerBuilder<ProjectsController> controller;
        private Mock<IJustDIYData> fakeJustDIYData = new Mock<IJustDIYData>();

        [TestInitialize]
        public void Init()
        {
            this.fakeJustDIYData.Setup(m => m.Projects.Delete(1)).Returns(new Project
            {
                Author = new User(),
                Category = Category.Hardware,
                Content = "Hello, World!",
                CreatedOn = DateTime.Now,
                Name = "Arduino Uno hacks",
                VideoUrl = "http://youtube.com/cats/",
                Points = 5
            });
            this.controller = new ControllerBuilder<ProjectsController>(new ProjectsController(this.fakeJustDIYData.Object));
        }

        [TestMethod]
        public void MethodShouldDeleteProjectById()
        {
            this.controller
                .Calling(c => c.Delete(1))
                .ShouldReturn()
                .Ok();
        }
    }
}
