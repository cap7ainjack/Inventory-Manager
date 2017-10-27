namespace InventoryManager.Services
{
    using InventoryManager.Models.EntityModels;
    using InventoryManager.Models.ViewModels.Cloth;
    using System.Linq;

    public class ClothService : Service
    {
        public void AddNewCloth(Cloth newCloth)
        {
            this.Data.Clothes.Add(newCloth);
            this.Data.SaveChanges();
        }

        public ClothDetailsViewModel GetClothDetails(int id)
        {
            ClothDetailsViewModel result = this.Data.Clothes.All()
                .Where(x => x.ClothId == id)
                .Select(x => new ClothDetailsViewModel
                {
                    ClothId = x.ClothId,
                    Name = x.Name,
                    Type = x.Type,
                    Descripton = x.Descripton,
                    Size = x.Size,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    PictureUrl = x.PictureUrl
                }).FirstOrDefault();

            return result;
        }
    }
}
