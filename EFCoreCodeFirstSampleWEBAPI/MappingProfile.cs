using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;

namespace EFCoreCodeFirstSampleWEBAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Films, FilmsDTO>();
            CreateMap<Films, FilmsDetailDTO>();
            CreateMap<FilmsForCreationDto, Films>();

            CreateMap<User, UserDTO>();
            CreateMap<UserForCreationDto, User>();

            CreateMap<Description, DescriptionDTO>();

            CreateMap<FilmsUsers, FilmsUsersDTO>();
            CreateMap<FilmsUsers, FilmsDetailUsersIdDTO>();
            CreateMap<FilmsUsers, FilmsIdUsersDetailsDTO>();
            CreateMap<FilmsUsers, FilmsUsers_DetailDTO>();
            CreateMap<FilmsUsersDTO, FilmsUsers>();
        }
    }
}
