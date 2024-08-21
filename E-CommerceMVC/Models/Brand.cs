using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
