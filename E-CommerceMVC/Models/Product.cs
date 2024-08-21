using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;

        public ICollection<ProductCategories> ProductCategories = new List<ProductCategories>();
        public ICollection<Category> Categories { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public Brand Brand { get; set; }
    }
}
