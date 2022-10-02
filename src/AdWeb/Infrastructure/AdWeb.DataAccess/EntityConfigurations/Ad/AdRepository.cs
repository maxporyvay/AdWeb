using AdWeb.AppServices.Ad.Repositories;
using AdWeb.Contracts;
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

        public async Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip)
        {
            return await _repository.GetAll()
                .Select(p => new AdDto
                {
                    Id = p.Id,
                    AdTitle = p.AdTitle,
                    AdDescription = p.AdDescription,
                    PublishTime = p.PublishTime
                })
                .Take(take).Skip(skip).ToListAsync();
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request)
        {
            var query = _repository.GetAll();

            if (request.Id.HasValue)
            {
                query = query.Where(p => p.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.AdTitle))
            {
                query = query.Where(p => p.AdTitle.ToLower().Contains(request.AdTitle.ToLower()));
            }
            
            return await query.Select(p => new AdDto
                {
                    Id = p.Id,
                    AdTitle = p.AdTitle,
                    AdDescription = p.AdDescription,
                    PublishTime = p.PublishTime
                }).ToListAsync();
        }
    }
}
