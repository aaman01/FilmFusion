using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Services;

namespace Rest_api_Assignments.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var producers = _producerService.GetAll();
                return Ok(producers);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var producer = _producerService.GetById(id);
                return Ok(producer);
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
        public IActionResult Add([FromBody] ProducerRequest producer)
        {
            try
            {
                var producerId = _producerService.Create(producer);
                return CreatedAtAction(nameof(GetById), new { id = producerId }, producerId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProducerRequest producer)
        {
            try
            {
                _producerService.Update(id, producer);
                return Ok("Producer Updated");
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
                _producerService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
