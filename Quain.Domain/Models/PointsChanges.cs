namespace Quain.Domain.Models
{
    public class PointsChanges
    {
        public Guid PointsChangesId { get; private set; }

        public Guid PointsId { get; private set; }

        public int Amount { get; private set; }

        public DateTimeOffset ChangeDate { get; private set; }

        public string? BillNumber { get; private set; }

        public string UpdatedBy { get; set; }

        public PointsChanges(int amount, string updatedBy, string billNumber = null)
        {
            ChangeDate = DateTimeOffset.UtcNow;
            Amount = amount;
            BillNumber = billNumber;
            UpdatedBy = updatedBy;
        }

    }
}
