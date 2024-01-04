using AgendaBlueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaBlueApi.Data
{
    public class AgendaContext : DbContext
    {
        public DbSet<AgendaItem> AgendaItens { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AgendaItem>(e =>
            {
                e.Property(n => n.Id)
                .ValueGeneratedOnAdd();
                
                e.Property(n => n.Telefone)
                .IsRequired();
                
                e.Property(n => n.Email)
                .HasMaxLength(50);
            });
        }
    }
}