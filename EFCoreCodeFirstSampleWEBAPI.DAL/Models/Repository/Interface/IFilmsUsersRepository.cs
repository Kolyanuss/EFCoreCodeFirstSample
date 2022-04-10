using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface
{
    public interface IFilmsUsersRepository : IRepositoryBase<FilmsUsers>
    {
        Task<IEnumerable<FilmsUsers>> GetAllAsync();
        Task<FilmsUsers> GetByPairIdAsync(int id1, int id2);
        Task<IEnumerable<FilmsUsers>> GetAllUsersByFilmIdAsync(int id);
        Task<IEnumerable<FilmsUsers>> GetAllFilmsByUserIdAsync(int id);
    }
}
