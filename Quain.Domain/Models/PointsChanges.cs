namespace Quain.Domain.Models
{
    using Microsoft.EntityFrameworkCore;

    public class PointsChanges
    {
        public Guid PointsChangesId { get; private set; }

        public Guid PointsId { get; private set; }

        [Precision(10, 2)]
        public decimal Amount { get; private set; }

        public DateTimeOffset ChangeDate { get; private set; }

        public string BillNumber { get; private set; }

        public PointsChanges(decimal amount, string billNumber)
        {
            ChangeDate = DateTimeOffset.UtcNow;
            Amount = amount;
            BillNumber = billNumber;
        }

    }
}
