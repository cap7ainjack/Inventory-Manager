using System;
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
    public class TestAdminClothController
    {
        private Mock<IInventoryManagerData> data;
        private IList<Cloth> cloths;
        private IClothService service;

        [TestInitialize]
        public void InIt()
        {
            this.cloths = this.GenerateTestData();
            this.data = this.InitData(this.cloths);
            this.service = new ClothService(this.data.Object);
        }

        private IList<Cloth> GenerateTestData()
        {
            return new List<Cloth>()
            {
                new Cloth()
                {
                    ClothId = 1,
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
                    ClothId = 2,
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
        public void Create_GetMethod()
        {
            var controller = new ClothAdminController(this.service);
            controller.WithCallTo(c => c.Add())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Create_PostMethod()
        {
            var controller = new ClothAdminController(this.service);

            controller.WithCallTo(c => c.Add(new Cloth()
            {
                Name = "New Cloth",
                Size = InventoryManager.Models.Enums.ClothSize.L,
                Quantity = 1,
                Price = 23.00m,
                Type = InventoryManager.Models.Enums.ClothTypes.Blazer,
                Descripton = "",
                PictureUrl = "No pic",
                ClothId = 3
            }))
            .ShouldRedirectTo<HomeController>(c => c.Index("Name-Ascending"));
        }
    }
}
