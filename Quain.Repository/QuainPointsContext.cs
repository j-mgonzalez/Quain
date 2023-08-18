using Microsoft.EntityFrameworkCore;
using Quain.Domain.Models;

namespace Quain.Repository;

public partial class QuainPointsContext : DbContext
{
    public QuainPointsContext()
    {
    }

    public QuainPointsContext(DbContextOptions<QuainPointsContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }

    public virtual DbSet<PointsChanges> PointsChanges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
                .HasOne(x => x.Points)
                .WithOne(x => x.Customer);

        modelBuilder.Entity<Points>()
            .HasMany(x => x.PointsChanges)
            .WithOne()
            .HasForeignKey(x => x.PointsId);

        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
