using AdWeb.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.Migrations
{
    public class MigrationsDbContext : AdBoardContext
    {
        public MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) : base(options)
        {

        }
    }
}
