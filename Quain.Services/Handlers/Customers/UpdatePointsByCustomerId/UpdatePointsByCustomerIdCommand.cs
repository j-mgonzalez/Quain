namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using MediatR;
    using Quain.Services.Inputs;

    public class UpdatePointsByCustomerIdCommand : IRequest<UpdatePointsByCustomerIdResponse>
    {
        public Guid CustomerId { get; set; }

        public PointsInput PointsInput { get; set; }

        private UpdatePointsByCustomerIdCommand(Guid customerId, PointsInput pointsInput)
        {
            CustomerId = customerId;
            PointsInput = pointsInput;
        }

        public static UpdatePointsByCustomerIdCommand From(Guid customerId, PointsInput pointsInput) 
            => new UpdatePointsByCustomerIdCommand(customerId, pointsInput);
    }
}
