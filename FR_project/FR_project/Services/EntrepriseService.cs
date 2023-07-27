using FR_project.Context;
using FR_project.Models;

namespace FR_project.Services
{
    public class EntrepriseService : IEntrepriseService
    {
        private readonly AppDbContext _context;
        public EntrepriseService(AppDbContext context)
        {
            _context = context;
        }
        public List<Entreprise> GetEntreprises()
        {
            var entreprises = _context.Entreprises.ToList();
            return entreprises;
        }
    }
}
