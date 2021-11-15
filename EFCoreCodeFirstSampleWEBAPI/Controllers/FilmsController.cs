using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.Models;
using EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using EFCoreCodeFirstSampleWEBAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FilmsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        // GET: api/Films
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Result = await _serviceManager.FilmsService.GetAll();
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Films/5
        [HttpGet("{id}", Name = "FilmById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Result = await _serviceManager.FilmsService.GetById(id);
                return Ok(Result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Films/5
        [HttpGet("{id}/desc")]
        public async Task<IActionResult> GetWithDetailsById(int id)
        {
            try
            {
                var Result = await _serviceManager.FilmsService.GetWithDetailsById(id);
                return Ok(Result);
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
                var filmsDtoPrint = _serviceManager.FilmsService.Post(filmsDto);
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
        public async Task<IActionResult> Put(int id, [FromBody] FilmsForCreationDto filmsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                await _serviceManager.FilmsService.Put(id, filmsDto);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceManager.FilmsService.Delete(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
