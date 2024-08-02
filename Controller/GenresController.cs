using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_api_Assignments.Services;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;

namespace Rest_api_Assignments.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var genres = _genreService.GetAll();
                return Ok(genres);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var genre = _genreService.Get(id);
                return Ok(genre);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("")]
        public IActionResult AddGenre([FromBody] GenreRequest genre)
        {
            try
            {
                var genreId = _genreService.Create(genre);
                return CreatedAtAction(nameof(Get), new { id = genreId }, genreId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateGenre([FromRoute] int id, [FromBody] GenreRequest genre)
        {
            try
            {
                _genreService.Update(id, genre);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                _genreService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
