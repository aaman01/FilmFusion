using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_api_Assignments.Models.DBModel;
using Rest_api_Assignments.Models.Request;
using Rest_api_Assignments.Services;

namespace Rest_api_Assignments.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var reviews = _reviewService.GetAll();
                return Ok(reviews);
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
                var review = _reviewService.Get(id);
                return Ok(review);
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
        public IActionResult AddReview([FromBody] ReviewRequest review)
        {
            try
            {
                var reviewId = _reviewService.Create(review);
                return CreatedAtAction(nameof(Get), new { id = reviewId }, reviewId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateReview([FromRoute] int id, [FromBody] ReviewRequest review)
        {
            try
            {
                _reviewService.Update(id, review);
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
        public IActionResult DeleteReview(int id)
        {
            try
            {
                _reviewService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
