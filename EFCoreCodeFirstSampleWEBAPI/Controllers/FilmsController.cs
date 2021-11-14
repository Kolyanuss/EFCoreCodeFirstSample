using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        /*private readonly IFilmsManager<Films> _manager; //to do: add service
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
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Films> Filmes = await _wraper.Films.GetAllAsync();
                var Result = _mapper.Map<IEnumerable<FilmsDTO>>(Filmes);
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // GET: api/Films/5
        [HttpGet("{id}", Name = "FilmById")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var films = await _wraper.Films.GetByIdAsync(id);
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
        public async Task<IActionResult> Post([FromBody] FilmsForCreationDto filmsDto)
        {
            try
            {
                if (filmsDto == null)
                {
                    return BadRequest("Films is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var films = _mapper.Map<Films>(filmsDto);
                _wraper.Films.Add(films);
                var filmsDtoPrint = _mapper.Map<FilmsDTO>(films);
                return CreatedAtRoute(
                      "FilmById",
                      new { Id = filmsDtoPrint.Id },
                      filmsDtoPrint);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Films/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] FilmsForCreationDto filmsDto)
        {
            try
            {
                if (filmsDto == null)
                {
                    return BadRequest("Films is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                Films ToUpdate = await _wraper.Films.GetByIdAsync(id);
                if (ToUpdate == null)
                {
                    return NotFound("The Films record couldn't be found.");
                }
                _mapper.Map(filmsDto, ToUpdate);
                _wraper.Films.Update(ToUpdate);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                Films films = await _wraper.Films.GetByIdAsync(id);
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
