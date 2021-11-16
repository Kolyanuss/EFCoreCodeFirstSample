using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using System.Collections.Generic;

namespace EFCoreCodeFirstSampleWEBAPI.Services.Abstractions
{
    public interface IUsersService
    {
        public Task<IEnumerable<UserDTO>> Get();
        public Task<UserDTO> GetById(int id);
        public UserDTO Post(UserDTO userdto);
        public Task Put(int id, UserDTO userdto);
        public Task Delete(int id);

    }
}
