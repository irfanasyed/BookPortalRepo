using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyschedController : ControllerBase
    {
        private readonly IRoyschedService _royschedService;

        public RoyschedController(IRoyschedService royschedService)
        {
            _royschedService = royschedService;
        }

        // Create a new roysched
        //[HttpPost("add")]
        //public async Task<IActionResult> CreateRoysched([FromBody] CreateRoyschedDto createRoyschedDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _royschedService.CreateRoysched(createRoyschedDto);
        //    return CreatedAtAction(nameof(GetRoyschedById), new { id = result.Id }, result);
        //}

        [HttpPost("add")]
        public async Task<IActionResult> CreateRoysched([FromBody] CreateRoyschedDto createRoyschedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _royschedService.CreateRoysched(createRoyschedDto);
            return CreatedAtAction(nameof(GetRoyschedById), new { id = result.Id }, result);
        }

        // Get all royscheds
        [HttpGet("all")]
        public async Task<IActionResult> GetAllRoyscheds()
        {
            var royscheds = await _royschedService.GetAllRoyscheds();
            return Ok(royscheds);
        }

        // Get roysched by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoyschedById(int id)
        {
            try
            {
                var roysched = await _royschedService.GetRoyschedById(id);
                return Ok(roysched);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }

        // Update a roysched
        //[HttpPut("update/{id}")]
        //public async Task<IActionResult> UpdateRoysched(int id, [FromBody] UpdateRoyschedDto updateRoyschedDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var updatedRoysched = await _royschedService.UpdateRoysched(id, updateRoyschedDto);
        //        return Ok(updatedRoysched);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(new { Error = ex.Message });
        //    }
        //}

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateRoysched(int id, [FromBody] UpdateRoyschedDto updateRoyschedDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedRoysched = await _royschedService.UpdateRoysched(id, updateRoyschedDto);
                return Ok(updatedRoysched);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        // Delete a roysched
        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> DeleteRoysched(int id)
        //{
        //    try
        //    {
        //        var result = await _royschedService.DeleteRoysched(id);
        //        return Ok(new { Success = result });
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(new { Error = ex.Message });
        //    }
        //}
    }
}

