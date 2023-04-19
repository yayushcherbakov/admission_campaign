using AdmissionСampaign.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdmissionСampaign.DataAccess
{
    public static class StartupExtension
    {
        public static void AddDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            // SQL configuration for non-injected dbcontext
            DbContextOptionsBuilder<ApplicationContext> builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseSqlServer(connectionString);
            services.AddSingleton(builder.Options);
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<EntrantRepository, EntrantRepository>();
        }
    }
}
