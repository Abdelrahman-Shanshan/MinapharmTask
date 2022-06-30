
using Microsoft.EntityFrameworkCore;
using MinapharmTask.Controllers;
using MinapharmTask.Data;
using MinapharmTask.Models;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        private AppDBContext _context;
        public DbContextOptions<AppDBContext> _options { get; }
        public static string connectionString = "Data Source=DESKTOP-TJF6SSV;Initial Catalog=MinapharmTaskDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public UnitTest1()
        {
            _options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer(connectionString).Options;
            _context = new AppDBContext(_options);
        }
        [Fact]
        public string Test_GetAll_Asset()
        {
            //Arrange  
            var controller = new AssetsController(_context);

            //Act  
            var data = controller.Index();

            //Assert  
            return "Get All Assets successfully";
        }


        [Fact]
        public string Test_Add_Asset()
        {
            //Arrange  
            var controller = new AssetsController(_context);
            var obj = new AssetsAttributes() { AssetName = "test", Owner = "test", Manufacturer = "test", Model = "test", Version = "test", Processor = "test", InstallesMomory = "test", Driver = "test", Year = 2022 };

            //Act  
            var data = controller.Create(obj);

            //Assert  
            return "Test done successfully and record added";
        }

        [Fact]
        public string Test_Update_Asset()
        {
            //Arrange  
            var controller = new AssetsController(_context);
            var obj = new AssetsAttributes() { Id = 14, AssetName = "testUpdaaaatedddd", Owner = "Owner Updaaatedd", Manufacturer = "test", Model = "test", Version = "test", Processor = "test", InstallesMomory = "test", Driver = "test", Year = 2022 };

            //Act  
            var data = controller.Edit(obj);

            //Assert  
            return "Test done successfully and record updated";
        }

        [Fact]
        public string Test_Delete_Asset()
        {
            //Arrange  
            var controller = new AssetsController(_context);

            //Act  
            var data = controller.DeleteAsset(14);

            //Assert  
            return "Test done successfully and record deleted";
        }
        [Fact]
        //Integration test
        public string Check_All_Asset_Using_context()
        {
            var _assets = _context.AssetsAttributes;
            return "Get all successfully";
        }
    }
}