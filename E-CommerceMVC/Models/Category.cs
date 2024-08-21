namespace E_CommerceAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products = new List<Product>();
        public ICollection<ProductCategories> ProductCategories { get; set; }
    }
}
