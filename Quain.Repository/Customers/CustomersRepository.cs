using Quain.Domain.Models;

namespace Quain.Repository.Customers
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly QuainRadioContext _context;

        public CustomersRepository(QuainRadioContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer customer, CancellationToken cancellationToken)
        {
            await _context.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
