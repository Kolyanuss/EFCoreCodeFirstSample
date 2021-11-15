using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface
{
    public interface IFilmsUsersRepository : IRepositoryBase<FilmsUsers>
    {
        Task<IEnumerable<FilmsUsers>> GetAllAsync();
        Task<FilmsUsers> GetByPairIdAsync(long id1, long id2);
        Task<IEnumerable<FilmsUsers>> GetAllUsersByFilmIdAsync(long id);
        Task<IEnumerable<FilmsUsers>> GetAllFilmsByUserIdAsync(long id);
    }
}
