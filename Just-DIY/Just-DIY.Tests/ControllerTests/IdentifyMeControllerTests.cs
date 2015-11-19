namespace Just_DIY.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Just_DIY.Controllers;

    [TestClass]
    public class IdentifyMeControllerTests
    {
        private string identity;

        [TestMethod]
        public void ShouldReturnParsedUser()
        {
            MyWebApi
                .Controller<IdentifyMeController>()
                .Calling(c => c.Get())
                .ShouldReturn()
                .ResultOfType<int>();
        }
    }
}
