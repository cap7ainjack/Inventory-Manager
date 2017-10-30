namespace InventoryManager.Web.Controllers
{
    using InventoryManager.Models.EntityModels;
    using InventoryManager.Services;
    using InventoryManager.Services.Interfaces;
    using System.Net;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class ClothAdminController : Controller
    {
        private IClothService service;

        public ClothAdminController()
            :this(new ClothService())
        {

        }

        public ClothAdminController(IClothService service)
        {
            this.service = service;
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "ClothId")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                this.service.AddNewCloth(cloth);
            }

            //return View(cloth);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clothModel = this.service.GetClothForById((int)id);
            if (clothModel == null)
            {
                return HttpNotFound();
            }

            return View(clothModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                this.service.ModifyCloth(cloth);
                return RedirectToAction("Index", "Home");
            }

            return View(cloth);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clothModel = this.service.GetClothForById((int)id);
            if (clothModel == null)
            {
                return HttpNotFound();
            }
            return View(clothModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteCloth(id);
            return RedirectToAction("Index", "Home");
        }
    }
}