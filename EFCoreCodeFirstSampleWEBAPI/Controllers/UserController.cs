using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Services;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Result = await _serviceManager.UsersService.Get();
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var Result = await _serviceManager.UsersService.GetById(id);
                return Ok(Result);

            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var userDtoPrint = _serviceManager.UsersService.Post(userdto);
                return CreatedAtRoute(
                      "UserById",
                      new { Id = userDtoPrint.Id },
                      userDtoPrint);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO userdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                await _serviceManager.UsersService.Put(id, userdto);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceManager.UsersService.Delete(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
