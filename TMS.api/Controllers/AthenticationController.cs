using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.api.DataTransferObject.User;
using TMS.api.Interfaces.Services;

namespace TMS.api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userDto)
        {
            var result = await authenticationService.RegisterUser(userDto);
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
    }
}
