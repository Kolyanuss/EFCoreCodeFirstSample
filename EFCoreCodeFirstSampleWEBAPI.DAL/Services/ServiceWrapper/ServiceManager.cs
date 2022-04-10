using System;
using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using EFCoreCodeFirstSampleWEBAPI.Services.Abstractions;

namespace EFCoreCodeFirstSampleWEBAPI.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFilmsService> _lazyFilmService;
        private readonly Lazy<IUsersService> _lazyUserService;
        private readonly Lazy<IFilmsUsersService> _lazyFilmUserService;
        public ServiceManager(IRepositoryWrapper repositoryManager, IMapper mapper)
        {
            _lazyFilmService = new Lazy<IFilmsService>(() => new FilmsService(repositoryManager, mapper));
            _lazyUserService = new Lazy<IUsersService>(() => new UsersService(repositoryManager, mapper));
            _lazyFilmUserService = new Lazy<IFilmsUsersService>(() => new FilmsUsersService(repositoryManager, mapper));
        }

        public IFilmsService FilmsService => _lazyFilmService.Value;
        public IUsersService UsersService => _lazyUserService.Value;
        public IFilmsUsersService FilmsUsersService => _lazyFilmUserService.Value;
    }
}
