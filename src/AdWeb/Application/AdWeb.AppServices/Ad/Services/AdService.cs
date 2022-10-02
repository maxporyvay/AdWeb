using AdWeb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.Ad.Services
{
    public class AdService : IAdService
    {
        public Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
