using AdWeb.AppServices.AdBoard.Services;
using AdWeb.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdWeb.Api.Controllers
{
    /// <summary>
    /// Работа с доской объявлений.
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class AdBoardController : ControllerBase
    {
        private readonly IAdBoardService _adBoardService;

        public AdBoardController(IAdBoardService adBoardService)
        {
            _adBoardService = adBoardService;
        }

        /// <summary>
        /// Возвращает объявления, размещенные пользователями.
        /// </summary>
        /// <returns>Коллекция элементов <see cref="AdBoardDto"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdBoardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _adBoardService.GetAsync();
            return Ok(result);
        }

        /// <summary>
        /// Удаляет объявление.
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _adBoardService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Вносит изменения в объявление.
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id)
        {
            await _adBoardService.UpdateAsync(id);
            return NoContent();
        }
    }
}