using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.CMS;
using Projekt.Data.Data.Sklep;
using Projekt.Data.Data;


namespace Projekt.Data.Data
{
    // ProjektContext reprezentuje cala baze dancyh
    public class ProjektContext : DbContext
    {
        public ProjektContext(DbContextOptions<ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; }
        public DbSet<Aktualnosc> Aktualnosc { get; set; }
        public DbSet<Danie> Danie { get; set; }
        public DbSet<ONas> ONas { get; set; }
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<Stopka> Stopka { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Promocja> Promocja { get; set; }
    }
}
