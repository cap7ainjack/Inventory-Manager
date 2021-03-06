﻿namespace InventoryManager.Services
{
    using InventoryManager.Models.EntityModels;
    using InventoryManager.Models.ViewModels.Cloth;
    using System.Linq;
    using System;
    using InventoryManager.Services.Interfaces;
    using InventoryManager.Data.Interfaces;

    public class ClothService : Service, IClothService
    {
        public ClothService(IInventoryManagerData data)
            : base(data)
        {
            this.Data = data;
        }

        public ClothService()
        {

        }

        public void AddNewCloth(Cloth newCloth)
        {
            this.Data.Clothes.Add(newCloth);
            this.Data.SaveChanges();
        }

        public Cloth GetClothForById(int id)
        {
            Cloth cloth = this.Data.Clothes.GetById(id);
            return cloth;
        }

        public Cloth GetClothDetails(int id)
        {
            Cloth result = this.Data.Clothes.All()
                .Where(x => x.ClothId == id)
                .Select(x => new Cloth
                {
                    ClothId = x.ClothId,
                    Name = x.Name,
                    Type = x.Type,
                    Descripton = x.Descripton,
                    Size = x.Size,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    PictureUrl = x.PictureUrl
                }).FirstOrDefault();

            return result;
        }

        public void ModifyCloth(Cloth cloth)
        {
            this.Data.Clothes.Update(cloth);
            //this.Data.Entry(cloth).State = EntityState.Modified;
            this.Data.SaveChanges();
        }

        public void DeleteCloth(int id)
        {
            Cloth laptop = this.Data.Clothes.GetById(id);
            this.Data.Clothes.Delete(laptop);
            this.Data.SaveChanges();
        }

    }
}
