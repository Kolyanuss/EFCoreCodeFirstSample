using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;
        private IMapper _mapper;

        public UserController(IRepositoryWrapper wraper, IMapper mapper)
        {
            _wrapper = wraper;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<User> users = await _wrapper.User.GetAllAsync();
                var Result = _mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                User user = await _wrapper.User.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound("The User record couldn't be found.");
                }
                else
                {
                    var Result = _mapper.Map<UserDTO>(user);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User userdto)
        {
            try
            {
                if (userdto == null)
                {
                    return BadRequest("User is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var user = _mapper.Map<User>(userdto);
                _wrapper.User.Add(user);
                var userDtoPrint = _mapper.Map<FilmsDTO>(user);
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
        public async Task<IActionResult> Put(long id, [FromBody] User userdto)
        {
            try
            {
                if (userdto == null)
                {
                    return BadRequest("User is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                User ToUpdate = await _wrapper.User.GetByIdAsync(id);
                if (ToUpdate == null)
                {
                    return NotFound("The User record couldn't be found.");
                }
                _mapper.Map(userdto, ToUpdate);
                _wrapper.User.Update(ToUpdate);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                User user = await _wrapper.User.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound("The User record couldn't be found.");
                }
                _wrapper.User.Delete(user);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
