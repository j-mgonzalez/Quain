namespace Quain.Services.Handlers.Authentication.Register
{
    using global::AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Quain.Domain.Models;
    using Quain.Services.DTO;
    using Quain.Services.Handlers.Authentication.Login;
	using Quain.Services.Utils;
	using System.IdentityModel.Tokens.Jwt;
	using System.Net;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public RegisterHandler(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var model = request.RegisterModel;
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return RegisterResponse.WithError(new List<string> { "Este usuario ya existe." } , HttpStatusCode.Conflict);

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return RegisterResponse.WithError(PasswordManagerHandlerUtil.GetErrors(result.Errors), HttpStatusCode.InternalServerError);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            var loginResponseDTO = new LoginResponseDTO { Token = new JwtSecurityTokenHandler().WriteToken(token), UserName = user.UserName, Message = "Usuario creado." };

            return RegisterResponse.With(loginResponseDTO, HttpStatusCode.Created);
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
