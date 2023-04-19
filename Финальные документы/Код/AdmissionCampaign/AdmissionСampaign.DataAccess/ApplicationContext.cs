using AdmissionСampaign.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdmissionСampaign.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Entrant> Entrants { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
