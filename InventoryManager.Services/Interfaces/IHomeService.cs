using InventoryManager.Models.EntityModels;
using InventoryManager.Models.ViewModels.Cloth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<Cloth> GetAllClothes(string sortingFilter);
        IEnumerable<Cloth> GetSearchedResults(string name);
    }
}
