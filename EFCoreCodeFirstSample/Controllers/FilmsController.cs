﻿using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IDataRepository<Films> _dataRepository;
        public FilmsController(IDataRepository<Films> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Films
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Films> Filmes = _dataRepository.GetAll();
            return Ok(Filmes);
        }

        // GET: api/Films/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Films films = _dataRepository.Get(id);
            if (films == null)
            {
                return NotFound("The Films record couldn't be found.");
            }
            return Ok(films);
        }

        // POST: api/Films
        [HttpPost]
        public IActionResult Post([FromBody] Films films)
        {
            if (films == null)
            {
                return BadRequest("Films is null.");
            }
            _dataRepository.Add(films);
            return CreatedAtRoute(
                  "Get",
                  new { Id = films.Id },
                  films);
        }

        // PUT: api/Films/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Films films)
        {
            if (films == null)
            {
                return BadRequest("Films is null.");
            }
            Films ToUpdate = _dataRepository.Get(id);
            if (ToUpdate == null)
            {
                return NotFound("The Films record couldn't be found.");
            }
            _dataRepository.Update(ToUpdate, films);
            return NoContent();
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Films films = _dataRepository.Get(id);
            if (films == null)
            {
                return NotFound("The Films record couldn't be found.");
            }
            _dataRepository.Delete(films);
            return NoContent();
        }
    }
}
