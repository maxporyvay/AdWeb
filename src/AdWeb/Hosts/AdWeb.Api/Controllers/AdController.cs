using AdWeb.AppServices.Ad.Services;
using AdWeb.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdWeb.Api.Controllers
{
    /// <summary>
    /// Работа с объявлением .
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip, CancellationToken cancellation)
        {
            var result = await _adService.GetAll(take, skip, cancellation);
            return Ok(result);
        }
    }
}
