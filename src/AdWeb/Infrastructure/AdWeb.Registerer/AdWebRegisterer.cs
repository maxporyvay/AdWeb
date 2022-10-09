using AdWeb.AppServices.Ad.Repositories;
using AdWeb.AppServices.Ad.Services;
using AdWeb.AppServices.AdBoard.Repositories;
using AdWeb.AppServices.AdBoard.Services;
using AdWeb.AppServices.Services;
using AdWeb.AppServices.User.Repositories;
using AdWeb.AppServices.User.Services;
using AdWeb.DataAccess;
using AdWeb.DataAccess.EntityConfigurations.Ad;
using AdWeb.DataAccess.EntityConfigurations.AdBoard;
using AdWeb.DataAccess.EntityConfigurations.User;
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

            services.AddDbContext<AdWebContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
              ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<AdWebContext>>()
                .Configure((DbContextOptionsBuilder<AdWebContext>)dbOptions)));
            services.AddSingleton<IDbContextOptionsConfigurator<AdWebContext>, AdWebContextConfiguration>();
            services.AddScoped(sp => (DbContext)sp.GetRequiredService<AdWebContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IAdBoardRepository, AdBoardRepository>();
            services.AddTransient<IAdBoardService, AdBoardService>();

            services.AddTransient<IAdRepository, AdRepository>();
            services.AddTransient<IAdService, AdService>();

            return services;
        }
    }
}
