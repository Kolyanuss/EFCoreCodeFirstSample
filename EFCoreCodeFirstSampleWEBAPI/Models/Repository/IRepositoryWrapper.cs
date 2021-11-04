using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IFilmsRepository Films { get; }
        void Save();
    }
}
