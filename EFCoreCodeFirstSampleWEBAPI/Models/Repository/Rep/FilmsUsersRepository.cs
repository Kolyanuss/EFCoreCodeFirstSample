using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class FilmsUsersRepository : RepositoryBase<FilmsUsers>, IFilmsUsersRepository
    {
        public FilmsUsersRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }

        public async Task<IEnumerable<FilmsUsers>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<FilmsUsers> GetByPairIdAsync(long id1, long id2)
        {
            return await GetByCondition(e => e.IdFilms == id1 && e.IdUser == id2).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FilmsUsers>> GetAllUsersByFilmIdAsync(long id)
        {
            return await GetByCondition(e => e.IdFilms == id).ToListAsync();
        }
        public async Task<IEnumerable<FilmsUsers>> GetAllFilmsByUserIdAsync(long id)
        {
            return await GetByCondition(e => e.IdUser == id).ToListAsync();
        }
    }
}
