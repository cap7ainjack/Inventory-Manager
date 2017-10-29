namespace InventoryManager.Data
{
    using InventoryManager.Data.Interfaces;
    using InventoryManager.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class InventoryManagerContext : IdentityDbContext<ApplicationUser>, IInventoryManagerContext
    {
      
        public InventoryManagerContext()
            : base("name=InventoryManager")
        {
        }

        public virtual IDbSet<Cloth> Clothes { get; set; }

        public static InventoryManagerContext Create()
        {
            return new InventoryManagerContext();
        }
    }

}