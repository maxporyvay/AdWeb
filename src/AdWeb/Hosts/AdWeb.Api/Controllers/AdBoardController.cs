using AdWeb.AppServices.AdBoard.Services;
using AdWeb.AppServices.User.Services;
using AdWeb.Contracts.AdBoard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdWeb.Api.Controllers
{
    /// <summary>
    /// ������ � ������ ����������.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("v1/[controller]")]
    public class AdBoardController : ControllerBase
    {
        private readonly IAdBoardService _adBoardService;
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adBoardService"></param>
        /// <param name="userService"></param>
        public AdBoardController(IAdBoardService adBoardService, IUserService userService)
        {
            _adBoardService = adBoardService;
            _userService = userService;
        }

        /// <summary>
        /// ���������� ����������, ����������� ��������������.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns>��������� ��������� <see cref="AdBoardDto"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdBoardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellation)
        {
            var result = await _adBoardService.GetAsync(cancellation);
            return Ok(result);
        }

        /// <summary>
        /// ������� ����� ����������.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns>��������� ��������� <see cref="AdBoardDto"/>.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdBoardDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> PostAsync(CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation); //����� ����� ???????
            var result = await _adBoardService.GetAsync(cancellation); //������ �� CreateAsync ??????
            return Ok(result);
        }

        /// <summary>
        /// ������� ���������� � �����.
        /// </summary>
        /// <param name="id">������������� ����������</param>
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
        /// ������ ��������� � ����������.
        /// </summary>
        /// <param name="id">������������� ����������</param>
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