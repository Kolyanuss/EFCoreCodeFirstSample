using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface
{
    public interface IFilmsRepository : IRepositoryBase<Films>
    {
        Task<IEnumerable<Films>> GetAllAsync();
        Task<Films> GetByIdAsync(int id);
        Task<Films> GetByIdWithDetailsAsync(int id);
    }
}
