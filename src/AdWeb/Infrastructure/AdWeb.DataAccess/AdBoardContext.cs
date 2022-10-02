using AdWeb.DataAccess.EntityConfigurations.Ad;
using AdWeb.DataAccess.EntityConfigurations.AdBoard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess
{
    public class AdBoardContext : DbContext
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AdBoardContext"/>
        /// </summary>
        protected AdBoardContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdConfiguration());
            modelBuilder.ApplyConfiguration(new AdBoardConfiguration());
        }
    }
}
