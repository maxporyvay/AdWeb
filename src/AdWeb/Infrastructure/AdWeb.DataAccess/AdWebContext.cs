using AdWeb.DataAccess.EntityConfigurations.Ad;
using AdWeb.DataAccess.EntityConfigurations.AdBoard;
using AdWeb.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess
{
    public class AdWebContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AdWebContext"/>
        /// </summary>
        public AdWebContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            base.OnModelCreating(modelBuilder);
        }
    }
}
