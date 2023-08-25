using Microsoft.EntityFrameworkCore;
using Quain.Domain.Models;
using System.Reflection;

namespace Quain.Repository;

public partial class QuainRadioContext : DbContext
{
    public QuainRadioContext()
    {
    }

    public QuainRadioContext(DbContextOptions<QuainRadioContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    [DbFunction(Name = "FN_GetClientByCodClientCuitName", Schema = "dbo", IsBuiltIn = false)]
    public IQueryable<Client> FN_GetClientByCodClientCuitName(string codClient, string cuit, string name)
        => FromExpression(() => FN_GetClientByCodClientCuitName(codClient, cuit, name));

    [DbFunction(Name = "FN_GetBillAmountByNComp", Schema = "dbo", IsBuiltIn = false)]
    public IQueryable<Sale> FN_GetBillAmountByNComp(string n_comp)
        => FromExpression(() => FN_GetBillAmountByNComp(n_comp));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Client>().ToFunction(nameof(FN_GetClientByCodClient));

        //modelBuilder.Entity<Sale>().ToFunction(nameof(FN_GetBillAmountByNCompAndCodClient));

        modelBuilder.HasDbFunction(typeof(QuainRadioContext).GetMethod(nameof(FN_GetClientByCodClientCuitName), new[] { typeof(string), typeof(string), typeof(string) }));

        modelBuilder.HasDbFunction(typeof(QuainRadioContext).GetRuntimeMethod(nameof(FN_GetBillAmountByNComp), new[] { typeof(string) }));
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
