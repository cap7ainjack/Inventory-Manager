namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Models.ViewModels.Cloth;
    using InventoryManager.Services;
    using InventoryManager.Services.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController()
            : this(new HomeService())
        {
            
        }

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

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

        // POST/GET: /Home/Search
        [HttpPost]
        public ActionResult Search(string name = "")
        {

            var model = this.service.GetSearchedResults(name);
            return View("Index",model);
        }
    }
}