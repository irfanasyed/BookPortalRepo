using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStorePortal_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubInfoController : ControllerBase
    {
        private readonly IPubInfoServices _pubInfoServices;
        public PubInfoController(IPubInfoServices pubInfoServices)
        {
            _pubInfoServices = pubInfoServices;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePubInfo(int id, [FromBody] UpdatePubInfoDto updatePubInfoDto)
        {
            await _pubInfoServices.UpdatePubInfoAsync(id, updatePubInfoDto);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPubInfo(int id, [FromBody] PatchPubInfoDto patchPubInfoDto)
        {
            await _pubInfoServices.PatchPubInfoAsync(id, patchPubInfoDto);
            return NoContent();
        }
    }
}
