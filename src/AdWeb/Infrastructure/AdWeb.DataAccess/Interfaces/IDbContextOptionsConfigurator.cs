using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.Interfaces
{
    /// <summary>
    /// Конфигуратор контекста.
    /// </summary>
    /// <typeparam name="TContext">Контекст.</typeparam>
    public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Выполняет конфигурацию контекста.
        /// </summary>
        /// <param name="options">Настройки.</param>
        void Configure(DbContextOptionsBuilder<TContext> options);
    }
}
