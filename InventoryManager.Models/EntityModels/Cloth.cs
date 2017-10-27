namespace InventoryManager.Models.EntityModels
{
    using InventoryManager.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class Cloth
    {
        public int ClothId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ClothTypes Type { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        [Required]
        public ClothSize Size { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripton { get; set; }
    }
}
