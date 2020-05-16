using GillesQuirynenSys.Models;
using Microsoft.EntityFrameworkCore;

namespace GillesQuirynenSys.Data
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.Name).IsRequired();
            });

        }
    }
}