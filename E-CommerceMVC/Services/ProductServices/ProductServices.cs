using E_CommerceMVC.Data;
using E_CommerceAPI.Models;
using E_CommerceMVC.ViewModels.Products;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_CommerceMVC.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public ProductServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}/assets/images";
        }



        public  void CreateProduct(CreateProductFormViewModel viewModel)
        {

            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(viewModel.Cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName) ;
            using var stream = File.Create(path) ;
             viewModel.Cover.CopyTo(stream) ;
            stream.Dispose();

            ICollection <Category> selectedCategories = new List<Category>();
            foreach(var id in viewModel.SelectedCategories)
            {
                selectedCategories.Add(_context.Categories.Find(id));
            }

            Product product = new()
            {
                ProductName = viewModel.ProductName,
                BrandId = viewModel.BrandId,
                Brand =  _context.Brands.Find(viewModel.BrandId),
                Categories = selectedCategories,
                Stock = viewModel.Stock,
                Price = viewModel.Price,
                Cover = coverName
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            List<ProductCategories> productCategories = new List<ProductCategories>();
            foreach (var category in product.Categories)
            {
                //var exsitingRelation = _context.ProductCategories.FirstOrDefault(pc => pc.ProductId == product.ProductId && pc.CategoryId == category.CategoryId);
                //if (exsitingRelation == null)
                //{
                //    _context.ProductCategories.Add(new ProductCategories 
                //    {
                //        Category = category,
                //        Product= product,
                //    });

                //}
                productCategories = new List<ProductCategories>()
                    {
                        new ProductCategories
                        {
                            Category = category,
                            Product = product
                        }
                    };
            }
             _context.ProductCategories.AddRange(productCategories);
             _context.SaveChanges();

        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.Include(p=> p.Brand).Include(p=> p.Categories).ToList();
            return products;
        }

        public Product? Update(UpdateProductFormViewModel viewModel)
        {
            var covername = SaveCover(viewModel.Cover);

            var product = _context.Products.Single( p=> p.ProductId == viewModel.ProductId);
            if (product is null)
                return null;

            ICollection<Category> selectedCategories = new List<Category>();
            foreach (var id in viewModel.SelectedCategories)
            {
                if(!_context.ProductCategories.Any(pc=> pc.ProductId == product.ProductId && pc.CategoryId == id))
                    selectedCategories.Add(_context.Categories.Find(id));
            }
            
            product.ProductName = viewModel.ProductName;
            product.BrandId = viewModel.BrandId;
            product.Stock = viewModel.Stock;
            product.Price = viewModel.Price;
            product.Categories = selectedCategories;
            product.Cover = covername;

            _context.Products.Update(product);

            if (_context.SaveChanges() > 0)
                return product;
            else
                return null;
        }

        public void Delete(DeleteProductFormViewModel viewModel)
        {
            Product product = _context.Products
                .Include(p=> p.Brand)
                .Include(p=> p.Categories)
                .SingleOrDefault(product => product.ProductId == viewModel.ProductId)?? throw new Exception("NotFound");
            
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetSelectListItem()
        {

            return _context.Products.Include(p => p.Brand).Include(p => p.Categories)
                .Select(p=> new SelectListItem 
                { 
                    Value = p.ProductId.ToString(),
                    Text = p.ProductName
                    }).ToList();
        }


        private string SaveCover(IFormFile Cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName);
            using var stream = File.Create(path);
            Cover.CopyTo(stream);
            stream.Dispose();
            return coverName;
        }
    }
}
