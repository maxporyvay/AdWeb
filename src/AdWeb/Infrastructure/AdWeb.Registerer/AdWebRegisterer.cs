using AdWeb.AppServices.Ad.Repositories;
using AdWeb.AppServices.Ad.Services;
using AdWeb.AppServices.Services;
using AdWeb.DataAccess;
using AdWeb.DataAccess.EntityConfigurations.Ad;
using AdWeb.DataAccess.Interfaces;
using AdWeb.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Registerer
{
    public static class AdWebRegisterer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();

            services.AddDbContext<AdBoardContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
              ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<AdBoardContext>>()
                .Configure((DbContextOptionsBuilder<AdBoardContext>)dbOptions)));
            services.AddSingleton<IDbContextOptionsConfigurator<AdBoardContext>, AdBoardContextConfiguration>();
            services.AddScoped(sp => (DbContext)sp.GetRequiredService<AdBoardContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IAdRepository, AdRepository>();
            services.AddTransient<IAdService, AdService>();

            return services;
        }
    }
}
