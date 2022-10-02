using AdWeb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.Ad.Repositories
{
    public interface IAdRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request);
    }
}
