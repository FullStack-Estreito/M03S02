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
            modelBuilder.Entity<DetalheModel>().HasOne(e => e.Ficha)
                        .WithMany(x => x.Detalhes)
                        .Metadata
                        .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
