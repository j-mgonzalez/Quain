namespace Quain.Services.Handlers.Authentication.Register
{
    using MediatR;
    using Quain.Domain.Models;

    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public RegisterModel RegisterModel { get; set; }

        private RegisterCommand(RegisterModel registerModel)
        {
            RegisterModel = registerModel;
        }

        public static RegisterCommand From(RegisterModel registerModel) 
            => new RegisterCommand(registerModel);
    }
}
