using AdWeb.AppServices.User.Repositories;
using AdWeb.Contracts.User;
using AdWeb.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task AddAsync(Domain.User model)
        {
            return _repository.AddAsync(model);
        }

        public async Task<Domain.User> FindWhere(Expression<Func<Domain.User, bool>> predicate, CancellationToken cancellation)
        {
            var data = _repository.GetAllFiltered(predicate);
            return await data.Where(predicate).FirstOrDefaultAsync(cancellation);
        }
    }
}
