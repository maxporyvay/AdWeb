using AdWeb.AppServices.User.Repositories;
using AdWeb.Contracts.User;
using AdWeb.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.EntityConfigurations.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.User> _repository;

        public UserRepository(IRepository<Domain.User> repository)
        {
            _repository = repository;
        }
    }
}
