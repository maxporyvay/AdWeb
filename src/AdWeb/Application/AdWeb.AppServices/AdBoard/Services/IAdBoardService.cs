using AdWeb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.AdBoard.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdBoardService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdBoardDto>> GetAsync(CancellationToken cancellation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellation);
    }
}
