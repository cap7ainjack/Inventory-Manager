namespace InventoryManager.Services
{
    using InventoryManager.Models.EntityModels;
    using InventoryManager.Models.ViewModels.Cloth;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : Service
    {
        public IEnumerable<ClothForIndexVM> GetAllClothes(string sortingFilter)
        {
            IEnumerable<Cloth> clothes = this.Data.Clothes.All() ;

            ICollection<ClothForIndexVM> clothesVM = MapEntityToViewModels(clothes);

            ICollection<ClothForIndexVM> sortedClothesVM = SortByInput(sortingFilter, clothesVM);

            return sortedClothesVM;
        }

        private ICollection<ClothForIndexVM> SortByInput(string sortingFilter, ICollection<ClothForIndexVM> clothesVM)
        {
            //exmp Name-Ascending
            string propFilter = sortingFilter.Substring(0, sortingFilter.IndexOf('-'));
            string order = sortingFilter.Substring(sortingFilter.IndexOf('-') + 1);

            if (order == "Ascending")
            {
               return clothesVM.OrderBy(x => x.GetType().GetProperty(propFilter).GetValue(x, null)).ToArray();
            }

            return clothesVM.OrderByDescending(x => x.GetType().GetProperty(propFilter).GetValue(x, null)).ToArray();
        }

        private ICollection<ClothForIndexVM> MapEntityToViewModels(IEnumerable<Cloth> clothes)
        {
           ICollection<ClothForIndexVM> clothesVM = new HashSet<ClothForIndexVM>();

            foreach (var cloth in clothes)
            {
                clothesVM.Add(new ClothForIndexVM
                {
                    ClothId = cloth.ClothId,
                    Name = cloth.Name,
                    Type = cloth.Type,
                    Quantity = cloth.Quantity,
                    Price = cloth.Price
                });
            }

            return clothesVM;
        }
    }
}
