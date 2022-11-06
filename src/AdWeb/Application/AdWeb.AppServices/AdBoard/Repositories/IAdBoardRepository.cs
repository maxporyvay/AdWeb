using AdWeb.Contracts.AdBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.AdBoard.Repositories
{
    public interface IAdBoardRepository
    {
        Task<IReadOnlyCollection<AdBoardDto>> GetAllAsync(CancellationToken cancellation);
        Task<Guid> CreateAsync(CancellationToken cancellation);
        Task DeleteAsync(Guid id, CancellationToken cancellation);
        Task UpdateAsync(Guid id, CancellationToken cancellation);
    }
}
