using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using System.Collections.Generic;
using EFCoreCodeFirstSampleWEBAPI.Models;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;

        public UserController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<User> Filmes = _wrapper.User.GetAll();
                return Ok(Filmes);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
                User user = _wrapper.User.GetById(id);
                if (user == null)
                {
                    return NotFound("The User record couldn't be found.");
                }
                return Ok(user);
            try
            {
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            _wrapper.User.Add(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.Id },
                  user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            User ToUpdate = _wrapper.User.GetById(id);
            if (ToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            _wrapper.User.Update(ToUpdate, user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _wrapper.User.GetById(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            _wrapper.User.Delete(user);
            return NoContent();
        }

    }
}
