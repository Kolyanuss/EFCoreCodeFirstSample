using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreCodeFirstSampleWEBAPI.Services.Abstractions;

namespace EFCoreCodeFirstSampleWEBAPI.Services
{
    public interface IServiceManager
    {
        IFilmsService FilmsService { get; }
        IUsersService UsersService { get; }
        IFilmsUsersService FilmsUsersService { get; }
    }
}
