using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }
    }
}
