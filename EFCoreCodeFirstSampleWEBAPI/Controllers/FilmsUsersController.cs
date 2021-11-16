using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/filmsusers")]
    [ApiController]
    public class FilmsUsersController : ControllerBase
    {
        private IRepositoryWrapper _wraper;
        private IMapper _mapper;

        public FilmsUsersController(IRepositoryWrapper wraper, IMapper mapper)
        {
            _wraper = wraper;
            _mapper = mapper;
        }

        // GET: api/FilmsUsers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<FilmsUsers> filmsUsers = await _wraper.FilmsUsers.GetAllAsync();
                var Result = _mapper.Map<IEnumerable<FilmsUsersDTO>>(filmsUsers);
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // GET: api/FilmsUsers/5/4
        [HttpGet("{id1}/{id2}", Name = "FilmUserById")]
        public async Task<IActionResult> GetById(int id1, int id2)
        {
            try
            {
                var films = await _wraper.FilmsUsers.GetByPairIdAsync(id1, id2);
                if (films == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                else
                {
                    var Result = _mapper.Map<FilmsUsersDTO>(films);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #region explicit loading
        // GET: api/FilmsUsers/5/4
        [HttpGet("{id1}/{id2}/info")]
        public async Task<IActionResult> GetByIdWithDetails(int id1, int id2)
        {
            try
            {
                var entity = await _wraper.FilmsUsers.GetByPairIdAsync(id1, id2);
                if (entity == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                else
                {
                    await _wraper.Films.GetByCondition(film => film.Id == entity.IdFilms).LoadAsync();
                    await _wraper.User.GetByCondition(user => user.Id == entity.IdUser).LoadAsync();
                    //GetByCondition(e => e.IdFilms == id1 && e.IdUser == id2).LoadAsync();
                    var Result = _mapper.Map<FilmsUsers_DetailDTO>(entity);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/FilmsUsers/filmsbyuser/5
        [HttpGet("filmsbyuser/{id1}")]
        public async Task<IActionResult> GetFilmsByUserId(int id1)
        {
            try
            {
                var entity = await _wraper.FilmsUsers.GetAllFilmsByUserIdAsync(id1);
                if (entity == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                else
                {
                    var Result = _mapper.Map<IEnumerable<FilmsUsersDTO>>(entity);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        #region explicit loading
        // GET: api/FilmsUsers/filmsbyuser/5/info
        [HttpGet("filmsbyuser/{id1}/info")]
        public async Task<IActionResult> GetFilmsByUserIdDetails(int id1)
        {
            try
            {
                var entity = await _wraper.FilmsUsers.GetAllFilmsByUserIdAsync(id1);
                if (entity == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                else
                {
                    //explicit loading
                    foreach (var it in entity)
                    {
                        await _wraper.Films.GetByCondition(film => film.Id == it.IdFilms).LoadAsync();
                    }
                    var Result = _mapper.Map<IEnumerable<FilmsDetailUsersIdDTO>>(entity);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/FilmsUsers/usersbyfilm/5
        [HttpGet("usersbyfilm/{id1}")]
        public async Task<IActionResult> GetUsersByFilmId(int id1)
        {
            try
            {
                var entity = await _wraper.FilmsUsers.GetAllUsersByFilmIdAsync(id1);
                if (entity == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                else
                {
                    var Result = _mapper.Map<IEnumerable<FilmsUsersDTO>>(entity);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        #region explicit loading
        // GET: api/FilmsUsers/usersbyfilm/5/info
        [HttpGet("usersbyfilm/{id1}/info")]
        public async Task<IActionResult> GetUsersByFilmIdDetails(int id1)
        {
            try
            {
                var entity = await _wraper.FilmsUsers.GetAllUsersByFilmIdAsync(id1);
                if (entity == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                else
                {
                    //explicit loading
                    foreach (var it in entity)
                    {
                        await _wraper.User.GetByCondition(user => user.Id == it.IdUser).LoadAsync();
                    }
                    var Result = _mapper.Map<IEnumerable<FilmsIdUsersDetailsDTO>>(entity);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion



        // POST: api/FilmsUsers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FilmsUsersDTO filmsDto)
        {
            try
            {
                if (filmsDto == null)
                {
                    return BadRequest("FilmsUsers is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var clearEntity = _mapper.Map<FilmsUsers>(filmsDto);
                _wraper.FilmsUsers.Add(clearEntity);
                var filmsDtoPrint = _mapper.Map<FilmsUsersDTO>(clearEntity);
                return CreatedAtRoute(
                      "FilmUserById",
                      new { Id1 = filmsDtoPrint.IdFilms, Id2 = filmsDtoPrint.IdUser },
                      filmsDtoPrint);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/FilmsUsers/5/5
        [HttpPut("{id1}/{id2}")]
        public async Task<IActionResult> Put(int id1, int id2, [FromBody] FilmsUsersDTO clearDto)
        {
            try
            {
                if (clearDto == null)
                {
                    return BadRequest("FilmsUsers is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                FilmsUsers ToUpdate = await _wraper.FilmsUsers.GetByPairIdAsync(id1, id2);
                if (ToUpdate == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                _mapper.Map(clearDto, ToUpdate);
                _wraper.FilmsUsers.Update(ToUpdate);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/FilmsUsers/5
        [HttpDelete("{id1}/{id2}")]
        public async Task<IActionResult> Delete(int id1, int id2)
        {
            try
            {
                FilmsUsers films = await _wraper.FilmsUsers.GetByPairIdAsync(id1, id2);
                if (films == null)
                {
                    return NotFound("The FilmsUsers record couldn't be found.");
                }
                _wraper.FilmsUsers.Delete(films);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
