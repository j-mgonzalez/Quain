namespace Quain.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string CUIT { get; private set; }

        public string CodClient { get; private set; }

        public Points Points { get; private set; }

        public void SetPoints(decimal points, string ncomp)
        {
            Points = new Points(points, ncomp);
        }

        public void UpdatePoints(decimal amout, string ncomp)
        {
            Points.UpdatePoints(amout, ncomp);
        }

    }
}
