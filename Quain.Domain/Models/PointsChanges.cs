namespace Quain.Domain.Models
{
    public class PointsChanges
    {
        public Guid PointsChangesId { get; private set; }

        public Guid PointsId { get; private set; }

        public int Amount { get; private set; }

        public DateTimeOffset ChangeDate { get; private set; }

        public int BillNumber { get; private set; }

    }
}
