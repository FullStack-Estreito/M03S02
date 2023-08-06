using Microsoft.EntityFrameworkCore;

namespace FichaCadastroApi.Model
{
    public class FichaCadastroDbContext : DbContext
    {
        public FichaCadastroDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FichaModel> FichaModels { get; set; }
        public DbSet<DetalheModel> DetalheModels { get; set; }


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
