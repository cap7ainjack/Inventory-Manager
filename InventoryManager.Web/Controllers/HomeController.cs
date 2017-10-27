namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Models.ViewModels.Cloth;
    using InventoryManager.Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private HomeService service = new HomeService();

        public ActionResult Index(string order = "Name-Ascending")
        {
            IEnumerable<ClothForIndexVM> allClothes = this.service.GetAllClothes(order);

            return View(allClothes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}