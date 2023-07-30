namespace Quain.Repository.Clients
{
    using Microsoft.EntityFrameworkCore;
    using Quain.Domain.Models;
    using System.Threading.Tasks;

    public class ClientRepository : IClientRepository
    {
        private readonly QuainRadioContext _context;

        public ClientRepository(QuainRadioContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientByCodClient(string codClient)
            => await _context.FN_GetClientByCodClient(codClient).FirstOrDefaultAsync()
                ?? throw new ApplicationException("Client not found");
    }
}
