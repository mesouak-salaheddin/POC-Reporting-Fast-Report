using FR_project.Models;

namespace FR_project.Services
{
    public interface IClientService
    {
        List<Models.Client> GetClients();
    }
}