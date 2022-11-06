using AdWeb.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.User.Repositories
{
    public interface IUserRepository
    {
        Task<Domain.User> FindWhere(Expression<Func<Domain.User, bool>> predicate, CancellationToken cancellation);

        Task AddAsync(Domain.User model);

        Task<Domain.User> FindById(Guid id, CancellationToken cancellation);
    }
}
