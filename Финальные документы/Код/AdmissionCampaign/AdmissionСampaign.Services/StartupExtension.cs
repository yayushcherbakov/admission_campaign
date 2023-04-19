using AdmissionСampaign.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AdmissionСampaign.DataAccess;

namespace AdmissionСampaign.Services
{
    public static class StartupExtension
    {
        public static void AddServices(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDBContext(dbConnectionString);
            services.AddRepositories();

            services.AddTransient<EntrantService, EntrantService>();
        }
    }
}
