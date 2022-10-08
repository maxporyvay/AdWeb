using AdWeb.AppServices.AdBoard.Repositories;
using AdWeb.Contracts.AdBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.AdBoard.Services
{
    /// <inheritdoc />
    public class AdBoardService : IAdBoardService
    {
        private readonly IAdBoardRepository _adBoardRepository;

        public AdBoardService(IAdBoardRepository adBoardRepository)
        {
            _adBoardRepository = adBoardRepository;
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<AdBoardDto>> GetAsync(CancellationToken cancellation)
        {
            return _adBoardRepository.GetAllAsync(cancellation);
        }

        /// <inheritdoc />
        public Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return _adBoardRepository.DeleteAsync(id, cancellation);
        }

        /// <inheritdoc />
        public Task UpdateAsync(Guid id, CancellationToken cancellation)
        {
            return _adBoardRepository.UpdateAsync(id, cancellation);
        }
    }
}
