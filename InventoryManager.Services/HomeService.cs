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
            : base(data)
        {
            this.Data = data;
        }

        public HomeService()
        {

        }

        public IEnumerable<Cloth> GetAllClothes(string sortingFilter)
        {
            IQueryable<Cloth> clothes = this.Data.Clothes.All();
            IEnumerable<Cloth> sortedClothesVM = SortByInput(sortingFilter, clothes);

            return sortedClothesVM;
        }

        private IEnumerable<Cloth> SortByInput(string sortingFilter, IEnumerable<Cloth> clothes)
        {
            //exmp Name-Ascending
            string propFilter = sortingFilter.Substring(0, sortingFilter.IndexOf('-'));
            string order = sortingFilter.Substring(sortingFilter.IndexOf('-') + 1);

            if (order == "Ascending")
            {
                return clothes.OrderBy(x => x.GetType().GetProperty(propFilter).GetValue(x, null)).ToArray();
            }

            return clothes.OrderByDescending(x => x.GetType().GetProperty(propFilter).GetValue(x, null)).ToArray();
        }

        public IEnumerable<Cloth> GetSearchedResults(string name)
        {
            IQueryable<Cloth> clothes = this.Data.Clothes.All().Where(x => x.Name.Contains(name));
            return clothes;
        }
    }
}
