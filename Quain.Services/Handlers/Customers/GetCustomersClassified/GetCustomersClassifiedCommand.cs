namespace Quain.Services.Handlers.Customers.GetCustomersClassified
{
    using MediatR;

    public class GetCustomersClassifiedCommand : IRequest<GetCustomersClassifiedResponse>
    {
        private GetCustomersClassifiedCommand()
        {
        }

        public static GetCustomersClassifiedCommand From() 
            => new GetCustomersClassifiedCommand();
    }
}
