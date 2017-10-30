using System.Collections.Generic;
using System.Linq;
using InventoryManager.Data.Interfaces;
using InventoryManager.Models.EntityModels;
using InventoryManager.Services;
using InventoryManager.Services.Interfaces;
using InventoryManager.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace InventoryManagerTests.Controllers
{
    [TestClass]
    public class TestHomeController
    {
        private Mock<IInventoryManagerData> data;
        private IList<Cloth> cloths;
        private IHomeService service;

        [TestInitialize]
        public void InIt()
        {
            this.cloths = this.GenerateTestData();
            this.data = this.InitData(this.cloths);
            this.service = new HomeService(this.data.Object);
        }

        private IList<Cloth> GenerateTestData()
        {
            return new List<Cloth>()
            {
                new Cloth()
                {
                    Name = "Parka",
                    Type = InventoryManager.Models.Enums.ClothTypes.Coat,
                    Size = InventoryManager.Models.Enums.ClothSize.L,
                    Price = 200,
                    Quantity = 8,
                    Descripton = "Best choice for cold witner",
                    PictureUrl = "http://d3d71ba2asa5oz.cloudfront.net/12013664/images/lmj7805_khaki.jpg"
                },

                new Cloth()
                {
                    Name = "Leather Jacket",
                    Type = InventoryManager.Models.Enums.ClothTypes.Jacket,
                    Size = InventoryManager.Models.Enums.ClothSize.M,
                    Price = 68.00m,
                    Quantity = 6,
                    Descripton = "Nice leather jacket",
                    PictureUrl = "http://trendyleatherjacket.com/wp-content/uploads/2014/04/BLACK-RIVET.png"
                }
            };
        }

        private Mock<IInventoryManagerData> InitData(IList<Cloth> clothes)
        {
            var data = new Mock<IInventoryManagerData>();

            data.Setup(x => x.SaveChanges()).Returns(1);
            data.Setup(x => x.Clothes.All()).Returns(clothes.AsQueryable());

            return data;
        }


        [TestMethod]
        public void Index_ShouldPass()
        {
            var controller = new HomeController(this.service);
            controller.WithCallTo(c => c.Index("Name-Ascending")).ShouldRenderDefaultView();
        }
    }
}
