using AdWeb.AppServices.User.Repositories;
using AdWeb.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.User.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public Task<Domain.User> GetCurrent(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<string> Login(string login, string password, CancellationToken cancellation)
        {
            var result = "bread"; // TODO
            return result;
        }

        /// <inheritdoc />
        public async Task<int> Register(string login, string password, CancellationToken cancellation)
        {
            var result = 1; // TODO (+ why int not Guid)
            return result;
        }
    }
}
