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
    public DbSet<Customer> Customers { get; set; }

    [DbFunction(Name = "FN_GetClientByCodClient", Schema = "dbo", IsBuiltIn = false)]
    public IQueryable<Client> FN_GetClientByCodClient(string codClient)
        => FromExpression(() => FN_GetClientByCodClient(codClient));

    [DbFunction(Name = "FN_GetBillAmount", Schema = "dbo", IsBuiltIn = false)]
    public IQueryable<Sale> FN_GetBillAmount(string n_comp)
        => FromExpression(() => FN_GetBillAmount(n_comp));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
                .HasOne(x => x.Points)
                .WithOne(x => x.Customer);

        modelBuilder.Entity<Points>()
            .HasMany(x => x.PointsChanges)
            .WithOne()
            .HasForeignKey(x => x.PointsId);

        //modelBuilder.Entity<Client>().ToFunction(nameof(FN_GetClientByCodClient));

        //modelBuilder.Entity<Sale>().ToFunction(nameof(FN_GetBillAmount));

        modelBuilder.HasDbFunction(typeof(QuainRadioContext).GetMethod(nameof(FN_GetClientByCodClient), new[] { typeof(string) }));

        modelBuilder.HasDbFunction(typeof(QuainRadioContext).GetRuntimeMethod(nameof(FN_GetBillAmount), new[] { typeof(string) }));

        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
