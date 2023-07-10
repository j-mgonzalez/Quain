using Quain.Domain.Models;

namespace Quain.Repository.Customers
{
    public interface ICustomersRepository
    {
        Task<Customer> Add(Customer customer, CancellationToken cancellationToken);
    }
}