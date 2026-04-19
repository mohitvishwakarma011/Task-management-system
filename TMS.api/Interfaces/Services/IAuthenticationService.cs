using Microsoft.AspNetCore.Identity;
using TMS.api.DataTransferObjects.User;

namespace TMS.api.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userDto);
    }
}
