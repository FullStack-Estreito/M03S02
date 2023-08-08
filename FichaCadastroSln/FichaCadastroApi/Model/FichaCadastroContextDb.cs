using Microsoft.EntityFrameworkCore;

namespace FichaCadastroApi.Model
{
    public class FichaCadastroDbContext : DbContext
    {
        public FichaCadastroDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
