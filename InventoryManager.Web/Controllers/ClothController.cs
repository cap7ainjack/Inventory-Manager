namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Services;
    using InventoryManager.Services.Interfaces;
    using System.Net;
    using System.Web.Mvc;

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
            var viewModel = this.service.GetClothDetails((int)ClothId);

            return View(viewModel);
        }

    }
}