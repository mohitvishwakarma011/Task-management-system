using AutoMapper;
using TMS.api.DataTransferObject.User;
using TMS.api.Entities;

namespace TMS.api.Mappings
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}
