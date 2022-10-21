using AdWeb.AppServices.User.Services;
using AdWeb.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdWeb.Api.Controllers
{
    /// <summary>
    /// Работа с пользователем.
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("register")]
        //[ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)] TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(string login, string password, CancellationToken cancellation)
        {
            var user = await _userService.Register(login, password, cancellation);
            return Created("", new { });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("login")]
        //[ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)] TODO
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Login(string login, string password, CancellationToken cancellation)
        {
            var token = await _userService.Login(login, password, cancellation);
            return Ok(token);
        }
    }
}
