using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface
{
    public interface IFilmsRepository : IRepositoryBase<Films>
    {
        Films GetById(long id);
    }
}
