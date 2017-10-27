namespace InventoryManager.Models.ViewModels.Cloth
{
    using InventoryManager.Models.Enums;

    public class ClothForIndexVM
    {
        public int ClothId { get; set; }
        public string Name { get; set; }
        public ClothTypes Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
