using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TMS.api.DataTransferObject.User;
using TMS.api.Entities;
using TMS.api.Interfaces.Services;

namespace TMS.api.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public AuthenticationService(ILogger<AuthenticationService> logger,
            IMapper mapper,
            UserManager<User> userManager) 
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userDto.Roles);
            }

            return result;
        }
    }
}
