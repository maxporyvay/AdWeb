using AdWeb.AppServices.AdBoard.Repositories;
using AdWeb.Contracts.AdBoard;
using AdWeb.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.EntityConfigurations.AdBoard
{
    public class AdBoardRepository : IAdBoardRepository
    {
        private readonly IRepository<Domain.AdBoard> _repository;

        public AdBoardRepository(IRepository<Domain.AdBoard> repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<AdBoardDto>> GetAllAsync(CancellationToken cancellation)
        {
            return await _repository.GetAll()
                .Include(b => b.Ad)
                .Select(b => new AdBoardDto
                {
                    Id = b.Id,
                    AdTitle = b.Ad.AdTitle
                }).ToListAsync(cancellation);
        }

        public async Task<Guid> CreateAsync(CancellationToken cancellation)
        {
            var AdBoard = new Domain.AdBoard();

            await _repository.AddAsync(AdBoard);

            return AdBoard.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingAdBoard = await _repository.GetByIdAsync(id);

            if (existingAdBoard == null)
            {
                throw new InvalidOperationException($"Доски объявлений с идентификатором {id} не существует!");
            }
            await _repository.DeleteAsync(existingAdBoard);
        }

        public async Task UpdateAsync(Guid id/*, sometype feature*/, CancellationToken cancellation)
        {
            var existingAdBoard = await _repository.GetByIdAsync(id);

            if (existingAdBoard == null)
            {
                throw new InvalidOperationException($"Доски объявлений с идентификатором {id} не существует!");
            }
            // existingAdBoard.Feature = feature
            await _repository.UpdateAsync(existingAdBoard);
        }
    }
}
