namespace Quain.Repository.Clients
{
    using Quain.Domain.Models;

    public interface IClientRepository
    {
        Task<Client> GetClientByCodClientCuitName(string codClient, string name, string cuit);

        Task<IEnumerable<ClientClassified>> GetClientsClassified();
    }
}