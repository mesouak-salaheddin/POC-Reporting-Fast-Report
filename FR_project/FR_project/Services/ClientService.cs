using FR_project.Context;
using FR_project.Models;

namespace FR_project.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;
        public  ClientService(AppDbContext context)
        {
            _context = context;
        }
        public List<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            return clients;
        }
    }
}
