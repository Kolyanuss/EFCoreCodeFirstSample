using System.Threading.Tasks;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using System.Collections.Generic;

namespace EFCoreCodeFirstSampleWEBAPI.Services.Abstractions
{
    public interface IFilmsService
    {
        public Task<IEnumerable<FilmsDTO>> GetAll();
        public Task<FilmsDTO> GetById(int id);
        public Task<FilmsDetailDTO> GetWithDetailsById(int id);
        public FilmsDTO Post(FilmsForCreationDto filmsDto);
        public Task Put(int id, FilmsForCreationDto filmsDto);
        public Task Delete(int id);

    }
}
