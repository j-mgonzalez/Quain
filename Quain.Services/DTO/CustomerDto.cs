namespace Quain.Services.DTO
{
    public class CustomerDto
    {
        public Guid Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CUIT { get; set; }

        public PointsDto Points { get; set; }
    }
}
