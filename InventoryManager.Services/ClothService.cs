namespace InventoryManager.Services
{
    using InventoryManager.Models.EntityModels;

    public class ClothService : Service
    {
        public void AddNewCloth(Cloth newCloth)
        {
            this.Context.Clothes.Add(newCloth);
            this.Context.SaveChanges();
        }
    }
}
