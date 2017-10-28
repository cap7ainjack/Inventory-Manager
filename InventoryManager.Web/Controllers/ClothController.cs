namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Services;
    using System.Net;
    using System.Web.Mvc;

    [Authorize]
    public class ClothController : Controller
    {
        private ClothService service = new ClothService();

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