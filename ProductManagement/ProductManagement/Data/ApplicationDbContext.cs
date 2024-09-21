using Microsoft.EntityFrameworkCore;
using ProductManagement.Models.Entities;

namespace ProductManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Nomenklature> Nomenklatures { get; set; }
        public DbSet<Link> Links { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настроить связи между Nomenklature и Link.
            modelBuilder.Entity<Link>()
                .HasOne(l => l.Nomenklature)
                .WithMany(n => n.ChildLinks)
                .HasForeignKey(l => l.NomenklatureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Link>()
                .HasOne(l => l.Parent)
                .WithMany(n => n.ParentLinks)
                .HasForeignKey(l => l.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
