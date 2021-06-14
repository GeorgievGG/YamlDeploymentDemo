using Microsoft.AspNetCore.Mvc;
using YamlDeploymentAPI.Controllers;
using YamlDeploymentInfrastructure;
using YamlDeploymentDomain;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YamlDeploymentTests
{
    [TestClass]
    public class BikeControllerTests
    {
        [TestMethod]
        public async Task Get_Returns_Successfully()
        {
            var context = InMemoryContext.GetContext();
            var controller = new BikeController(context);
            InMemoryContext.InsertBike(context, new Bike() { Id = 12, Name = "TestingBike", Available = true, Price = 12 });

            //act
            var result = await controller.Get();

            //assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        //[TestMethod]
        //public async Task Post_InvalidId_Returns400()
        //{
        //    var context = InMemoryContext.GetContext();
        //    var controller = new BikeController(context);
        //    var newBike = new Bike() { Id = -1, Name = "IllegalBike", Available = false, Price = -190 };

        //    //act
        //    var result = await controller.Post(newBike);

        //    //assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //}
    }
}
