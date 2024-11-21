using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }
        // Create a new title
        [HttpPost]
        public async Task<IActionResult> CreateTitle([FromBody] CreateTitleDto createTitleDto)
        {
            var result = await _titleService.AddTitleAsync(createTitleDto); // Ensure it calls the correct method
            return Ok(result);
        }

        // Get all titles
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTitles()
        {
            var titles = await _titleService.GetAllTitlesAsync();
            return Ok(titles);
        }

        // Get a title by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitleById(int id)
        {
            try
            {
                var title = await _titleService.GetTitleByIdAsync(id);
                return Ok(title);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }

        // Update a title
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTitle(int id, [FromBody] UpdateTitleDto updateTitleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedTitle = await _titleService.UpdateTitleAsync(id, updateTitleDto);
                return Ok(updatedTitle);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }

        // Delete a title
        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> DeleteTitle(int id)
        //{
        //    try
        //    {
        //        var result = await _titleService.DeleteTitleAsync(id);
        //        return Ok(new { Message = result ? "Title deleted successfully." : "Failed to delete title." });
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(new { Error = ex.Message });
        //    }
        //}

        // Search titles by name
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchTitleByName(string name)
        {
            var titles = await _titleService.SearchTitlesByNameAsync(name); // Correct method to call
            return Ok(titles);
        }

        // Partially update a title
        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> PatchTitle(int id, [FromBody] PatchTitleDto patchTitleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedTitle = await _titleService.PatchTitleAsync(id, patchTitleDto);
                return Ok(updatedTitle);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }
    }
}

