using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistense
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Fin_Pessoa> fin_pessoa { get; set; }
        public DbSet<Fin_categoria> fin_categoria { get; set; }
        public DbSet<Fin_Movimentacao> fin_movimentacao { get; set; }
        public DbSet<Fin_Conta_Bancaria> fin_conta_bancaria { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
