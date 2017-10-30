using InventoryManager.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Interfaces
{
    public interface IInventoryManagerContext
    {
        IDbSet<Cloth> Clothes { get; set; }

        int SaveChanges();
    }
}
