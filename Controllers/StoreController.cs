using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreDto createStoreDto)
        {
            if (createStoreDto == null)
            {
                return BadRequest("Store data is required.");
            }

            var result = await _storeService.CreateStore(createStoreDto);
            return Ok(result);  // Return the result as success
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStore()
        {
            var stores = await _storeService.GetAllStore();
            return Ok(stores);  // Return all stores
        }
        [HttpGet("{storId}")]
        public async Task<IActionResult> GetStoreById(int storId)
        {
            try
            {
                var store = await _storeService.GetStoreById(storId);
                return Ok(store);  // Return the store with the given ID
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  // Return not found if store not found
            }
        }
        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetStoresByCity(string city)
        {
            try
            {
                var stores = await _storeService.GetStoresByCity(city);
                return Ok(stores);  // Return stores by city
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  // Return not found if no store in the city
            }
        }
        [HttpGet("name/{storName}")]
        public async Task<IActionResult> GetStoresByName(string storName)
        {
            try
            {
                var stores = await _storeService.GetStoresByName(storName);
                return Ok(stores);  // Return stores by name
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  // Return not found if no store with the given name
            }
        }
        [HttpGet("zip/{zip}")]
        public async Task<IActionResult> GetStoresByZip(string zip)
        {
            try
            {
                var stores = await _storeService.GetStoresByZip(zip);
                return Ok(stores);  // Return stores by zip code
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  // Return not found if no store with the given zip
            }
        }
        [HttpPatch("{storId}")]
        public async Task<IActionResult> PatchStore(int storId, [FromBody] PatchStoreDto patchStoreDto)
        {
            if (patchStoreDto == null)
            {
                return BadRequest("Patch data is required.");
            }

            try
            {
                var result = await _storeService.PatchStore(storId, patchStoreDto);
                return Ok(result);  // Return success message for patch
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  // Return not found if store with the given id is not found
            }
        }
        [HttpPut("{storId}")]
        public async Task<IActionResult> UpdateStore(int storId, [FromBody] UpdateStoreDto updateStoreDto)
        {
            if (updateStoreDto == null)
            {
                return BadRequest("Update data is required.");
            }

            try
            {
                var result = await _storeService.UpdateStore(storId, updateStoreDto);
                return Ok(result);  // Return success message for update
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  // Return not found if store with the given id is not found
            }
        }
    }
}
