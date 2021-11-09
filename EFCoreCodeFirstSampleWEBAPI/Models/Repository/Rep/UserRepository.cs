using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;
using System.Linq;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }

        public User GetById(long id)
        {
            return GetByCondition(e => e.Id == id).FirstOrDefault();
        }
    }
}
