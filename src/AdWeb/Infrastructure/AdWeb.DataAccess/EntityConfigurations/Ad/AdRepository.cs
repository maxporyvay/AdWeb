using AdWeb.AppServices.Ad.Repositories;
using AdWeb.Contracts.Ad;
using AdWeb.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess.EntityConfigurations.Ad
{
    public class AdRepository : IAdRepository
    {
        private readonly IRepository<Domain.Ad> _repository;

        public AdRepository(IRepository<Domain.Ad> repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip, CancellationToken cancellation)
        {
            return await _repository.GetAll()
                .Select(a => new AdDto
                {
                    Id = a.Id,
                    AdTitle = a.AdTitle,
                    AdDescription = a.AdDescription,
                    PublishTime = a.PublishTime
                })
                .Take(take).Skip(skip).ToListAsync(cancellation);
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation)
        {
            var query = _repository.GetAll();

            if (request.Id.HasValue)
            {
                query = query.Where(a => a.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.AdTitle))
            {
                query = query.Where(a => a.AdTitle.ToLower().Contains(request.AdTitle.ToLower()));
            }
            
            return await query.Select(a => new AdDto
                {
                    Id = a.Id,
                    AdTitle = a.AdTitle,
                    AdDescription = a.AdDescription,
                    PublishTime = a.PublishTime
                }).ToListAsync(cancellation);
        }
    }
}
