using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceAPI.Models
{
    public class ProductCategories
    {
        public int Id { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }

    }
}
