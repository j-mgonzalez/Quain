namespace Quain.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string CUIT { get; private set; }

        public Points Points { get; private set; }
    }
}
