using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Boo_Store_Portal_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("Create author")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            return Ok(await _authorService.CreateAuthor(createAuthorDto));
        }
        [HttpGet("Get all Authors")]
        public async Task<IActionResult> GetAllAuthor()
        {
            return Ok(await _authorService.GetAllAuthor());
        }
        [HttpGet("GetAuthorByLastName/{lname}")]
        public async Task<IActionResult> GetAuthorByLastName(string lastName)
        {
            return Ok(await _authorService.GetAuthorByLastName(lastName));
        }
        [HttpGet("GetAuthorByFirstName/{fname}")]
        public async Task<IActionResult> GetAuthorByFirstName(string firstName)
        {
            return Ok(await _authorService.GetAuthorByFirstName(firstName));
        }
        [HttpGet("GetAuthorByPhone/{phone}")]
        public async Task<IActionResult> GetAuthorByPhone(string phone)
        {
            return Ok(await _authorService.GetAuthorByPhone(phone));
        }
        [HttpGet("getAuthorbyZip/{zip}")]
        public async Task<IActionResult> GetAuthorByZip(string zip)
        {
            return Ok(await _authorService.GetAuthorByZip(zip));
        }
        [HttpGet("get author by state/{state}")]
        public async Task<IActionResult> GetAuthorByState(string state)
        {
            return Ok(await _authorService.GetAuthorByState(state));
        }
        [HttpGet("get author by city/{city}")]
        public async Task<IActionResult> GetAuthorByCity(string city)
        {
            return Ok(await _authorService.GetAuthorByCity(city));
        }
        [HttpPut("update author/{id}")]
        public async Task<IActionResult> UpdateAuthorById(int id,[FromBody] UpdateAuthorDto updateAuthorDto)
        {
            
            return Ok(await _authorService.UpdateAuthorById(id, updateAuthorDto));
        }
        [HttpPatch("update author by id/{id}")]
        public async Task<IActionResult> PatchAuthorById(int id,[FromBody] PatchAuthorDto patchAuthorDto)
        {
            return Ok(await _authorService.PatchAuthorById(id, patchAuthorDto));
        }
    }
}
