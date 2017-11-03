namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Models.ViewModels.Cloth;
    using InventoryManager.Services;
    using InventoryManager.Services.Interfaces;
    using System.Net;
    using System.Web.Mvc;
    using InventoryManager.Models.EntityModels;
    using System;

    [Authorize]
    public class ClothController : Controller
    {
        private IClothService service;

        public ClothController()
            : this(new ClothService())
        {

        }

        public ClothController(IClothService service)
        {
            this.service = service;
        }

        public ActionResult Details(int? ClothId)
        {
            if (ClothId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = this.service.GetClothDetails((int)ClothId);

            ClothDetailsViewModel viewModel = getViewModelByEntityModel(model);

            return View(viewModel);
        }

        private ClothDetailsViewModel getViewModelByEntityModel(Cloth model)
        {
            return new ClothDetailsViewModel
            {
                ClothId = model.ClothId,
                Name = model.Name,
                Size = model.Size,
                Quantity = model.Quantity,
                Type = model.Type,
                Descripton = model.Descripton,
                PictureUrl = model.PictureUrl,
                Price = model.Price
            };
        }
    }
}