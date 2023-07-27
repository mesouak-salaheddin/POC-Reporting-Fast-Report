using FR_project.Context;
using FR_project.Models;

namespace FR_project.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;
        public CategorieService(AppDbContext context)
        {
            _context = context;
        }
        public List<Categorie> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}