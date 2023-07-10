using mesada.Models;

namespace mesada.Data
{
    public class MesadaDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public MesadaDbContext(DbContextOptions<MesadaDbContext> options)
            : base(options)
        {
        }

    }
}