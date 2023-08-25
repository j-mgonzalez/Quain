namespace Quain.Services.Handlers.Customers.UpdatePointsByCustomerId
{
    using MediatR;
    using Quain.Services.Inputs;

    public class UpdatePointsByCustomerIdCommand : IRequest<UpdatePointsByCustomerIdResponse>
    {
        public Guid CustomerId { get; set; }

        public PointsInput PointsInput { get; set; }

        public string UpdatedBy { get; set; }

        private UpdatePointsByCustomerIdCommand(Guid customerId, PointsInput pointsInput, string updatedBy)
        {
            CustomerId = customerId;
            PointsInput = pointsInput;
            UpdatedBy = updatedBy;
        }

        public static UpdatePointsByCustomerIdCommand From(Guid customerId, PointsInput pointsInput, string updatedBy) 
            => new UpdatePointsByCustomerIdCommand(customerId, pointsInput, updatedBy);
    }
}
