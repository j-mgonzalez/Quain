namespace Quain.Services.Handlers.Authentication.RegisterAdmin
{
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Quain.Domain.Models;
    using Quain.Services.DTO;
	using Quain.Services.Utils;
	using System.IdentityModel.Tokens.Jwt;
	using System.Net;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterAdminHandler : IRequestHandler<RegisterAdminCommand, RegisterAdminResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public RegisterAdminHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<RegisterAdminResponse> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var model = request.RegisterModel;
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null) return RegisterAdminResponse.WithError(new List<string> { "Este usuario ya existe." }, HttpStatusCode.Conflict);

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return RegisterAdminResponse.WithError(PasswordManagerHandlerUtil.GetErrors(result.Errors), HttpStatusCode.InternalServerError);

            var adminRoleExists = await _roleManager.RoleExistsAsync(UserRoles.Admin);
            var userRoleExists = await _roleManager.RoleExistsAsync(UserRoles.User);

            if (!adminRoleExists)
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!userRoleExists)
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (adminRoleExists)
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            if (userRoleExists)
                await _userManager.AddToRoleAsync(user, UserRoles.User);

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

            return RegisterAdminResponse.With(loginResponseDTO, HttpStatusCode.Created);
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
