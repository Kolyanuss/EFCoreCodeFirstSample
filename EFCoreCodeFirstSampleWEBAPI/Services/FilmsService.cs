using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using EFCoreCodeFirstSampleWEBAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSampleWEBAPI.Exceptions;

namespace EFCoreCodeFirstSampleWEBAPI.Services
{
    public class FilmsService : IFilmsService
    {
        private IRepositoryWrapper _wraper;
        private IMapper _mapper;

        public FilmsService(IRepositoryWrapper wraper, IMapper mapper)
        {
            _wraper = wraper;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FilmsDTO>> GetAll()
        {
            IEnumerable<Films> Filmes = await _wraper.Films.GetAllAsync();
            return _mapper.Map<IEnumerable<FilmsDTO>>(Filmes);
        }

        public async Task<FilmsDTO> GetById(int id)
        {
            var films = await _wraper.Films.GetByIdAsync(id);
            if (films == null)
            {
                throw new FilmsNotFoundException(id);
            }
            else
            {
                return _mapper.Map<FilmsDTO>(films);
            }
        }

        public async Task<FilmsDetailDTO> GetWithDetailsById(int id)
        {
            var films = await _wraper.Films.GetByIdWithDetailsAsync(id);
            if (films == null)
            {
                throw new FilmsNotFoundException(id);
            }
            else
            {
                return _mapper.Map<FilmsDetailDTO>(films);
            }
        }

        public FilmsDTO Post(FilmsForCreationDto filmsDto)
        {
            if (filmsDto == null)
            {
                throw new BadRequestException("Films is null.");
            }
            var films = _mapper.Map<Films>(filmsDto);
            _wraper.Films.Add(films);
            return _mapper.Map<FilmsDTO>(films);
        }

        public async Task Put(int id,FilmsForCreationDto filmsDto)
        {
            if (filmsDto == null)
            {
                throw new BadRequestException("Films is null.");
            }
            Films ToUpdate = await _wraper.Films.GetByIdAsync(id);
            if (ToUpdate == null)
            {
                throw new FilmsNotFoundException(id);
            }
            _mapper.Map(filmsDto, ToUpdate);
            _wraper.Films.Update(ToUpdate);
        }

        public async Task Delete(int id)
        {
            Films films = await _wraper.Films.GetByIdAsync(id);
            if (films == null)
            {
                throw new FilmsNotFoundException(id);
            }
            _wraper.Films.Delete(films);
        }
    }
}
