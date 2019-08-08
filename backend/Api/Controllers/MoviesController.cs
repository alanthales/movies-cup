using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _service.GetMovies();
            return Ok(movies);
        }

        [HttpPost("classification")]
        public IActionResult GetClassification([FromBody] List<Filme> filmes)
        {
            var classif = _service.GetChampions(filmes);
            return Ok(classif);
        }
    }
}
