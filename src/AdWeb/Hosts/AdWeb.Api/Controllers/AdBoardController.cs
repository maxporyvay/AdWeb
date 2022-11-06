using AdWeb.AppServices.AdBoard.Services;
using AdWeb.Contracts.AdBoard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdWeb.Api.Controllers
{
    /// <summary>
    /// Работа с доской объявлений.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("v1/[controller]")]
    public class AdBoardController : ControllerBase
    {
        private readonly IAdBoardService _adBoardService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adBoardService"></param>
        public AdBoardController(IAdBoardService adBoardService)
        {
            _adBoardService = adBoardService;
        }

        /// <summary>
        /// Возвращает объявления, размещенные пользователями.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns>Коллекция элементов <see cref="AdBoardDto"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdBoardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellation)
        {
            var result = await _adBoardService.GetAsync(cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Создает доску объявлений.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns>Коллекция элементов <see cref="AdBoardDto"/>.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAsync(CancellationToken cancellation)
        {
            var result = await _adBoardService.CreateAsync(cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Удаляет объявление с доски.
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellation"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellation)
        {
            await _adBoardService.DeleteAsync(id, cancellation);
            return NoContent();
        }

        /// <summary>
        /// Вносит изменения в объявление.
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellation"></param>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, CancellationToken cancellation)
        {
            await _adBoardService.UpdateAsync(id, cancellation);
            return NoContent();
        }
    }
}