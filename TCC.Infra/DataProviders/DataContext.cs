using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Infra.DataProviders.Extensions;

namespace TCC.Infra.DataProviders
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set;}
        public DbSet<Classificacao> Classificacoes { get; set;}
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {
            this.AddAuditory();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.AddAuditory();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}