using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Films, FilmsDTO>();
            CreateMap<FilmsForCreationDto, Films>();
            CreateMap<User, UserDTO>();
            CreateMap<UserForCreationDto, User>();
        }
    }
}
