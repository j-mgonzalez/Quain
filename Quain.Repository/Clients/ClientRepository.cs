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

        public async Task<Client> GetClientByCodClientCuitName(string codClient, string name, string cuit)
        {
            var foo = _context.FN_GetClientByCodClientCuitName(codClient, cuit, name);

            return await foo.FirstOrDefaultAsync()
                ?? throw new ApplicationException($"El cliente {codClient} {name} {cuit} no existe.");
        }

        public async Task<IEnumerable<ClientClassified>> GetClientsClassified()
        {
            var foo = _context.FN_GetClientsClassified();

            return await foo.ToListAsync();
        }
    }
}
