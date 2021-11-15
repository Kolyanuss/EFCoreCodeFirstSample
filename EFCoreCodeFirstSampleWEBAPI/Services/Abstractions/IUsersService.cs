using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;

namespace EFCoreCodeFirstSampleWEBAPI.Services.Abstractions
{
    public interface IUsersService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> GetById(long id);
        public Task<IActionResult> Post(UserDTO userdto);
        public Task<IActionResult> Put(long id, UserDTO userdto);
        public Task<IActionResult> Delete(long id);

    }
}
