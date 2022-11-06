using AdWeb.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.User.Services
{
    /// <summary>
    /// Сервис для работы с пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="cancellation"></param>
        /// <returns>Идентификатор пользователя.</returns>
        Task<Guid> Register(string login, string password, CancellationToken cancellation);

        /// <summary>
        /// Вход пользователя в систему.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="cancellation"></param>
        /// <returns>Токен.</returns>
        Task<string> Login(string login, string password, CancellationToken cancellation);

        /// <summary>
        /// Получить текущего пользователя.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns>Токен.</returns>
        Task<Domain.User> GetCurrent(CancellationToken cancellation);
    }
}
