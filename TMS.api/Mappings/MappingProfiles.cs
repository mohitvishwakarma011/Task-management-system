using AutoMapper;
using TMS.api.DataTransferObject.User;
using TMS.api.DataTransferObjects;
using TMS.api.Entities;

namespace TMS.api.Mappings
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserRegistrationDto, User>();
            CreateMap<TaskItem,TaskItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
                .ReverseMap()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Description));
        }
    }
}
