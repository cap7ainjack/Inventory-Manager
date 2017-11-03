namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Models.EntityModels;
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
            IEnumerable<Cloth> allClothes = this.service.GetAllClothes(order);
            IEnumerable<ClothForIndexVM> allClothesVM = MapEntityToViewModels(allClothes);

            return View(allClothesVM);
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
            IEnumerable<ClothForIndexVM> clothesVM = MapEntityToViewModels(model);
            return View("Index", clothesVM);
        }

        private IEnumerable<ClothForIndexVM> MapEntityToViewModels(IEnumerable<Cloth> clothes)
        {
            ICollection<ClothForIndexVM> clothesVM = new HashSet<ClothForIndexVM>();

            foreach (var cloth in clothes)
            {
                clothesVM.Add(new ClothForIndexVM
                {
                    ClothId = cloth.ClothId,
                    Name = cloth.Name,
                    Type = cloth.Type,
                    Quantity = cloth.Quantity,
                    Price = cloth.Price
                });
            }

            return clothesVM;
        }
    }
}