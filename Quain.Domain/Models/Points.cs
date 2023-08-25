namespace Quain.Domain.Models
{
    using Microsoft.EntityFrameworkCore;

    public class Points
    {
        public Guid PointsId { get; private set; }

        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public int CurrentValue { get; private set; }

        public ICollection<PointsChanges> PointsChanges { get; private set; }

        public DateTimeOffset? LastUpdate { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        public Points()
        {
            
        }

        public Points(int currentValue, string updatedBy, string ncomp)
        {
            CurrentValue = currentValue;
            CreatedDate = DateTimeOffset.UtcNow;

            this.AddChange(new PointsChanges(currentValue, updatedBy, ncomp));
        }

        public void UpdatePoints(int amount, string updatedBy, string ncomp = null)
        {
            CurrentValue += amount;
            LastUpdate = DateTimeOffset.UtcNow;

            this.AddChange(new PointsChanges(amount, updatedBy, ncomp));
        }

        public void AddChange(PointsChanges pointsChange)
        {
            if (PointsChanges is null)
                PointsChanges = new List<PointsChanges>();

            PointsChanges.Add(pointsChange);
        }

    }
}
