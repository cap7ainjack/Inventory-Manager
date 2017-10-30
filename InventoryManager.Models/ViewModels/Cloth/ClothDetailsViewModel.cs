namespace InventoryManager.Models.ViewModels.Cloth
{
    using InventoryManager.Models.Enums;

    public class ClothDetailsViewModel
    {
        public int ClothId { get; set; }

        public string Name { get; set; }

        public ClothTypes Type { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ClothSize Size { get; set; }

        public string PictureUrl { get; set; }

        public string Descripton { get; set; }
    }
}
