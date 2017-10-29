namespace InventoryManager.Services
{
    using InventoryManager.Data.Interfaces;
    using InventoryManager.Models.EntityModels;
    using InventoryManager.Models.ViewModels.Cloth;
    using InventoryManager.Services.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : Service, IHomeService
    {
        public HomeService(IInventoryManagerData data)
        {
            this.Data = data;
        }

        public HomeService()
        {
            
        }

        public IEnumerable<ClothForIndexVM> GetAllClothes(string sortingFilter)
        {
            IQueryable<Cloth> clothes = this.Data.Clothes.All();

            IEnumerable<ClothForIndexVM> clothesVM = MapEntityToViewModels(clothes);

            IEnumerable<ClothForIndexVM> sortedClothesVM = SortByInput(sortingFilter, clothesVM);

            return sortedClothesVM;
        }

        private IEnumerable<ClothForIndexVM> SortByInput(string sortingFilter, IEnumerable<ClothForIndexVM> clothesVM)
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

        private IEnumerable<ClothForIndexVM> MapEntityToViewModels(IEnumerable<Cloth> clothes)
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

        public IEnumerable<ClothForIndexVM> GetSearchedResults(string name)
        {
            IQueryable<Cloth> clothes = this.Data.Clothes.All().Where(x => x.Name.Contains(name));

            IEnumerable<ClothForIndexVM> clothesVM = MapEntityToViewModels(clothes);

            return clothesVM;
        }
    }
}
