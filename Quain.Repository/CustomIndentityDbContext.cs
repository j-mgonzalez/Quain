namespace Quain.Repository
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CustomIndentityDbContext : IdentityDbContext<IdentityUser>
    {
        public CustomIndentityDbContext(DbContextOptions<CustomIndentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}