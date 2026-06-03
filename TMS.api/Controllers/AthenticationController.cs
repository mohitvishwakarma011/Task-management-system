using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.api.DataTransferObjects;
using TMS.api.DataTransferObjects.User;
using TMS.api.Interfaces.Services;

namespace TMS.api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userDto)
        {
            var result = await _authenticationService.RegisterUser(userDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                    return BadRequest(ModelState);
                }
            }
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo([FromRoute] int userId)
        {
            await Task.Delay(1000);
            return Ok(userId);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserTokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginUser(UserForAuthenticationDto dto)
        {
            if(!await _authenticationService.ValidateUser(dto))
            {
                return Unauthorized();
            }

            var tokenString = await _authenticationService.CreateToken();
            return Ok(new UserTokenDto { Token = tokenString});
        }
    }
}
