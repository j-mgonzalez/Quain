namespace Quain.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string CUIT { get; private set; }

        public string CodClient { get; private set; }

        public Points Points { get; private set; }

        public void SetPoints(int points, string updatedBy, string ncomp)
        {
            Points = new Points(points, updatedBy, ncomp);
        }

        public void UpdatePoints(int amout, string updatedBy, string ncomp = null)
        {
            Points.UpdatePoints(amout, updatedBy, ncomp);
        }

        public bool BillWasUsed(string billNumber)
            => Points.PointsChanges.Any(p => p.BillNumber == billNumber);

    }
}
