using JobsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsAPI.Persistence
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        { }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // NÃO ESQUECER DE DEFINIR CHAVE PRIMÁRIA
            builder.Entity<Job>(o =>
            {
                // o.Property(j => j.Title).HasMaxLength(25);
                o.HasKey(j => j.Id);
            });
        }
    }
}
