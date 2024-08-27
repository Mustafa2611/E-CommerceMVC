using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceAPI.Models
{
    public class ProductCategories
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }

    }
}
