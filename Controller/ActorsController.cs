using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Services;

namespace Rest_api_Assignments.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var actors = _actorService.GetAll();
                return Ok(actors);
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
                var actor = _actorService.GetById(id);
                return Ok(actor);
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
        public IActionResult Add([FromBody] ActorRequest actor)
        {
            try
            {
                var actorId = _actorService.Create(actor);
                return CreatedAtAction(nameof(Get), new { id = actorId }, actorId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ActorRequest actor)
        {
            try
            {
                _actorService.Update(id, actor);
                return Ok("Actor Updated");
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
        public IActionResult Delete(int id)
        {
            try
            {
                _actorService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
