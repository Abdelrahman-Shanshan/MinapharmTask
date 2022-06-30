using Microsoft.AspNetCore.Mvc;
using MinapharmTask.Controllers;
using MinapharmTask.Models;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Task_Add_ValidData_Return_OkResult()
        {

            //Arrange
            AssetsController controller = new AssetsController(null);
            var asset = new AssetsAttributes() { AssetName = "Test Name", Owner = "Test", Manufacturer = "test", Model = "test", Version = "test", Processor = "test", InstallesMomory = "test", Driver = "test", Year = 2022 };

            //Act
            var data = controller.Create(asset);

            //Assert
            //Assert.IsType<OkObjectResult>(data);
        }
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
    }
}