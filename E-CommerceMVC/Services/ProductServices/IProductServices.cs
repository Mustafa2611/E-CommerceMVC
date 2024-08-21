using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Brands;
using E_CommerceMVC.ViewModels.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceMVC.Services.ProductServices
{
    public interface IProductServices
    {

        void CreateProduct(CreateProductFormViewModel viewModel);
        Product? Update(UpdateProductFormViewModel viewModel);
        void Delete(DeleteProductFormViewModel viewModel);

        IEnumerable<Product> GetProducts();
        

        IEnumerable<SelectListItem> GetSelectListItem();

    }
}
