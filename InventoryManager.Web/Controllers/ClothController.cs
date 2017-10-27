using InventoryManager.Models.EntityModels;
using InventoryManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClothController : Controller
    {
        private ClothService service = new ClothService();

        // GET: Cloth/add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Exclude = "ClothId")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                this.service.AddNewCloth(cloth);
            }

            //return View(cloth);
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var viewModel = this.service.GetClothDetails(id);

            return View(viewModel);
        }
    }
}