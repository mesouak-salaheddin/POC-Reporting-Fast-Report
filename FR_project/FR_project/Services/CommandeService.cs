using FR_project.Context;
using FR_project.Models;

namespace FR_project.Services
{
    public class CommandeService : ICommandeService
    {
        private readonly AppDbContext _context;
        
        public CommandeService(AppDbContext context)
        {
            _context = context;
        }
        public List<Commande> GetCommandes()
        {
            var commandes = _context.Commandes.ToList();
            return commandes;
        }
    }
}
