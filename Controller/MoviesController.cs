using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Services;

namespace Rest_api_Assignments.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("")]
        public IActionResult GetAll([FromQuery] int yearOfRelease)
        {
            try
            {
                var movies = _movieService.GetAll(yearOfRelease);
                return Ok(movies);
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
                var movie = _movieService.Get(id);
                return Ok(movie);
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
        public IActionResult AddMovie([FromBody] MovieRequest movie)
        {
            try
            {
                var movieId = _movieService.Create(movie);
                return CreatedAtAction(nameof(Get), new { id = movieId }, movieId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateMovie([FromRoute] int id, [FromBody] MovieRequest movie)
        {
            try
            {
                _movieService.Update(id, movie);
                return Ok("Movie Updated");
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
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("file not selected");
            var task = await new FirebaseStorage("imdb-2-4b59e.appspot.com")
                .Child("movie_poster")
                .Child(Guid.NewGuid().ToString() + ".jpg")
                .PutAsync(file.OpenReadStream());
            return Ok(task);
        }
    }
}
