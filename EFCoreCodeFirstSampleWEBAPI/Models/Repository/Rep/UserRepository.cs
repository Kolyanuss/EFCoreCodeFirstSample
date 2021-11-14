using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return await GetByCondition(e => e.Id == id).FirstOrDefaultAsync();
        }

    }
}
