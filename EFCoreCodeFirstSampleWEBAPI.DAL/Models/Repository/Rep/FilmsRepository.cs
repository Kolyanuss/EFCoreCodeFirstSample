using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class FilmsRepository : RepositoryBase<Films>, IFilmsRepository
    {
        public FilmsRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }

        public async Task<IEnumerable<Films>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Films> GetByIdAsync(int id)
        {
            return await GetByCondition(e => e.Id == id).FirstOrDefaultAsync();
        }

        #region eager loading
        public async Task<Films> GetByIdWithDetailsAsync(int id)
        {
            return await GetByCondition(e => e.Id == id).Include(e => e.Description).FirstOrDefaultAsync();
        }
        #endregion

    }
}
