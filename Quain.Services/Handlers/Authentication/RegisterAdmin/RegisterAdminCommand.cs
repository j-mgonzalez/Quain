namespace Quain.Services.Handlers.Authentication.RegisterAdmin
{
    using MediatR;
    using Quain.Domain.Models;

    public class RegisterAdminCommand : IRequest<RegisterAdminResponse>
    {
        public RegisterModel RegisterModel { get; set; }

        private RegisterAdminCommand(RegisterModel registerModel)
        {
            RegisterModel = registerModel;
        }

        public static RegisterAdminCommand From(RegisterModel registerModel) 
            => new RegisterAdminCommand(registerModel);
    }
}
