using InventoryManager.Models.EntityModels;

namespace InventoryManager.Data.Interfaces
{
    public interface IInventoryManagerData
    {
        IRepository<Cloth> Clothes { get; }

        int SaveChanges();
    }
}
