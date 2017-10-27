namespace InventoryManager.Data
{
    using InventoryManager.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class InventoryManagerContext : IdentityDbContext<ApplicationUser>
    {
      
        public InventoryManagerContext()
            : base("name=InventoryManager")
        {
        }

        public virtual DbSet<Cloth> Clothes { get; set; }

        public static InventoryManagerContext Create()
        {
            return new InventoryManagerContext();
        }
    }

}