using FR_project.Context;
using FR_project.Models;

namespace FR_project.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }
    }
}
