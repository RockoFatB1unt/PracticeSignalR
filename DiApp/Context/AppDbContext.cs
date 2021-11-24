using DiAndSignalRApp.Interfaces;
using DiAndSignalRApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DiAndSignalRApp.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasKey(u => new { u.GuardianOneId, u.GuardianTwoId });

            builder.Entity<Guardian>()
                .HasMany(g => g.StudentsForGuardianOne)
                .WithOne(p => p.GuardianOne)
                .HasForeignKey(p => p.GuardianOneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Guardian>()
                .HasMany(g => g.StudentsForGuardianTwo)
                .WithOne(p => p.GuardianTwo)
                .HasForeignKey(p => p.GuardianTwoId)
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.Entity<CustomerWithReferrals>()
                .HasKey(c => new { c.CustomerId, c.ReferralId });


            builder.Entity<Customer>()
                .HasMany(c => c.ReferralCustomers)
                .WithOne(r => r.Customer);

            builder.Entity<CustomerWithReferrals>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.ReferralCustomers)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
