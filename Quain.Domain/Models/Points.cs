namespace Quain.Domain.Models
{
    public class Points
    {
        public Guid PointsId { get; private set; }

        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public int CurrentValue { get; private set; }

        public ICollection<PointsChanges> PointsChanges { get; private set; }

        public DateTimeOffset LastUpdate { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

    }
}
