using AdWeb.AppServices.User.Repositories;
using AdWeb.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<UserDto>> GetAll(int take, int skip, CancellationToken cancellation)
        {
            return _userRepository.GetAll(take, skip, cancellation);
        }
    }
}
