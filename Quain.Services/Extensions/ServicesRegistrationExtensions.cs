namespace Quain.Services.Extensions
{
    using FluentValidation;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Quain.Repository;
    using Quain.Repository.Clients;
    using Quain.Repository.Customers;
    using Quain.Repository.Sales;
    using System.Reflection;

    public static class ServicesRegistrationExtensions
    {
        public static void RegisterQuainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuainRadioContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.FluentValidationSettings(assembly);
            services.AddAutoMapper(assembly);

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
        }

        private static void FluentValidationSettings(this IServiceCollection services, Assembly servicesAssembly)
        {
            services.AddValidatorsFromAssembly(servicesAssembly);
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
