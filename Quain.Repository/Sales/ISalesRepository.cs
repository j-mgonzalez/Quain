using Quain.Domain.Models;

namespace Quain.Repository.Sales
{
    public interface ISalesRepository
    {
        Task<Sale> GetSale(string nComp, string codClient);
    }
}