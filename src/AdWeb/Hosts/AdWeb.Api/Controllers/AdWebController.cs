using AdWeb.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdWeb.Api.Controllers
{
    /// <summary>
    /// ������ � ������ ����������.
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class AdWebController : ControllerBase
    {
        public AdWebController()
        {

        }

        /// <summary>
        /// ���������� ����������, ����������� ��������������.
        /// </summary>
        /// <returns>��������� ��������� <see cref="AdBoardDto"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdBoardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// ������� ����������.
        /// </summary>
        /// <param name="id">������������� ����������</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// ������ ��������� � ����������.
        /// </summary>
        /// <param name="id">������������� ����������</param>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id)
        {
            return await Task.FromResult(Ok());
        }
    }
}