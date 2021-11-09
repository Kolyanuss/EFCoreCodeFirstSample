using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;
using System.Linq;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep
{
    public class FilmsRepository : RepositoryBase<Films>, IFilmsRepository
    {
        public FilmsRepository(MyAppContext myAppContext) : base(myAppContext)
        {
        }

        public Films GetById(long id)
        {
            return GetByCondition(e => e.Id == id).FirstOrDefault();
        }

    }
}
