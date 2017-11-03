using InventoryManager.Models.EntityModels;
using InventoryManager.Models.ViewModels.Cloth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.Interfaces
{
    public interface IClothService
    {
        void AddNewCloth(Cloth newCloth);

        Cloth GetClothForById(int id);

        Cloth GetClothDetails(int id);

        void ModifyCloth(Cloth cloth);

        void DeleteCloth(int id);
    }
}
