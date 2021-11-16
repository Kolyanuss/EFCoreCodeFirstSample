using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using EFCoreCodeFirstSampleWEBAPI.Services.Abstractions;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.Exceptions;

namespace EFCoreCodeFirstSampleWEBAPI.Services
{
    public class UsersService : IUsersService
    {
        private IRepositoryWrapper _wrapper;
        private IMapper _mapper;

        public UsersService(IRepositoryWrapper wraper, IMapper mapper)
        {
            _wrapper = wraper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            IEnumerable<User> users = await _wrapper.User.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetById(int id)
        {
            User user = await _wrapper.User.GetByIdAsync(id);
            if (user == null)
            {
                throw new UsersNotFoundException(id);
            }
            else
            {
                return _mapper.Map<UserDTO>(user);
            }
        }

        public UserDTO Post(UserDTO userdto)
        {
            if (userdto == null)
            {
                throw new BadRequestException("User is null.");
            }
            var user = _mapper.Map<User>(userdto);
            _wrapper.User.Add(user);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task Put(int id, UserDTO userdto)
        {
            if (userdto == null)
            {
                throw new BadRequestException("User is null.");
            }
            User ToUpdate = await _wrapper.User.GetByIdAsync(id);
            if (ToUpdate == null)
            {
                throw new UsersNotFoundException(id);
            }
            _mapper.Map(userdto, ToUpdate);
            _wrapper.User.Update(ToUpdate);
        }

        public async Task Delete(int id)
        {
            User user = await _wrapper.User.GetByIdAsync(id);
            if (user == null)
            {
                throw new UsersNotFoundException(id);
            }
            _wrapper.User.Delete(user);
        }
    }
}
