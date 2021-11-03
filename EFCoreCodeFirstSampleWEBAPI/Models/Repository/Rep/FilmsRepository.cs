using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class FilmsRepository : RepositoryBase<Films>, IFilmsRepository
    {
        public FilmsRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }
    }
}
