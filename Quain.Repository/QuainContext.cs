namespace Quain.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Quain.Domain.Models;

    public class QuainContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public QuainContext(DbContextOptions<QuainContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(x => x.Points)
                .WithOne(x => x.Customer);

            modelBuilder.Entity<Points>()
                .HasMany(x => x.PointsChanges)
                .WithOne()
                .HasForeignKey(x => x.PointsId);
        }
    }
}
