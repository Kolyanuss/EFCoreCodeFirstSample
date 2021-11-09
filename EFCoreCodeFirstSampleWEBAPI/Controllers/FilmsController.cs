using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataManager.Interface;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        /*private readonly IFilmsManager<Films> _manager;
        public FilmsController(IFilmsManager<Films> manager)
        {
            _manager = manager;
        }*/
        private IRepositoryWrapper _wraper;
        private IMapper _mapper;

        public FilmsController(IRepositoryWrapper wraper, IMapper mapper)
        {
            _wraper = wraper;
            _mapper = mapper;
        }

        // GET: api/Films
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Films> Filmes = _wraper.Films.GetAll();
                var Result = _mapper.Map<IEnumerable<FilmsDTO>>(Filmes);
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // GET: api/Films/5
        [HttpGet("{id}", Name = "GetFilm")]
        public IActionResult GetById(long id)
        {
            try
            {
                Films films = _wraper.Films.GetById(id);
                if (films == null)
                {
                    return NotFound("The Films record couldn't be found.");
                }
                else
                {
                    var Result = _mapper.Map<FilmsDTO>(films);
                    return Ok(Result);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Films
        [HttpPost]
        public IActionResult Post([FromBody] Films films)
        {
            try
            {
                if (films == null)
                {
                    return BadRequest("Films is null.");
                }
                _wraper.Films.Add(films);
                return CreatedAtRoute(
                      "Get",
                      new { Id = films.Id },
                      films);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Films/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Films films)
        {
            try
            {
                if (films == null)
                {
                    return BadRequest("Films is null.");
                }
                Films ToUpdate = _wraper.Films.GetById(id);
                if (ToUpdate == null)
                {
                    return NotFound("The Films record couldn't be found.");
                }
                _wraper.Films.Update(ToUpdate, films);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                Films films = _wraper.Films.GetById(id);
                if (films == null)
                {
                    return NotFound("The Films record couldn't be found.");
                }
                _wraper.Films.Delete(films);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
