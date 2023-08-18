namespace Quain.Repository.Customers
{
    using Microsoft.EntityFrameworkCore;
    using Quain.Domain.Models;

    public class CustomersRepository : ICustomersRepository
    {
        private readonly QuainPointsContext _context;

        public CustomersRepository(QuainPointsContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer customer, CancellationToken cancellationToken)
        {
            await _context.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }

        public async Task<Customer> GetCustomer(string codClient, CancellationToken cancellationToken)
            => await _context.Customers
                .Include(c => c.Points)
                    .ThenInclude(p => p.PointsChanges)
                .Where(c => c.CodClient == codClient).FirstOrDefaultAsync();

        public async Task<Customer> GetCustomerById(Guid id, CancellationToken cancellationToken)
            => await _context.Customers
                .Include(c => c.Points)
                    .ThenInclude(p => p.PointsChanges)
                .Where(c => c.Id == id).FirstOrDefaultAsync()
                ?? throw new ApplicationException("El cliente no fue encontrado.");

        public async Task<Customer> Update(Customer customer, CancellationToken cancellationToken)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
