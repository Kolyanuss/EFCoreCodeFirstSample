using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.BLL.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.BLL.Exceptions;
using EFCoreCodeFirstSampleWEBAPI.BLL.Interfaces.ISQLServices;
using EFCoreCodeFirstSampleWEBAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.UnitTests
{
    public class FilmsServiceFake : IFilmsService
    {
        private readonly IEnumerable<Films> _filmesList = null;
        private readonly IMapper _mapper;
        public FilmsServiceFake()
        {
            _filmesList = new List<Films>()
            {
                new Films()
                {
                    Id = 0, NameFilm = "Marvel",
                    ReleaseData=new DateTime(2002,5,21),
                    Country = "USA", FKDescriptionId=1
                },
                new Films()
                {
                    Id = 1, NameFilm = "Djagernaut",
                    ReleaseData=new DateTime(2002,5,22),
                    Country = "Ikraine", FKDescriptionId=2
                }
            };

            //var config = new MapperConfiguration(cfg =>
            //        cfg.CreateMap<Films, FilmsDTO>()
            //    );
            var config2 = new MapperConfiguration(cfg =>
                    cfg.AddProfile<MappingProfile>()
                );

            _mapper = new Mapper(config2);

        }


        public async Task<IEnumerable<FilmsDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<FilmsDTO>>(_filmesList);
        }

        public async Task<FilmsDTO> GetById(int id)
        {
            var films = _filmesList.Where(a => a.Id == id).FirstOrDefault();
            if (films == null)
            {
                throw new FilmsNotFoundException(id);
            }
            else
            {
                return _mapper.Map<FilmsDTO>(films);
            }
        }

        public Task<FilmsDTO> GetByIdSpec(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FilmsDetailDTO> GetWithDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FilmsDTO> Post(FilmsForCreationDto filmsDto)
        {
            throw new NotImplementedException();
        }

        public Task Put(int id, FilmsForCreationDto filmsDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
