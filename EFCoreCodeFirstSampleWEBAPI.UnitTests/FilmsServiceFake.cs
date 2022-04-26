using EFCoreCodeFirstSampleWEBAPI.BLL.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.BLL.Interfaces.ISQLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.UnitTests
{
    public class FilmsServiceFake : IFilmsService
    {
        public FilmsServiceFake()
        {
        }


        public Task<IEnumerable<FilmsDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FilmsDTO> GetById(int id)
        {
            throw new NotImplementedException();
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
