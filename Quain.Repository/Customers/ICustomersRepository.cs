using Quain.Domain.Models;

namespace Quain.Repository.Customers
{
    public interface ICustomersRepository
    {
        Task<Customer> Add(Customer customer, CancellationToken cancellationToken);

        Task<Customer> Update(Customer customer, CancellationToken cancellationToken);

        Task<IEnumerable<Customer>> GetCustomers(string codClient, string cuit, string name, CancellationToken cancellationToken);
        
        Task<Customer> GetCustomer(string codClient, string cuit, string name, CancellationToken cancellationToken);

        Task<Customer> GetCustomer(string codClient, CancellationToken cancellationToken);

        Task<Customer> GetCustomerById(Guid id, CancellationToken cancellationToken);
    }
}