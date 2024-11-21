using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStorePortal_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherServices _publisherService;

        public PublishersController(IPublisherServices publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher([FromBody] CreatePublisherDto createPublisherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            var result = await _publisherService.AddPublisherAsync(createPublisherDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublisherAsync();
            return Ok(publishers);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetPublisherByName(string name)
        {
            var publishers = await _publisherService.GetPublisherByNameAsync(name);
            return Ok(publishers);
        }

        [HttpGet("by-city/{city}")]
        public async Task<IActionResult> GetPublisherByCity(string city)
        {
            var publishers = await _publisherService.GetPublisherByCityAsync(city);
            return Ok(publishers);
        }

        [HttpGet("by-state/{state}")]
        public async Task<IActionResult> GetPublisherByState(string state)
        {
            var publishers = await _publisherService.GetPublisherByStateAsync(state);
            return Ok(publishers);
        }

        [HttpGet("by-country/{country}")]
        public async Task<IActionResult> GetPublisherByCountry(string country)
        {
            var publishers = await _publisherService.GetPublisherByCountryAsync(country);
            return Ok(publishers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, [FromBody] UpdatePublisherDto updatePublisherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            var updatedPublisher = await _publisherService.UpdatePublisherAsync(id, updatePublisherDto);
            return Ok(updatedPublisher);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPublisher(int id, [FromBody] PatchPublisherDto patchPublisherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            var patchedPublisher = await _publisherService.PatchPublisherAsync(id, patchPublisherDto);
            return Ok(patchedPublisher);
        }
    }
}
