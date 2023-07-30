namespace Quain.Repository.Clients
{
    using Quain.Domain.Models;

    public interface IClientRepository
    {
        Task<Client> GetClientByCodClient(string codClient);
    }
}