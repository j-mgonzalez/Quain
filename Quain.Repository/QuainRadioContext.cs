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

    [DbFunction(Name = "FN_GetClientByCodClient", Schema = "dbo", IsBuiltIn = false)]
    public IQueryable<Client> FN_GetClientByCodClient(string codClient)
        => FromExpression(() => FN_GetClientByCodClient(codClient));

    [DbFunction(Name = "FN_GetBillAmountByNCompAndCodClient", Schema = "dbo", IsBuiltIn = false)]
    public IQueryable<Sale> FN_GetBillAmountByNCompAndCodClient(string n_comp, string cod_client)
        => FromExpression(() => FN_GetBillAmountByNCompAndCodClient(n_comp, cod_client));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Client>().ToFunction(nameof(FN_GetClientByCodClient));

        //modelBuilder.Entity<Sale>().ToFunction(nameof(FN_GetBillAmountByNCompAndCodClient));

        modelBuilder.HasDbFunction(typeof(QuainRadioContext).GetMethod(nameof(FN_GetClientByCodClient), new[] { typeof(string) }));

        modelBuilder.HasDbFunction(typeof(QuainRadioContext).GetRuntimeMethod(nameof(FN_GetBillAmountByNCompAndCodClient), new[] { typeof(string), typeof(string) }));
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
